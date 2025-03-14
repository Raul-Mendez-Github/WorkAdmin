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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblTitle.Location = new System.Drawing.Point(295, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(272, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Workadmin";
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnInsert.Location = new System.Drawing.Point(103, 129);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(198, 33);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insertar registro";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDB.Location = new System.Drawing.Point(56, 74);
            this.btnCreateDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(105, 33);
            this.btnCreateDB.TabIndex = 3;
            this.btnCreateDB.Text = "Crear BD";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // btnDeleteDB
            // 
            this.btnDeleteDB.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnDeleteDB.Location = new System.Drawing.Point(228, 74);
            this.btnDeleteDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteDB.Name = "btnDeleteDB";
            this.btnDeleteDB.Size = new System.Drawing.Size(138, 33);
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
            this.dataGridViewSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSelect.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelect.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSelect.Location = new System.Drawing.Point(11, 183);
            this.dataGridViewSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelect.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSelect.RowHeadersVisible = false;
            this.dataGridViewSelect.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.dataGridViewSelect.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSelect.RowTemplate.Height = 28;
            this.dataGridViewSelect.Size = new System.Drawing.Size(861, 344);
            this.dataGridViewSelect.TabIndex = 5;
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(592, 74);
            this.comboBoxTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(280, 30);
            this.comboBoxTable.TabIndex = 6;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxTable_SelectedIndexChanged);
            this.comboBoxTable.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTable_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label1.Location = new System.Drawing.Point(441, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tabla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label2.Location = new System.Drawing.Point(441, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Consultar vista:";
            // 
            // comboBoxView
            // 
            this.comboBoxView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxView.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.comboBoxView.FormattingEnabled = true;
            this.comboBoxView.Location = new System.Drawing.Point(592, 126);
            this.comboBoxView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxView.Name = "comboBoxView";
            this.comboBoxView.Size = new System.Drawing.Size(280, 30);
            this.comboBoxView.TabIndex = 8;
            this.comboBoxView.SelectedIndexChanged += new System.EventHandler(this.comboBoxView_SelectedIndexChanged);
            this.comboBoxView.SelectionChangeCommitted += new System.EventHandler(this.comboBoxView_SelectionChangeCommitted);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 538);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkAdmin";
            this.Load += new System.EventHandler(this.MainMenu_Load);
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

