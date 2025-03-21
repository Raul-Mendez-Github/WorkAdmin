using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WorkAdmin.DataHandler;

namespace WorkAdmin
{
    public partial class UpdateForm : Form
    {
        private Tables _tableType;
        private Dictionary<string, object> _columnValues;

        public UpdateForm(Tables tableType, Dictionary<string, object> columnValues)
        {
            _tableType = tableType;
            _columnValues = columnValues;
            this.Text = $"Modificar {tableType}";
            //this.Size = new System.Drawing.Size(400, 350);
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.Controls.Clear();

            switch (_tableType)
            {
                case Tables.Producto:
                    ConfigureProductForm();
                    break;
                case Tables.Proveedor:
                    ConfigureSupplierForm();
                    break;
                case Tables.Empleado:
                    ConfigureEmployeeForm();
                    break;
                case Tables.Compra:
                    ConfigurePurchaseForm();
                    break;
                case Tables.Empleado_utiliza_Producto:
                    ConfigureProductUsageForm();
                    break;
                case Tables.Factura:
                    ConfigureInvoiceForm();
                    break;
                case Tables.Compra_tiene_Producto:
                    ConfigurePurchaseProductForm();
                    break;
                default:
                    MessageBox.Show("Modificaciones no permitidas en esta tabla.");
                    this.Close();
                    break;
            }
            LoadDataIntoForm(_columnValues);
        }

