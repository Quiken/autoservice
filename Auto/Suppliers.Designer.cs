namespace Auto
{
    partial class Suppliers
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.INN_providers = new System.Windows.Forms.TextBox();
            this.number_phone_providers = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.table = new System.Windows.Forms.DataGridView();
            this.add_book = new System.Windows.Forms.Button();
            this.save_book = new System.Windows.Forms.Button();
            this.delete_book = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(103, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 292;
            this.label2.Text = "ИНН";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 22);
            this.label1.TabIndex = 291;
            this.label1.Text = "Номер телефона";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 22);
            this.label6.TabIndex = 290;
            this.label6.Text = "Наименование";
            // 
            // INN_providers
            // 
            this.INN_providers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.INN_providers.Location = new System.Drawing.Point(175, 90);
            this.INN_providers.Name = "INN_providers";
            this.INN_providers.Size = new System.Drawing.Size(314, 24);
            this.INN_providers.TabIndex = 286;
            // 
            // number_phone_providers
            // 
            this.number_phone_providers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number_phone_providers.Location = new System.Drawing.Point(175, 50);
            this.number_phone_providers.Name = "number_phone_providers";
            this.number_phone_providers.Size = new System.Drawing.Size(312, 24);
            this.number_phone_providers.TabIndex = 285;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(175, 12);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(312, 24);
            this.name.TabIndex = 284;
            // 
            // table
            // 
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(2, 120);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(1071, 463);
            this.table.TabIndex = 293;
            // 
            // add_book
            // 
            this.add_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.add_book.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_book.ForeColor = System.Drawing.Color.Black;
            this.add_book.Location = new System.Drawing.Point(663, 9);
            this.add_book.Name = "add_book";
            this.add_book.Size = new System.Drawing.Size(128, 27);
            this.add_book.TabIndex = 294;
            this.add_book.Text = "Добавить";
            this.add_book.UseVisualStyleBackColor = false;
            this.add_book.Click += new System.EventHandler(this.Add_book_Click);
            // 
            // save_book
            // 
            this.save_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.save_book.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_book.ForeColor = System.Drawing.Color.Black;
            this.save_book.Location = new System.Drawing.Point(754, 50);
            this.save_book.Name = "save_book";
            this.save_book.Size = new System.Drawing.Size(128, 30);
            this.save_book.TabIndex = 296;
            this.save_book.Text = "Сохранить";
            this.save_book.UseVisualStyleBackColor = false;
            this.save_book.Click += new System.EventHandler(this.Save_book_Click);
            // 
            // delete_book
            // 
            this.delete_book.BackColor = System.Drawing.Color.Red;
            this.delete_book.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete_book.ForeColor = System.Drawing.Color.White;
            this.delete_book.Location = new System.Drawing.Point(555, 50);
            this.delete_book.Name = "delete_book";
            this.delete_book.Size = new System.Drawing.Size(128, 30);
            this.delete_book.TabIndex = 295;
            this.delete_book.Text = "Удалить";
            this.delete_book.UseVisualStyleBackColor = false;
            this.delete_book.Click += new System.EventHandler(this.Delete_book_Click);
            // 
            // Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 584);
            this.Controls.Add(this.add_book);
            this.Controls.Add(this.save_book);
            this.Controls.Add(this.delete_book);
            this.Controls.Add(this.table);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.INN_providers);
            this.Controls.Add(this.number_phone_providers);
            this.Controls.Add(this.name);
            this.Name = "Suppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поставщики";
            this.Load += new System.EventHandler(this.Suppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox INN_providers;
        private System.Windows.Forms.TextBox number_phone_providers;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button add_book;
        private System.Windows.Forms.Button save_book;
        private System.Windows.Forms.Button delete_book;
    }
}