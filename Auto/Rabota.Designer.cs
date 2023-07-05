namespace Auto
{
    partial class Rabota
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
            this.table_2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.table_2)).BeginInit();
            this.SuspendLayout();
            // 
            // table_2
            // 
            this.table_2.AllowUserToAddRows = false;
            this.table_2.AllowUserToDeleteRows = false;
            this.table_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_2.Location = new System.Drawing.Point(1, 2);
            this.table_2.Name = "table_2";
            this.table_2.ReadOnly = true;
            this.table_2.Size = new System.Drawing.Size(983, 581);
            this.table_2.TabIndex = 263;
            this.table_2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_2_CellDoubleClick);
            // 
            // Rabota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 584);
            this.Controls.Add(this.table_2);
            this.Name = "Rabota";
            this.Text = "Виды работ";
            this.Load += new System.EventHandler(this.Rabota_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView table_2;
    }
}