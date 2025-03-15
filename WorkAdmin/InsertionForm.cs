using System;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using WorkAdmin;
using static WorkAdmin.DataHandler;

namespace WorkAdmin
{
    public partial class InsertionForm : Form
    {
        private Tables _tableType;

        public InsertionForm(Tables tableType)
        {
            InitializeComponent();
            _tableType = tableType;
        }
        private void InsertionForm_Load(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Inserciones directas no permitidas en esta tabla.");
                    this.Close();
                    break;
            }
        }

        private void ConfigureProductForm()
        {
            this.Text = "Insertar Producto";

            // Crear y agregar controles para Producto
            var lblName = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 20) };
            var txtName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var lblDescription = new Label { Text = "Descripción:", Location = new System.Drawing.Point(20, 60) };
            var txtDescription = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200 };

            var lblMetricUnit = new Label { Text = "Unidad de Medida:", Location = new System.Drawing.Point(20, 100) };
            var txtMetricUnit = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            var lblSpecification = new Label { Text = "Especificación:", Location = new System.Drawing.Point(20, 140) };
            var txtSpecification = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200 };

            var lblCategory = new Label { Text = "Categoría:", Location = new System.Drawing.Point(20, 180) };
            var txtCategory = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Text = "REFACCION" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                string message = DataHandler.InsertProduct(
                    NullStringEmptys(txtName.Text),
                    NullStringEmptys(txtDescription.Text),
                    NullStringEmptys(txtMetricUnit.Text),
                    NullStringEmptys(txtSpecification.Text),
                    NullStringEmptys(txtCategory.Text)
                );
                MessageBox.Show(message);
                this.Close();
            };

            this.Controls.AddRange(new Control[] { lblName, txtName, lblDescription, txtDescription, lblMetricUnit, txtMetricUnit, lblSpecification, txtSpecification, lblCategory, txtCategory, btnSave });
        }

        private void ConfigureSupplierForm()
        {
            this.Text = "Insertar Proveedor";

            // Crear y agregar controles para Proveedor
            var lblName = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 20) };
            var txtName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var lblBusinessName = new Label { Text = "Razón Social:", Location = new System.Drawing.Point(20, 60) };
            var txtBusinessName = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200 };

            var lblAddress = new Label { Text = "Domicilio:", Location = new System.Drawing.Point(20, 100) };
            var txtAddress = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            var lblPhoneNumber = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 140) };
            var txtPhoneNumber = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Text = "6120000000" };

            var lblEmail = new Label { Text = "Correo:", Location = new System.Drawing.Point(20, 180) };
            var txtEmail = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200 };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    string message = DataHandler.InsertSupplier(
                        NullStringEmptys(txtName.Text),
                        NullStringEmptys(txtBusinessName.Text),
                        NullStringEmptys(txtAddress.Text),
                        NullStringEmptys(txtPhoneNumber.Text),
                        NullStringEmptys(txtEmail.Text)
                    );
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
            this.Text = "Insertar Empleado";

            // Crear y agregar controles para Empleado
            var lblName = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 20) };
            var txtName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var lblPosition = new Label { Text = "Puesto:", Location = new System.Drawing.Point(20, 60) };
            var txtPosition = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200, Text = "EMPLEADO GENERAL" };

            var lblSalary = new Label { Text = "Sueldo:", Location = new System.Drawing.Point(20, 100) };
            var txtSalary = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            var lblPhoneNumber = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 140) };
            var txtPhoneNumber = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Text = "6120000000" };

            var lblEmail = new Label { Text = "Correo:", Location = new System.Drawing.Point(20, 180) };
            var txtEmail = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200 };

            var lblRFC = new Label { Text = "RFC:", Location = new System.Drawing.Point(20, 220) };
            var txtRFC = new TextBox { Location = new System.Drawing.Point(120, 220), Width = 200 };

            var lblBirthDate = new Label { Text = "Fecha de Nacimiento:", Location = new System.Drawing.Point(20, 260) };
            var dtpBirthDate = new DateTimePicker { Location = new System.Drawing.Point(120, 260), Width = 200 };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 300) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    string message = DataHandler.InsertEmployee(
                        NullStringEmptys(txtName.Text),
                        decimal.Parse(txtSalary.Text),
                        dtpBirthDate.Value,
                        NullStringEmptys(txtPosition.Text),
                        NullStringEmptys(txtPhoneNumber.Text),
                        NullStringEmptys(txtEmail.Text),
                        NullStringEmptys(txtRFC.Text)
                    );
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
            this.Text = "Insertar Compra";

            // Crear y agregar controles para Compra
            var lblPurchaseDate = new Label { Text = "Fecha de Compra:", Location = new System.Drawing.Point(20, 20) };
            var dtpPurchaseDate = new DateTimePicker { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var lblReceptionDate = new Label { Text = "Fecha de Recepción:", Location = new System.Drawing.Point(20, 60) };
            var dtpReceptionDate = new DateTimePicker { Location = new System.Drawing.Point(120, 60), Width = 200 };

            var lblInvoiceId = new Label { Text = "ID Factura:", Location = new System.Drawing.Point(20, 100) };
            var txtInvoiceId = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            var lblEmployeeId = new Label { Text = "ID Empleado:", Location = new System.Drawing.Point(20, 140) };
            var txtEmployeeId = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200 };

            var lblSupplierId = new Label { Text = "ID Proveedor:", Location = new System.Drawing.Point(20, 180) };
            var txtSupplierId = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200 };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    string message = DataHandler.InsertPurchase(
                        dtpPurchaseDate.Value,
                        int.Parse(txtInvoiceId.Text),
                        int.Parse(txtEmployeeId.Text),
                        int.Parse(txtSupplierId.Text),
                        dtpReceptionDate.Value
                    );
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

        private void ConfigureProductUsageForm()
        {
            this.Text = "Registrar Uso de Producto";

            // Crear y agregar controles para Empleado_utiliza_Producto
            var lblDate = new Label { Text = "Fecha:", Location = new System.Drawing.Point(20, 20) };
            var dtpDate = new DateTimePicker { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var lblEmployeeId = new Label { Text = "ID Empleado:", Location = new System.Drawing.Point(20, 60) };
            var txtEmployeeId = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200 };

            var lblProductId = new Label { Text = "ID Producto:", Location = new System.Drawing.Point(20, 100) };
            var txtProductId = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200,  };

            var lblQuantity = new Label { Text = "Cantidad:", Location = new System.Drawing.Point(20, 140) };
            var txtQuantity = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200, Text = "1" };

            var lblReason = new Label { Text = "Motivo:", Location = new System.Drawing.Point(20, 180) };
            var txtReason = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Text = "Sin motivo" };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    string message = DataHandler.InsertProductUsage(
                        dtpDate.Value,
                        int.Parse(txtEmployeeId.Text),
                        int.Parse(txtProductId.Text),
                        int.Parse(txtQuantity.Text),
                        NullStringEmptys(txtReason.Text)
                    );
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
        private void ConfigureInvoiceForm()
        {
            this.Text = "Insertar Factura";

            var lblFolio = new Label { Text = "Folio:", Location = new System.Drawing.Point(20, 20) };
            var txtFolio = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var lblSubtotal = new Label { Text = "Subtotal:", Location = new System.Drawing.Point(20, 60) };
            var txtSubtotal = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200 };

            var lblTotal = new Label { Text = "Total:", Location = new System.Drawing.Point(20, 100) };
            var txtTotal = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            var lblEmissionDate = new Label { Text = "Fecha de Emisión:", Location = new System.Drawing.Point(20, 140) };
            var dtpEmissionDate = new DateTimePicker { Location = new System.Drawing.Point(120, 140), Width = 200 };

            var lblPaymentMethod = new Label { Text = "Método de Pago:", Location = new System.Drawing.Point(20, 180) };
            var txtPaymentMethod = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200 };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 220) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    string folio = txtFolio.Text;
                    decimal subtotal = decimal.Parse(txtSubtotal.Text);
                    decimal total = decimal.Parse(txtTotal.Text);
                    DateTime emissionDate = dtpEmissionDate.Value;
                    string paymentMethod = txtPaymentMethod.Text;

                    string message = DataHandler.InsertInvoice(
                        folio,
                        subtotal,
                        total,
                        emissionDate,
                        paymentMethod
                    );
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
        private void ConfigurePurchaseProductForm()
        {
            this.Text = "Asociar Producto a Compra";

            // Crear y agregar controles para Compra_tiene_Producto
            var lblQuantity = new Label { Text = "Cantidad:", Location = new System.Drawing.Point(20, 20) };
            var txtQuantity = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var lblUnitPrice = new Label { Text = "Precio Unitario:", Location = new System.Drawing.Point(20, 60) };
            var txtUnitPrice = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200 };

            var lblPurchaseId = new Label { Text = "ID Compra:", Location = new System.Drawing.Point(20, 100) };
            var txtPurchaseId = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            var lblProductId = new Label { Text = "ID Producto:", Location = new System.Drawing.Point(20, 140) };
            var txtProductId = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 200 };

            var lblStatus = new Label { Text = "Estado:", Location = new System.Drawing.Point(20, 180) };
            var txtStatus = new TextBox { Location = new System.Drawing.Point(120, 180), Width = 200, Text = "Nuevo" };

            var lblObservations = new Label { Text = "Observaciones:", Location = new System.Drawing.Point(20, 220) };
            var txtObservations = new TextBox { Location = new System.Drawing.Point(120, 220), Width = 200 };

            var btnSave = new Button { Text = "Guardar", Location = new System.Drawing.Point(120, 260) };
            btnSave.Click += (sender, e) =>
            {
                try
                {
                    int quantity = int.Parse(txtQuantity.Text);
                    decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
                    int purchaseId = int.Parse(txtPurchaseId.Text);
                    int productId = int.Parse(txtProductId.Text);
                    string status = txtStatus.Text;
                    string observations = txtObservations.Text;

                    string message = DataHandler.InsertPurchaseProduct(
                        quantity,
                        unitPrice,
                        purchaseId,
                        productId,
                        status,
                        observations
                    );
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
        private string NullStringEmptys(string text)
        {
            return (text == string.Empty) ? null : text;
        }
        private int? NullIntParseStringEmptys(string text)
        {
            if (NullStringEmptys(text) == null) return null;
            if (!int.TryParse(text, out int value)) return null;
            return value;
        }
    }
}