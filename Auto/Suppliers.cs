using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto
{
    public partial class Suppliers : Form
    {
        DataSet ds;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();

        public Suppliers()
        {
            InitializeComponent();

            Loading();
        }
        public void Loading()
        {
            name.Text = "";
            number_phone_providers.Text = "";
            INN_providers.Text = "";
            // Настройки таблицы

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select * FROM `provider` ORDER BY `Код поставщика` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "provider");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }
        private void Add_book_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text == "" || number_phone_providers.Text == "" || INN_providers.Text == "") // Проверка правильности введенных исходных данных
                {
                    MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
                }
                else
                {

                    string commandText = string.Format("INSERT INTO `provider` (`Наименование поставщика`, `Телефон`, `ИНН`) VALUES ('{0}', '{1}', '{2}')", name.Text, number_phone_providers.Text, INN_providers.Text); // Cтрока передачи данных

                    my_command = new MySqlCommand(commandText, my_conn);

                    my_conn.Open(); // Открытие соединения с базой данных

                    my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                    MessageBox.Show("Поставщик добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении поставщика

                    Loading();
                }
            }
            catch
            {
                MessageBox.Show("Проверьте правильность заполнения поля ИНН!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void Delete_book_Click(object sender, EventArgs e)
        {
            try
            {
                int a = table.CurrentRow.Index; // Выделенная строка в таблице

                string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

                string sql_delete = string.Format("DELETE FROM `provider` WHERE (`Код поставщика`) = {0}", id_table); // запрос на удаление в БД

                my_command = new MySqlCommand(sql_delete, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных 

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                my_conn.Close();

                Loading();

                MessageBox.Show("Поставщик успешно удален!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении поставщика

            }
            catch
            {
                MessageBox.Show("Не можете удалить информацию, так как эти данные находятся в связанных таблицах!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
            }
        }

        private void Save_book_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value);

            string strQuery = string.Format("UPDATE `provider` SET `Наименование поставщика` = @param1, `Телефон` = @param2, `ИНН` = @param3 WHERE `Код поставщика` = {0}", id_table); // Строка передачи данных

            my_command = new MySqlCommand(strQuery, my_conn);

            my_conn.Open();

            // Обновление соответствующих столбцов
            my_command.Parameters.AddWithValue("@param1", table.Rows[a].Cells["Наименование поставщика"].Value);
            my_command.Parameters.AddWithValue("@param2", table.Rows[a].Cells["Телефон"].Value);
            my_command.Parameters.AddWithValue("@param3", table.Rows[a].Cells["ИНН"].Value);

            my_command.ExecuteNonQuery();
            my_conn.Close();

            Loading();

            MessageBox.Show("Данные о поставщике успешно обновлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об изменении данных о поставщике
        }
    }
}