        private void LoadDataIntoForm(Dictionary<string, object> columnValues)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    string columnName = textBox.Tag?.ToString();
                    if (columnName != null && columnValues.ContainsKey(columnName))
                    {
                        textBox.Text = columnValues[columnName]?.ToString();
                    }
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    string columnName = dateTimePicker.Tag?.ToString();
                    if (columnName != null && columnValues.ContainsKey(columnName))
                    {
                        if (DateTime.TryParse(columnValues[columnName]?.ToString(), out DateTime dateValue))
                        {
                            dateTimePicker.Value = dateValue;
                        }
                    }
                }
            }
        }

        private void ConfigureProductForm()
        {
            // Crear y agregar controles para Producto
            var lblName = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 20) };
            var txtName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Tag = "nombre" };

            var lblDescription = new Label { Text = "Descripción:", Location = new System.Drawing.Point(20, 60) };
            var txtDescription = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200, Tag = "descripcion" };

            var lblMetricUnit = new Label { Text = "Unidad de Medida:", Location = new System.Drawing.Point(20, 100) };
            var txtMetricUnit = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200, Tag = "unidad_medida" };

            var lblSpecification = new Label { Text = "Especificación:", Location = new System.Drawing.Point(20, 140) };
            var txtSpecification = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Tag = "especificacion" };

            var lblCategory = new Label { Text = "Categoría:", Location = new System.Drawing.Point(20, 180) };
            var txtCategory = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Tag = "categoria" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    Dictionary<string, object> newValues = new Dictionary<string, object>
                {
                    { "nombre", txtName.Text },
                    { "descripcion", txtDescription.Text },
                    { "unidad_medida", txtMetricUnit.Text },
                    { "especificacion", txtSpecification.Text },
                    { "categoria", txtCategory.Text }
                };

                    Dictionary<string, object> conditions = new Dictionary<string, object>
                {
                    { "id", _columnValues["id"] } // Usar el ID como condición
                };

                    string message = DataHandler.UpdateRegister("Producto", newValues, conditions);
                    MessageBox.Show(message);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar todos los datos con formato válido.", "Error");
                }
            };

            this.Controls.AddRange(new Control[] { lblName, txtName, lblDescription, txtDescription, lblMetricUnit, txtMetricUnit, lblSpecification, txtSpecification, lblCategory, txtCategory, btnSave });
        }

        private void ConfigureSupplierForm()
        {
            // Crear y agregar controles para Proveedor
            var lblName = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 20) };
            var txtName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Tag = "nombre" };

            var lblBusinessName = new Label { Text = "Razón Social:", Location = new System.Drawing.Point(20, 60) };
            var txtBusinessName = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200, Tag = "razon_social" };

            var lblAddress = new Label { Text = "Domicilio:", Location = new System.Drawing.Point(20, 100) };
            var txtAddress = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200, Tag = "domicilio" };

            var lblPhoneNumber = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 140) };
            var txtPhoneNumber = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Tag = "telefono" };

            var lblEmail = new Label { Text = "Correo:", Location = new System.Drawing.Point(20, 180) };
            var txtEmail = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Tag = "correo" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    Dictionary<string, object> newValues = new Dictionary<string, object>
                {
                    { "nombre", txtName.Text },
                    { "razon_social", txtBusinessName.Text },
                    { "domicilio", txtAddress.Text },
                    { "telefono", txtPhoneNumber.Text },
                    { "correo", txtEmail.Text }
                };

                    Dictionary<string, object> conditions = new Dictionary<string, object>
                {
                    { "id", _columnValues["id"] } // Usar el ID como condición
                };

                    string message = DataHandler.UpdateRegister("Proveedor", newValues, conditions);
                    MessageBox.Show(message);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar todos los datos con formato válido.", "Error");
                }
            };

            this.Controls.AddRange(new Control[] { lblName, txtName, lblBusinessName, txtBusinessName, lblAddress, txtAddress, lblPhoneNumber, txtPhoneNumber, lblEmail, txtEmail, btnSave });
        }
        private void ConfigureEmployeeForm()
        {
            // Crear y agregar controles para Empleado
            var lblName = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 20) };
            var txtName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Tag = "nombre" };

            var lblPosition = new Label { Text = "Puesto:", Location = new System.Drawing.Point(20, 60) };
            var txtPosition = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200, Tag = "puesto" };

            var lblSalary = new Label { Text = "Sueldo:", Location = new System.Drawing.Point(20, 100) };
            var txtSalary = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200, Tag = "sueldo" };

            var lblPhoneNumber = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 140) };
            var txtPhoneNumber = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Tag = "telefono" };

            var lblEmail = new Label { Text = "Correo:", Location = new System.Drawing.Point(20, 180) };
            var txtEmail = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Tag = "correo" };

            var lblRFC = new Label { Text = "RFC:", Location = new System.Drawing.Point(20, 220) };
            var txtRFC = new TextBox { Location = new System.Drawing.Point(120, 220), Width = 200, Tag = "rfc" };

            var lblBirthDate = new Label { Text = "Fecha de Nacimiento:", Location = new System.Drawing.Point(20, 260) };
            var dtpBirthDate = new DateTimePicker { Location = new System.Drawing.Point(120, 260), Width = 200, Tag = "fecha_nacimiento" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 300) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    Dictionary<string, object> newValues = new Dictionary<string, object>
            {
                { "nombre", txtName.Text },
                { "puesto", txtPosition.Text },
                { "sueldo", decimal.Parse(txtSalary.Text) },
                { "telefono", txtPhoneNumber.Text },
                { "correo", txtEmail.Text },
                { "rfc", txtRFC.Text },
                { "fecha_nacimiento", dtpBirthDate.Value }
            };

                    Dictionary<string, object> conditions = new Dictionary<string, object>
            {
                { "id", _columnValues["id"] } // Usar el ID como condición
            };

                    string message = DataHandler.UpdateRegister("Empleado", newValues, conditions);
                    MessageBox.Show(message);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar todos los datos con formato válido.", "Error");
                }
            };

            this.Controls.AddRange(new Control[] { lblName, txtName, lblPosition, txtPosition, lblSalary, txtSalary, lblPhoneNumber, txtPhoneNumber, lblEmail, txtEmail, lblRFC, txtRFC, lblBirthDate, dtpBirthDate, btnSave });
        }
        private void ConfigurePurchaseForm()
        {
            // Crear y agregar controles para Compra
            var lblPurchaseDate = new Label { Text = "Fecha de Compra:", Location = new System.Drawing.Point(20, 20) };
            var dtpPurchaseDate = new DateTimePicker { Location = new System.Drawing.Point(120, 20), Width = 200, Tag = "fecha_compra" };

            var lblReceptionDate = new Label { Text = "Fecha de Recepción:", Location = new System.Drawing.Point(20, 60) };
            var dtpReceptionDate = new DateTimePicker { Location = new System.Drawing.Point(120, 60), Width = 200, Tag = "fecha_recepcion" };

            var lblInvoiceId = new Label { Text = "ID Factura:", Location = new System.Drawing.Point(20, 100) };
            var txtInvoiceId = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200, Tag = "id_factura" };

            var lblEmployeeId = new Label { Text = "ID Empleado:", Location = new System.Drawing.Point(20, 140) };
            var txtEmployeeId = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Tag = "id_empleado" };

            var lblSupplierId = new Label { Text = "ID Proveedor:", Location = new System.Drawing.Point(20, 180) };
            var txtSupplierId = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Tag = "id_proveedor" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    Dictionary<string, object> newValues = new Dictionary<string, object>
            {
                { "fecha_compra", dtpPurchaseDate.Value },
                { "fecha_recepcion", dtpReceptionDate.Value },
                { "id_factura", int.Parse(txtInvoiceId.Text) },
                { "id_empleado", int.Parse(txtEmployeeId.Text) },
                { "id_proveedor", int.Parse(txtSupplierId.Text) }
            };

                    Dictionary<string, object> conditions = new Dictionary<string, object>
            {
                { "id", _columnValues["id"] } // Usar el ID como condición
            };

                    string message = DataHandler.UpdateRegister("Compra", newValues, conditions);
                    MessageBox.Show(message);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar todos los datos con formato válido.", "Error");
                }
            };

            this.Controls.AddRange(new Control[] { lblPurchaseDate, dtpPurchaseDate, lblReceptionDate, dtpReceptionDate, lblInvoiceId, txtInvoiceId, lblEmployeeId, txtEmployeeId, lblSupplierId, txtSupplierId, btnSave });
        }

        private void ConfigureInvoiceForm()
        {
            // Crear y agregar controles para Factura
            var lblFolio = new Label { Text = "Folio:", Location = new System.Drawing.Point(20, 20) };
            var txtFolio = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Tag = "folio" };

            var lblSubtotal = new Label { Text = "Subtotal:", Location = new System.Drawing.Point(20, 60) };
            var txtSubtotal = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200, Tag = "subtotal" };

            var lblTotal = new Label { Text = "Total:", Location = new System.Drawing.Point(20, 100) };
            var txtTotal = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200, Tag = "total" };

            var lblEmissionDate = new Label { Text = "Fecha de Emisión:", Location = new System.Drawing.Point(20, 140) };
            var dtpEmissionDate = new DateTimePicker { Location = new System.Drawing.Point(120, 140), Width = 200, Tag = "fecha_emision" };

            var lblPaymentMethod = new Label { Text = "Método de Pago:", Location = new System.Drawing.Point(20, 180) };
            var txtPaymentMethod = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Tag = "metodo_pago" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    Dictionary<string, object> newValues = new Dictionary<string, object>
            {
                { "folio", txtFolio.Text },
                { "subtotal", decimal.Parse(txtSubtotal.Text) },
                { "total", decimal.Parse(txtTotal.Text) },
                { "fecha_emision", dtpEmissionDate.Value },
                { "metodo_pago", txtPaymentMethod.Text }
            };

                    Dictionary<string, object> conditions = new Dictionary<string, object>
            {
                { "id", _columnValues["id"] } // Usar el ID como condición
            };

                    string message = DataHandler.UpdateRegister("Factura", newValues, conditions);
                    MessageBox.Show(message);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar todos los datos con formato válido.", "Error");
                }
            };

            this.Controls.AddRange(new Control[] { lblFolio, txtFolio, lblSubtotal, txtSubtotal, lblTotal, txtTotal, lblEmissionDate, dtpEmissionDate, lblPaymentMethod, txtPaymentMethod, btnSave });
        }
        private void ConfigureProductUsageForm()
        {
            // Crear y agregar controles para Empleado_utiliza_Producto
            var lblDate = new Label { Text = "Fecha:", Location = new System.Drawing.Point(20, 20) };
            var dtpDate = new DateTimePicker { Location = new System.Drawing.Point(120, 20), Width = 200, Tag = "fecha" };

            var lblEmployeeId = new Label { Text = "ID Empleado:", Location = new System.Drawing.Point(20, 60) };
            var txtEmployeeId = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200, Tag = "id_empleado" };

            var lblProductId = new Label { Text = "ID Producto:", Location = new System.Drawing.Point(20, 100) };
            var txtProductId = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200, Tag = "id_producto" };

            var lblQuantity = new Label { Text = "Cantidad:", Location = new System.Drawing.Point(20, 140) };
            var txtQuantity = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Tag = "cantidad" };

            var lblReason = new Label { Text = "Motivo:", Location = new System.Drawing.Point(20, 180) };
            var txtReason = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Tag = "motivo" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    Dictionary<string, object> newValues = new Dictionary<string, object>
            {
                { "fecha", dtpDate.Value },
                { "cantidad", int.Parse(txtQuantity.Text) },
                { "motivo", txtReason.Text }
            };

                    // Usar toda la fila como clave compuesta
                    Dictionary<string, object> conditions = _columnValues;

                    string message = DataHandler.UpdateRegister("Empleado_utiliza_Producto", newValues, conditions);
                    MessageBox.Show(message);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar todos los datos con formato válido.", "Error");
                }
            };

            this.Controls.AddRange(new Control[] { lblDate, dtpDate, lblEmployeeId, txtEmployeeId, lblProductId, txtProductId, lblQuantity, txtQuantity, lblReason, txtReason, btnSave });
        }
        private void ConfigurePurchaseProductForm()
        {
            // Crear y agregar controles para Compra_tiene_Producto
            var lblQuantity = new Label { Text = "Cantidad:", Location = new System.Drawing.Point(20, 20) };
            var txtQuantity = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Tag = "cantidad" };

            var lblUnitPrice = new Label { Text = "Precio Unitario:", Location = new System.Drawing.Point(20, 60) };
            var txtUnitPrice = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200, Tag = "precio_unitario" };

            var lblPurchaseId = new Label { Text = "ID Compra:", Location = new System.Drawing.Point(20, 100) };
            var txtPurchaseId = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200, Tag = "id_compra" };

            var lblProductId = new Label { Text = "ID Producto:", Location = new System.Drawing.Point(20, 140) };
            var txtProductId = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Tag = "id_producto" };

            var lblStatus = new Label { Text = "Estado:", Location = new System.Drawing.Point(20, 180) };
            var txtStatus = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Tag = "estado" };

            var lblObservations = new Label { Text = "Observaciones:", Location = new System.Drawing.Point(20, 220) };
            var txtObservations = new TextBox { Location = new System.Drawing.Point(120, 220), Width = 200, Tag = "observaciones" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 260) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    Dictionary<string, object> newValues = new Dictionary<string, object>
            {
                { "cantidad", int.Parse(txtQuantity.Text) },
                { "precio_unitario", decimal.Parse(txtUnitPrice.Text) },
                { "estado", txtStatus.Text },
                { "observaciones", txtObservations.Text }
            };

                    // Usar toda la fila como clave compuesta
                    Dictionary<string, object> conditions = _columnValues;

                    string message = DataHandler.UpdateRegister("Compra_tiene_Producto", newValues, conditions);
                    MessageBox.Show(message);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar todos los datos con formato válido.", "Error");
                }
            };

            this.Controls.AddRange(new Control[] { lblQuantity, txtQuantity, lblUnitPrice, txtUnitPrice, lblPurchaseId, txtPurchaseId, lblProductId, txtProductId, lblStatus, txtStatus, lblObservations, txtObservations, btnSave });
        }
    }
}