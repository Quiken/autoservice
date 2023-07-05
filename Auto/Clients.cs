using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto
{
    public partial class Clients : Form
    {
        DataSet ds;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();

        public int n;
        public string di, FIO_1;
        public Clients()
        {
            InitializeComponent();

            Loading();
        }
        public void Loading()
        {
            FIO.Text = "";
            vod_nomer.Text = "";
            number.Text = "";
            // Настройки таблицы

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select * FROM `client` ORDER BY `Код клиента` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "Клиент");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Add_book_Click(object sender, EventArgs e)
        {
            if (FIO.Text == "" || vod_nomer.Text == "" || number.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string commandText = string.Format("INSERT INTO `client` (`ФИО`, `Номер телефона`, `Дата рождения`, `Водительское удостоверение`) VALUES ('{0}', '{1}', '{2:yyyy.MM.dd}', '{3}')", FIO.Text, number.Text, dateTimePicker1.Value, vod_nomer.Text); // Cтрока передачи данных

                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                my_command = new MySqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                Loading();
            }
        }

        private void Delete_book_Click(object sender, EventArgs e)
        {
            try
            {
                int a = table.CurrentRow.Index; // Выделенная строка в таблице

                string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

                string sql_delete = string.Format("DELETE FROM `client` WHERE (`Код клиента`) = {0}", id_table); // запрос на удаление в БД

                my_command = new MySqlCommand(sql_delete, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных 

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                Loading();

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении

            }
            catch
            {
                MessageBox.Show("Не можете удалить информацию, так как эти данные находятся в связанных таблицах!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
            }
        }

        private void Save_book_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

            string strQuery = string.Format("UPDATE `client` SET `ФИО` = @param1, `Номер телефона` = @param2, `Дата рождения` = @param3, `Водительское удостоверение` = @param4 WHERE `Код клиента` = {0}", id_table); // Строка передачи данных

            my_command = new MySqlCommand(strQuery, my_conn);

            my_conn.Open();

            // Обновление соответствующих столбцов
            my_command.Parameters.AddWithValue("@param1", table.Rows[a].Cells["ФИО"].Value);
            my_command.Parameters.AddWithValue("@param2", table.Rows[a].Cells["Номер телефона"].Value);
            my_command.Parameters.AddWithValue("@param3", table.Rows[a].Cells["Дата рождения"].Value);
            my_command.Parameters.AddWithValue("@param4", table.Rows[a].Cells["Водительское удостоверение"].Value);

            my_command.ExecuteNonQuery();


            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении

            Loading();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "[ФИО] LIKE '" + search.Text + "%'"; // Критерий поиска
        }

        private void Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = table.CurrentRow.Index;

                string id_buyer = Convert.ToString(table.Rows[a].Cells[0].Value);

                string name_buyer = Convert.ToString(table.Rows[a].Cells[1].Value);

                Form1 form1 = this.Owner as Form1;
                form1.id_buyer.Text = id_buyer;
                form1.name_buyer.Text = name_buyer;

                this.Close();
            }
            catch { }
        }

        private void Cost_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            di = Convert.ToString(table.Rows[a].Cells[0].Value);
            FIO_1 = Convert.ToString(table.Rows[a].Cells[1].Value);

            Card card = new Card(di, FIO_1);
            card.Owner = this;
            card.ShowDialog();
        }
    }
}
