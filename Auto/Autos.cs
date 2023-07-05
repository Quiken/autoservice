using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto
{
    public partial class Autos : Form
    {
        DataSet ds;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();
        public Autos()
        {
            InitializeComponent();

            Loading();
        }
        public void Loading()
        {
            name.Text = "";
            nomer.Text = "";
            passport.Text = "";
            // Настройки таблицы

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select * FROM auto ORDER BY `Код автомобиля` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "auto");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }
        // Кнопка добавить автомобиль
        private void add_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || nomer.Text == "" || passport.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибк
            }
            else
            {
                string commandText = string.Format("INSERT INTO `auto` (`Марка`, `Регистрационный знак`, `Год выпуска`, `Технический паспорт`) VALUES ('{0}', '{1}', '{2}', '{3}')", name.Text, nomer.Text, add_years.Text, passport.Text); // Cтрока передачи данных

                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                my_command = new MySqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                Loading();
            }
        }

        private void Autos_Load(object sender, EventArgs e)
        {
            for (int n = 1950; n <= 2021; n++)
                add_years.Items.Add(Convert.ToString(n)); // Заполнение года от 1950 до 2020

            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        // Кнопка удалить
        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int a = table.CurrentRow.Index; // Выделенная строка в таблице

                string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

                string sql_delete = string.Format("DELETE FROM `auto` WHERE `Код автомобиля` = {0}", id_table); // запрос на удаление в БД

                my_command = new MySqlCommand(sql_delete, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных 

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                my_conn.Close();

                Loading();

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении

            }
            catch
            {
                MessageBox.Show("Не можете удалить информацию, так как эти данные находятся в связанных таблицах!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
            }
        }
        // Кнопка сохранить изменения
        private void save_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

            string strQuery = string.Format("UPDATE `auto` SET `Марка` = @param1, `Регистрационный знак` = @param2, `Год выпуска` = @param3, `Технический паспорт` = @param4 WHERE `Код автомобиля` = {0}", id_table); // Строка передачи данных

            my_command = new MySqlCommand(strQuery, my_conn);

            my_conn.Open();

            // Обновление соответствующих столбцов
            my_command.Parameters.AddWithValue("@param1", table.Rows[a].Cells["Марка"].Value);
            my_command.Parameters.AddWithValue("@param2", table.Rows[a].Cells["Регистрационный знак"].Value);
            my_command.Parameters.AddWithValue("@param3", table.Rows[a].Cells["Год выпуска"].Value);
            my_command.Parameters.AddWithValue("@param4", table.Rows[a].Cells["Технический паспорт"].Value);

            my_command.ExecuteNonQuery();

            my_conn.Close();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении

            Loading();
        }


        private void Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = table.CurrentRow.Index;

                string id_auto = Convert.ToString(table.Rows[a].Cells[0].Value);

                string auto = Convert.ToString(table.Rows[a].Cells[1].Value);

                Form1 form1 = this.Owner as Form1;
                form1.id_auto.Text = id_auto;
                form1.auto.Text = auto;

                this.Close();
            }
            catch { }
        }
    }
}
