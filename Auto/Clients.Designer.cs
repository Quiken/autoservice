namespace Auto
{
    partial class Clients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.search = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.vod_nomer = new System.Windows.Forms.TextBox();
            this.Адрес = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FIO = new System.Windows.Forms.TextBox();
            this.table = new System.Windows.Forms.DataGridView();
            this.add_book = new System.Windows.Forms.Button();
            this.save_book = new System.Windows.Forms.Button();
            this.delete_book = new System.Windows.Forms.Button();
            this.cost = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search.Location = new System.Drawing.Point(753, 40);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(205, 26);
            this.search.TabIndex = 261;
            this.search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(768, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 19);
            this.label6.TabIndex = 260;
            this.label6.Text = "Поиск клиента по ФИО";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(342, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(168, 22);
            this.dateTimePicker1.TabIndex = 259;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(224, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 258;
            this.label1.Text = "Дата рождения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // number
            // 
            this.number.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number.Location = new System.Drawing.Point(342, 37);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(281, 22);
            this.number.TabIndex = 257;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(212, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 17);
            this.label9.TabIndex = 256;
            this.label9.Text = "Номер телефона";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vod_nomer
            // 
            this.vod_nomer.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vod_nomer.Location = new System.Drawing.Point(430, 102);
            this.vod_nomer.Name = "vod_nomer";
            this.vod_nomer.Size = new System.Drawing.Size(212, 22);
            this.vod_nomer.TabIndex = 255;
            // 
            // Адрес
            // 
            this.Адрес.AutoSize = true;
            this.Адрес.BackColor = System.Drawing.Color.Transparent;
            this.Адрес.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Адрес.Location = new System.Drawing.Point(201, 106);
            this.Адрес.Name = "Адрес";
            this.Адрес.Size = new System.Drawing.Size(215, 17);
            this.Адрес.TabIndex = 254;
            this.Адрес.Text = "Водительское удостоверение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(158, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 17);
            this.label3.TabIndex = 252;
            this.label3.Text = "Фамилия Имя Отчество";
            // 
            // FIO
            // 
            this.FIO.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIO.Location = new System.Drawing.Point(342, 1);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(300, 22);
            this.FIO.TabIndex = 253;
            // 
            // table
            // 
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(3, 151);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(1010, 431);
            this.table.TabIndex = 251;
            this.table.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellDoubleClick);
            // 
            // add_book
            // 
            this.add_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.add_book.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_book.ForeColor = System.Drawing.Color.Black;
            this.add_book.Location = new System.Drawing.Point(11, 27);
            this.add_book.Name = "add_book";
            this.add_book.Size = new System.Drawing.Size(128, 27);
            this.add_book.TabIndex = 248;
            this.add_book.Text = "Добавить";
            this.add_book.UseVisualStyleBackColor = false;
            this.add_book.Click += new System.EventHandler(this.Add_book_Click);
            // 
            // save_book
            // 
            this.save_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.save_book.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_book.ForeColor = System.Drawing.Color.Black;
            this.save_book.Location = new System.Drawing.Point(12, 96);
            this.save_book.Name = "save_book";
            this.save_book.Size = new System.Drawing.Size(128, 30);
            this.save_book.TabIndex = 250;
            this.save_book.Text = "Сохранить";
            this.save_book.UseVisualStyleBackColor = false;
            this.save_book.Click += new System.EventHandler(this.Save_book_Click);
            // 
            // delete_book
            // 
            this.delete_book.BackColor = System.Drawing.Color.Red;
            this.delete_book.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete_book.ForeColor = System.Drawing.Color.White;
            this.delete_book.Location = new System.Drawing.Point(11, 60);
            this.delete_book.Name = "delete_book";
            this.delete_book.Size = new System.Drawing.Size(128, 30);
            this.delete_book.TabIndex = 249;
            this.delete_book.Text = "Удалить";
            this.delete_book.UseVisualStyleBackColor = false;
            this.delete_book.Click += new System.EventHandler(this.Delete_book_Click);
            // 
            // cost
            // 
            this.cost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cost.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cost.ForeColor = System.Drawing.Color.Red;
            this.cost.Location = new System.Drawing.Point(707, 99);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(148, 30);
            this.cost.TabIndex = 263;
            this.cost.Text = "Приобрести карту";
            this.cost.UseVisualStyleBackColor = false;
            this.cost.Click += new System.EventHandler(this.Cost_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Auto.Properties.Resources.изолированная_лупа_с_вектором_значка_глаза_голубым_на_белой_139926786;
            this.pictureBox2.Location = new System.Drawing.Point(694, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 262;
            this.pictureBox2.TabStop = false;
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 582);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.search);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.number);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.vod_nomer);
            this.Controls.Add(this.Адрес);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FIO);
            this.Controls.Add(this.table);
            this.Controls.Add(this.add_book);
            this.Controls.Add(this.save_book);
            this.Controls.Add(this.delete_book);
            this.Name = "Clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";
            this.Load += new System.EventHandler(this.Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox vod_nomer;
        private System.Windows.Forms.Label Адрес;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button add_book;
        private System.Windows.Forms.Button save_book;
        private System.Windows.Forms.Button delete_book;
        private System.Windows.Forms.Button cost;
    }
}