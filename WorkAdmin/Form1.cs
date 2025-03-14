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
            InsertionForm insertionForm = new InsertionForm();
            insertionForm.ShowDialog();
        }
        private void comboBoxTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDataAccordingToComboBox((ComboBox)sender, dataGridViewSelect, selectedTable);
        }
        private void comboBoxView_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDataAccordingToComboBox((ComboBox)sender, dataGridViewSelect, selectedView);
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
        private void LoadDataAccordingToComboBox(ComboBox comboBox, DataGridView dataGridView, Enum enumType)
        {
            Enum selectedEnumValue = (Enum)comboBox.SelectedItem;
            DataTable data = DataHandler.GetDataFrom(selectedEnumValue);
            dataGridView.DataSource = data;
        }
    }
}