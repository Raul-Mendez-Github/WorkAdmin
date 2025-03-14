using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace WorkAdmin
{
    public partial class MainMenu : Form
    {
        DataHandler.Tables selectedTable;
        DataHandler.Views selectedView;
        public MainMenu()
        {
            InitializeComponent();
            LoadEnumOnComboBox(comboBoxTable, selectedTable);
            LoadEnumOnComboBox(comboBoxView, selectedView);
        }
        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            string connection = DataHandler.CreateDatabase();
            ShowResultOf(connection);
        }

        private void btnDeleteDB_Click(object sender, EventArgs e)
        {
            ShowResultOf(DataHandler.DropDatabase());
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertionForm insertionForm = new InsertionForm(selectedTable);
            insertionForm.ShowDialog();
        }
        private void comboBoxTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var combobox = (ComboBox)sender;
            selectedTable = (DataHandler.Tables)combobox.SelectedItem;
            LoadData(dataGridViewSelect, selectedTable);
        }
        private void comboBoxView_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var combobox = (ComboBox)sender;
            selectedView = (DataHandler.Views)combobox.SelectedItem;
            LoadData(dataGridViewSelect, selectedView);
        }
        private void ShowResultOf(string connectionState)
        {
            MessageBox.Show(connectionState);
        }
        private void LoadEnumOnComboBox(ComboBox comboBox, Enum enumType)
        {
            comboBox.Items.Clear();
            foreach (var value in Enum.GetValues(enumType.GetType()))
            {
                comboBox.Items.Add(value);
            }
        }
        private void LoadData(DataGridView dataGridView, Enum enumType)
        {
            DataTable data = DataHandler.GetDataFrom(enumType);
            dataGridView.DataSource = data;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
        }

        private void comboBoxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInsert.Enabled = false;
        }
    }
}