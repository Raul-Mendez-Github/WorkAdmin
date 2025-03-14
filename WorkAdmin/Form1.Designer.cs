namespace WorkAdmin
{
    partial class MainMenu
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.btnDeleteDB = new System.Windows.Forms.Button();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxView = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(387, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Workadmin";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(411, 102);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(186, 51);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insertar registro";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(68, 102);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(102, 51);
            this.btnCreateDB.TabIndex = 3;
            this.btnCreateDB.Text = "Crear BD";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // btnDeleteDB
            // 
            this.btnDeleteDB.Location = new System.Drawing.Point(252, 102);
            this.btnDeleteDB.Name = "btnDeleteDB";
            this.btnDeleteDB.Size = new System.Drawing.Size(112, 51);
            this.btnDeleteDB.TabIndex = 4;
            this.btnDeleteDB.Text = "Eliminar BD";
            this.btnDeleteDB.UseVisualStyleBackColor = true;
            this.btnDeleteDB.Click += new System.EventHandler(this.btnDeleteDB_Click);
            // 
            // dataGridViewSelect
            // 
            this.dataGridViewSelect.AllowUserToAddRows = false;
            this.dataGridViewSelect.AllowUserToDeleteRows = false;
            this.dataGridViewSelect.AllowUserToResizeColumns = false;
            this.dataGridViewSelect.AllowUserToResizeRows = false;
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelect.Location = new System.Drawing.Point(12, 205);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.ReadOnly = true;
            this.dataGridViewSelect.RowHeadersVisible = false;
            this.dataGridViewSelect.RowHeadersWidth = 62;
            this.dataGridViewSelect.RowTemplate.Height = 28;
            this.dataGridViewSelect.Size = new System.Drawing.Size(1018, 423);
            this.dataGridViewSelect.TabIndex = 5;
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(754, 89);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(204, 28);
            this.comboBoxTable.TabIndex = 6;
            this.comboBoxTable.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTable_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(696, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tabla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(750, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Consultar vista:";
            // 
            // comboBoxView
            // 
            this.comboBoxView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxView.FormattingEnabled = true;
            this.comboBoxView.Location = new System.Drawing.Point(615, 155);
            this.comboBoxView.Name = "comboBoxView";
            this.comboBoxView.Size = new System.Drawing.Size(391, 28);
            this.comboBoxView.TabIndex = 8;
            this.comboBoxView.SelectionChangeCommitted += new System.EventHandler(this.comboBoxView_SelectionChangeCommitted);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 640);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTable);
            this.Controls.Add(this.dataGridViewSelect);
            this.Controls.Add(this.btnDeleteDB);
            this.Controls.Add(this.btnCreateDB);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Button btnDeleteDB;
        private System.Windows.Forms.DataGridView dataGridViewSelect;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxTable;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBoxView;
    }
}

