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
    public partial class Oborud : Form
    {
        DataSet ds;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();
        public Oborud()
        {
            InitializeComponent();

            Loading();
        }
        public void Loading()
        {
            name.Text = "";
            price.Text = "";
            garant.Text = "";
            // Настройки таблицы

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select * FROM `oborud` ORDER BY `Код оборудования` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "oborud");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Add_book_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || price.Text == "" || garant.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string price_ = price.Text.Replace(",", ".");

                string commandText = string.Format("INSERT INTO `oborud` (`Наименование оборудования`, `Дата изготовления`, `Стоимость`, `Срок гарантии`) VALUES ('{0}', '{1:yyyy.MM.dd}', '{2}', '{3}')", name.Text, dateTimePicker1.Value, price_, garant.Text); // Cтрока передачи данных

                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                my_command = new MySqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                Loading();
            }
        }

        private void Oborud_Load(object sender, EventArgs e)
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

                string sql_delete = string.Format("DELETE FROM `oborud` WHERE (`Код оборудования`) = {0}", id_table); // запрос на удаление в БД

                my_command = new MySqlCommand(sql_delete, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных 

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                my_conn.Close();

                Loading();

                MessageBox.Show("Информация успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении поставщика

            }
            catch
            {
                MessageBox.Show("Не можете удалить информацию, так как эти данные находятся в связанных таблицах!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
            }
        }

        private void Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = table.CurrentRow.Index;

                string id_obor = Convert.ToString(table.Rows[a].Cells[0].Value);

                string obor = Convert.ToString(table.Rows[a].Cells[1].Value);

                Form1 form1 = this.Owner as Form1;
                form1.id_obor.Text = id_obor;
                form1.obor.Text = obor;

                this.Close();
            }
            catch { }
        }
    }
}
