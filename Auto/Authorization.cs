﻿using System;
using System.Windows.Forms;

namespace Auto
{
    public partial class Authorization : Form
    {
        public string connectionString = "Database=auto_repair;Data Source=localhost;username=root;password=root"; // Строка подключения
        public Authorization()
        {
            InitializeComponent();

            login.Text = "Administrator";
            password.Text = "admin";

            //login.Text = "Employee";
            //password.Text = "employee";
        }

        private void entrance_Click(object sender, EventArgs e)
        {
            if (login.Text == "Administrator" && password.Text == "admin")
            {
                // Открытие нового окна
                Employee employee = new Employee();
                this.Hide();
                employee.ShowDialog();
                this.Show();
            }
            if (login.Text == "Employee" && password.Text == "employee")
            {
                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Такого пользователя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
