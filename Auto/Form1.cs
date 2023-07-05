using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto
{
    public partial class Form1 : Form
    {
        DataSet ds, ds_1;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();
        string sls = "";
        public Form1()
        {
            InitializeComponent();

            Loading_2();

            //Настройка выпадающего списка
           my_data = new MySqlDataAdapter("select * from employee", authorization.connectionString);

            DataTable tbl = new DataTable();

            my_data.Fill(tbl);

            employee.DataSource = tbl;
            employee.DisplayMember = "ФИО";// столбец для отображения
            employee.ValueMember = "Код сотрудника";//столбец с id
        }
       
        // Поиск клиента по фамилии
        private void search_buyer_TextChanged(object sender, EventArgs e)
        {
            ds_1.Tables[0].DefaultView.RowFilter = "[ФИО клиента] LIKE '" + search_buyer.Text + "%'"; // Критерий поиска
        }
        public void Loading_2()
        {
            id_rabot.Text = "";
            rabot.Text = "";
            id_zapt.Text = "";
            zapt.Text = "";
            id_obor.Text = "";
            obor.Text = "";
            // Настройки таблицы

            table_2.ColumnHeadersDefaultCellStyle.Font = new Font(table_2.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold); // Шрифт и размер названий столбцов
            table_2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table_2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table_2.DefaultCellStyle.Font = new Font("Times New Roman", 12); // Шрифт и размер строк

            ds_1 = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "Select w.`Код заказа`, y.ФИО as `ФИО клиента`, u.Марка, u.`Регистрационный знак`, q.`Вид работы`, e.`Наименование оборудования`, r.`Наименование запчасти`, t.`ФИО` as `ФИО сотрудника`, w.`Дата поступления` " +
                " FROM `ordering_services` as w " +
                " JOIN `client` as y ON y.`Код клиента` = w.`Код клиента` " +
                " JOIN `auto` as u ON u.`Код автомобиля` = w.`Код автомобиля` " +
                " JOIN `rabota` as q ON q.`Код работы` = w.`Код работы` " +
                " JOIN oborud as e ON e.`Код оборудования` = w.`Код оборудования` " +
                " JOIN zapt as r ON r.`Код запчасти` = w.`Код запчасти` " +
                " JOIN employee as t ON t.`Код сотрудника` = w.`Код сотрудника` ORDER BY w.`Код заказа` ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds_1, "ordering_services");//Заполняем DataSet cодержимым DataAdapter'a

            table_2.DataSource = ds_1.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Завершение работы программы при закрытии
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        // Кнопка информация
        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для ведения учета работы автомастерской", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table_2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table_2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Owner = this;
            clients.ShowDialog();
        }

        private void ПоставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Owner = this;
            suppliers.ShowDialog();
        }

        private void ЗапчастиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zapt zapt = new Zapt();
            zapt.Owner = this;
            zapt.ShowDialog();
        }

        private void ОборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oborud oborud = new Oborud();
            oborud.Owner = this;
            oborud.ShowDialog();
        }


        // Кнопка добавить автомобиль
        private void добавитьАвтомобильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autos autos = new Autos();
            autos.Owner = this;
            autos.ShowDialog();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Rabota rabota = new Rabota();
            rabota.Owner = this;
            rabota.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int a = table_2.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table_2.Rows[a].Cells[0].Value); // номер строки для удаления

            string sql_delete = string.Format("DELETE FROM `ordering_services` WHERE (`Код заказа`) = {0}", id_table); // запрос на удаление в БД

            my_command = new MySqlCommand(sql_delete, my_conn);

            my_conn.Open(); // Открытие соединения с базой данных 

            my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

            Loading_2();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

            string sql = "`summa`"; //Sql запрос (достать все из таблицы ...)

            my_data = new MySqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "Услуги заказа");//Заполняем DataSet cодержимым DataAdapter'a

            table_2.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Loading_2();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (id_rabot.Text == "" || id_zapt.Text == "" || id_obor.Text == "") // Проверка правильности введенных исходных данных
                {
                    MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
                }
                else
                {
                    my_conn.Open(); // Открытие соединения с базой данных

                    my_command = my_conn.CreateCommand();

                    my_command.CommandText = "Select * from employee where ФИО  ='" + employee.Text + "';";

                    MySqlDataReader sdr = my_command.ExecuteReader();

                    while (sdr.Read())
                    {
                        sls = sdr.GetString("Код сотрудника");
                    }
                  
                    my_conn.Close();

                    string commandText = string.Format("INSERT INTO `ordering_services` (`Код работы`, `Код оборудования`, `Код запчасти`, `Код сотрудника`, `Код клиента`, `Код автомобиля`, `Дата поступления`) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, '{6:yyyy.MM.dd}')", id_rabot.Text, id_obor.Text, id_zapt.Text, sls, id_buyer.Text, id_auto.Text, dateTimePicker1.Value); // Cтрока передачи данных

                    my_conn = new MySqlConnection(authorization.connectionString); //Создаем соеденение

                    my_command = new MySqlCommand(commandText, my_conn);

                    my_conn.Open(); // Открытие соединения с базой данных

                    my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                    MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                    Loading_2();
                }
            }
            catch
            {
                MessageBox.Show("Отсутствует необходимое количество товара на складе!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении
            }
        }
    }
}
