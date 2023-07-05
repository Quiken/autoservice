using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto
{
    public partial class Employee : Form
    {
        DataSet ds, ds_1;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();
        public Employee()
        {
            InitializeComponent();

            Loading();

            Loading_1();
        }
        public void Loading()
        {
            FIO.Text = "";
            adress.Text = "";
            number.Text = "";
            // Настройки таблицы

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select * FROM employee ORDER BY `Код сотрудника` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "employee");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }
        // Кнопка добавить
        private void add_book_Click(object sender, EventArgs e)
        {
            if (FIO.Text == "" || adress.Text == "" || number.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string commandText = string.Format("INSERT INTO `employee` (`ФИО`, `Дата рождения`, `Адрес`, `Номер телефона`) VALUES ('{0}', '{1:yyyy.MM.dd}', '{2}', '{3}')", FIO.Text, dateTimePicker1.Value, adress.Text, number.Text); // Cтрока передачи данных

                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                my_command = new MySqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                Loading();
            }
        }
        // Настройка таблицы (все умещалось)
        private void Employee_Load(object sender, EventArgs e)
        {
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            table_2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table_2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        // Кнопка удалить
        private void delete_book_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

            string sql_delete = string.Format("DELETE FROM `employee` WHERE (`Код сотрудника`) = {0}", id_table); // запрос на удаление в БД

            my_command = new MySqlCommand(sql_delete, my_conn);

            my_conn.Open(); // Открытие соединения с базой данных 

            my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

            Loading();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
        }
        // Кнопка сохранить изменения в таблице
        private void save_book_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

            string strQuery = string.Format("UPDATE `employee` SET `ФИО` = @param1, `Дата рождения` = @param2, `Адрес` = @param3, `Номер телефона` = @param4 WHERE `Код сотрудника` = {0}", id_table); // Строка передачи данных

            my_command = new MySqlCommand(strQuery, my_conn);

            my_conn.Open();

            // Обновление соответствующих столбцов
            my_command.Parameters.AddWithValue("@param1", table.Rows[a].Cells["ФИО"].Value);
            my_command.Parameters.AddWithValue("@param2", table.Rows[a].Cells["Дата рождения"].Value);
            my_command.Parameters.AddWithValue("@param3", table.Rows[a].Cells["Адрес"].Value);
            my_command.Parameters.AddWithValue("@param4", table.Rows[a].Cells["Номер телефона"].Value);

            my_command.ExecuteNonQuery();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении

            Loading();
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "[ФИО] LIKE '" + search.Text + "%'"; // Критерий поиска
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Loading_1()
        {
            name.Text = "";
            price.Text = "";
            srok.Text = "";
            garant.Text = "";
            // Настройки таблицы

            table_2.ColumnHeadersDefaultCellStyle.Font = new Font(table_2.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table_2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table_2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table_2.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds_1 = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select * FROM `rabota` ORDER BY `Код работы` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds_1, "rabota");//Заполняем DataSet cодержимым DataAdapter'a

            table_2.DataSource = ds_1.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

            string sql_delete = string.Format("DELETE FROM `rabota` WHERE (`Код работы`) = {0}", id_table); // запрос на удаление в БД

            my_command = new MySqlCommand(sql_delete, my_conn);

            my_conn.Open(); // Открытие соединения с базой данных 

            my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

            Loading_1();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int a = table_2.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table_2.Rows[a].Cells[0].Value); // номер строки для удаления

            string strQuery = string.Format("UPDATE `rabota` SET `Вид работы` = @param1, `Стоимость` = @param2, `Срок выполнения` = @param3, `Гарантия` = @param4 WHERE `Код работы` = {0}", id_table); // Строка передачи данных

            my_command = new MySqlCommand(strQuery, my_conn);

            my_conn.Open();

            // Обновление соответствующих столбцов
            my_command.Parameters.AddWithValue("@param1", table_2.Rows[a].Cells["Вид работы"].Value);
            my_command.Parameters.AddWithValue("@param2", table_2.Rows[a].Cells["Стоимость"].Value);
            my_command.Parameters.AddWithValue("@param3", table_2.Rows[a].Cells["Срок выполнения"].Value);
            my_command.Parameters.AddWithValue("@param4", table_2.Rows[a].Cells["Гарантия"].Value);

            my_command.ExecuteNonQuery();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении

            Loading_1();
        }

        private void Show_1_Click(object sender, EventArgs e)
        {
            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "summa_sotrudnik"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "ordering_services");//Заполняем DataSet cодержимым DataAdapter'a

            table_3.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Show_2_Click(object sender, EventArgs e)
        {
            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "summa_obsh"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "ordering_services");//Заполняем DataSet cодержимым DataAdapter'a

            table_3.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "summa_sotrudnik_mesac"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "ordering_services");//Заполняем DataSet cодержимым DataAdapter'a

            table_3.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "zarplata"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "ordering_services");//Заполняем DataSet cодержимым DataAdapter'a

            table_3.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || price.Text == "" || garant.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string price_ = price.Text.Replace(",", ".");

                string commandText = string.Format("INSERT INTO `rabota` (`Вид работы`, `Стоимость`, `Срок выполнения`, `Гарантия`) VALUES ('{0}', '{1}', '{2}', '{3}')", name.Text, price_, srok.Text, garant.Text); // Cтрока передачи данных

                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                my_command = new MySqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                Loading_1();
            }
        }
    }
}
