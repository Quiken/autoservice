using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto
{
    public partial class Card : Form
    {
        DataSet ds;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();
        public Card(string di, string FIO_1)
        {
            InitializeComponent();

            Loading();
            this.di = di;
            this.FIO_1 = FIO_1;

            id_buyer.Text = di;
            id_card.Text = di;
            name_buyer.Text = FIO_1;
        }
        string di, FIO_1;
        public void Loading()
        {
            id_card.Text = "";
            id_buyer.Text = "";
            name_buyer.Text = "";
            // Настройки таблицы

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select w.`Код клиента`, p.`ФИО`, u.`Дата приобретения`, u.`Количество бонусов`, u.Скидка " +
                " FROM `cli_dis` as w JOIN `client` as p ON p.`Код клиента` = w.`Код клиента` JOIN discont as u ON u.`Код карты` = w.`Код карты` ORDER BY w.`Код клиента` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "Клиент_дисконт");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1

            add_book.Enabled = false;
        }
        
        private void Cost_Click(object sender, EventArgs e)
        {
            try
            {
                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                string commandText = string.Format("INSERT INTO `discont` (`Код карты`, `Дата приобретения`, `Количество бонусов`, `Скидка`) VALUES ({0},'{1:yyyy.MM.dd}', {2}, {3})", id_card.Text, dateTimePicker1.Value, bonus.Text, discount.Text); // Cтрока передачи данных

                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                my_command = new MySqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                add_book.Enabled = true;
                cost.Enabled = false;
            }
            catch
            {
                MessageBox.Show("У данного клиента карта есть!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
        }

        private void Add_book_Click(object sender, EventArgs e)
        {
            if (id_card.Text == "" || id_buyer.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Сначала выберите клиента или создайте карту!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string commandText = string.Format("INSERT INTO `cli_dis` (`Код клиента`, `Код карты`) VALUES ({0}, {1})", id_buyer.Text, id_card.Text); // Cтрока передачи данных

                my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                my_command = new MySqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                Loading();
            }
        }

        private void Card_Load(object sender, EventArgs e)
        {
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            bonus.Text = "0";
            discount.Text = "0";
        }
    }
}
