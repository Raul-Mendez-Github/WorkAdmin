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
using static WorkAdmin.DataHandler;
using ComboBox = System.Windows.Forms.ComboBox;

namespace WorkAdmin
{
    public partial class MainMenu : Form
    {
        DataHandler.Tables selectedTable;
        DataHandler.Views selectedView;
        bool shownIsTable = false;
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
            Refresh();
        }
        private void comboBoxTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedEnumValue = (DataHandler.Tables)comboBox.SelectedItem;
            selectedTable = selectedEnumValue;
            LoadData(dataGridViewSelect, selectedEnumValue);

            shownIsTable = true;
            ValidateEnableModifying();
        }
        private void comboBoxView_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedEnumValue = (DataHandler.Views)comboBox.SelectedItem;
            selectedView = selectedEnumValue;
            LoadData(dataGridViewSelect, selectedEnumValue);

            shownIsTable = false;
            ValidateEnableModifying();
        }
        private void ShowResultOf(string connectionState)
        {
            MessageBox.Show(connectionState);
        }
        private void LoadEnumOnComboBox(ComboBox comboBox, Enum enumType)
        {
            comboBox.Items.Clear();
            comboBox.DataSource = null;
            comboBox.DataSource = Enum.GetValues(enumType.GetType());
        }
        private void LoadData(DataGridView dataGridView, Enum enumType)
        {
            DataTable data = DataHandler.GetDataFrom(enumType);
            dataGridView.DataSource = data;
        }
        private void dataGridViewSelect_SelectionChanged(object sender, EventArgs e)
        {
            ValidateEnableModifying();
        }
        private void ValidateEnableModifying()
        {
            if (dataGridViewSelect.SelectedRows.Count > 0 && shownIsTable)
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnInsertar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnInsertar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSelect.SelectedRows.Count == 0) return;

            Dictionary<string, object> columnValues = new Dictionary<string, object>();

            foreach (DataGridViewColumn column in dataGridViewSelect.Columns)
            {
                object cellValue = dataGridViewSelect.SelectedRows[0].Cells[column.Name].Value;

                columnValues.Add(column.Name, cellValue);
            }

            string result = DataHandler.DeleteRegister(selectedTable.ToString(), columnValues);

            MessageBox.Show(result);
            Refresh();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSelect.SelectedRows.Count == 0) return;

            Dictionary<string, object> columnValues = new Dictionary<string, object>();

            foreach (DataGridViewColumn column in dataGridViewSelect.Columns)
            {
                object cellValue = dataGridViewSelect.SelectedRows[0].Cells[column.Name].Value;
                columnValues.Add(column.Name, cellValue);
            }

            UpdateForm updateForm = new UpdateForm(selectedTable, columnValues);
            updateForm.ShowDialog();
            Refresh();
        }
        private void Refresh()
        {
            LoadData(dataGridViewSelect, selectedTable);
        }
    }
}