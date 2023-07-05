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
    public partial class Zapt : Form
    {
        DataSet ds;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();

        string sls = "";
        public Zapt()
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

            string sql = "Select w.`Код запчасти`, w.`Наименование запчасти`, w.Стоимость, w.Гарантия, w.`Дата поступления`, w.Количество, p.`Наименование поставщика` " +
                " FROM `zapt` as w JOIN `provider` as p ON p.`Код поставщика` = w.`Код поставщика` ORDER BY w.`Код запчасти` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "zapt");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }
        private void Zapt_Load(object sender, EventArgs e)
        {
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Настройка выпадающего списка
            my_data = new MySqlDataAdapter("select * from provider", authorization.connectionString);

            DataTable tbl = new DataTable();

            my_data.Fill(tbl);

            status.DataSource = tbl;
            status.DisplayMember = "Наименование поставщика";// столбец для отображения
            status.ValueMember = "Код поставщика";//столбец с id
        }

        private void Add_book_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || price.Text == "" || garant.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                my_conn.Open(); // Открытие соединения с базой данных

                my_command = my_conn.CreateCommand();

                my_command.CommandText = "Select * from `provider` where `Наименование поставщика`  ='" + status.Text + "';";

                MySqlDataReader sdr = my_command.ExecuteReader();

                while (sdr.Read())
                {
                    sls = sdr.GetString("Код поставщика");
                }

                my_conn.Close();

                string price_ = price.Text.Replace(",", ".");

                string commandText = string.Format("INSERT INTO `zapt` (`Наименование запчасти`, `Стоимость`, `Гарантия`, `Код поставщика`, `Дата поступления`, `Количество`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4:yyyy.MM.dd}', {5})", name.Text, price_, garant.Text, sls, dateTimePicker1.Value, count.Text); // Cтрока передачи данных

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

                string sql_delete = string.Format("DELETE FROM `zapt` WHERE (`Код запчасти`) = {0}", id_table); // запрос на удаление в БД

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

        private void Search_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "[Наименование запчасти] LIKE '" + search.Text + "%'"; // Критерий поиска
        }

        private void Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = table.CurrentRow.Index;

                string id_zapt = Convert.ToString(table.Rows[a].Cells[0].Value);

                string zapt = Convert.ToString(table.Rows[a].Cells[1].Value);

                Form1 form1 = this.Owner as Form1;
                form1.id_zapt.Text = id_zapt;
                form1.zapt.Text = zapt;

                this.Close();
            }
            catch { }
        }
    }
}
