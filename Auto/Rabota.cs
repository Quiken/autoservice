using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Auto
{
    public partial class Rabota : Form
    {
        DataSet ds, ds_1;
        MySqlConnection my_conn;
        MySqlDataAdapter my_data;
        MySqlCommand my_command;

        Authorization authorization = new Authorization();
        public Rabota()
        {
            InitializeComponent();

            Loading_1();
        }

        private void Table_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = table_2.CurrentRow.Index;

                string id_rabot = Convert.ToString(table_2.Rows[a].Cells[0].Value);

                string rabot = Convert.ToString(table_2.Rows[a].Cells[1].Value);

                Form1 form1 = this.Owner as Form1;
                form1.id_rabot.Text = id_rabot;
                form1.rabot.Text = rabot;

                this.Close();
            }
            catch { }
        }

        private void Rabota_Load(object sender, EventArgs e)
        {
            table_2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table_2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void Loading_1()
        {
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
    }
}
