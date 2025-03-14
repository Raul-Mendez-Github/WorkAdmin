using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace WorkAdmin
{
    public static class DataHandler
    {
        public static string databaseName = "Workadmin";
        public static string masterConnection = "Server=LocalHost;Integrated Security=SSPI;Initial Catalog=master;";
        public static string dataBaseConnection = $"Server=LocalHost;Integrated Security=SSPI;database={databaseName};";
        private static SqlConnection connection = new SqlConnection();
        private static SqlCommand command = new SqlCommand();
        private static string message = string.Empty;
        public enum Tables
        {
            Compra,
            Compra_tiene_Producto,
            Empleado,
            Empleado_utiliza_Producto,
            Factura,
            Producto,
            Proveedor,
            Compra_Backup,
            Empleado_Backup,
            Factura_Backup,
            Producto_Backup,
            Proveedor_Backup
        };
        public enum Views
        {
            Inventario,
            Vista_Productos_Cantidad_Comprada,
            Vista_Empleados_Uso_Productos,
            Vista_Facturas_Pendientes,
            Vista_Compras_Detalles,
            Vista_Proveedores_Productos_Mas_Comprados,
            Vista_Empleados_Contacto,
            Vista_Compras_Por_Empleado,
            Vista_Productos_Utilizados,
            Vista_Historial_Compras_Facturas
        }

        public static string CreateDatabase()
        {
            string query = File.ReadAllText(".\\ScriptCreacionBD.sql");

            try
            {
                connection = new SqlConnection(masterConnection);
                connection.Open();

                string[] batches = query.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string batch in batches)
                {
                    if (!string.IsNullOrWhiteSpace(batch))
                    {
                        command = new SqlCommand(batch, connection);
                        command.ExecuteNonQuery();
                    }
                }
                message = "La base de datos fue creada correctamente";
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error al conectarse con la base de datos \r\n" + ex.Message;
            }
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return message;
        }
        public static string DropDatabase()
        {
            string query;
            try
            {
                connection = new SqlConnection(masterConnection);
                query = $"drop database { databaseName }";
                command = new SqlCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();

                message = "Base de datos borrada con éxito";
            }
            catch (Exception ex)
            {
                message = "Ocurrio un error al conectarse con la base de datos \r\n" + ex.Message;
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return message;
        }
        public static DataTable GetDataFrom(Enum table)
        {
            DataTable dataTable = new DataTable();
            SqlDataReader reader;
            string query;

            try
            {
                connection = new SqlConnection(masterConnection);
                connection.Open();
                query = $"use { databaseName }\r\nSelect * From {table.ToString()}";
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                dataTable.Load(reader);
            }
            catch (SystemException ex)
            {
                message = "Ocurrió un error: " + ex.Message;
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return dataTable;
        }
        public static string InsertProduct(string name, string description = null, string metricUnit = null, string specification = null, string category = "REFACCION")
        {
            try
            {
                connection = new SqlConnection(dataBaseConnection);
                connection.Open();

                command = new SqlCommand($"use { databaseName }\r\nInsertarProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre", name);
                command.Parameters.AddWithValue("@descripcion", description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@unidad_medida", metricUnit ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@especificacion", specification ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@categoria", category);

                command.ExecuteNonQuery();
                message = "Producto insertado correctamente.";
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error al insertar el producto: " + ex.Message;
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return message;
        }
        public static string InsertSupplier(string name, string businessName = null, string address = null, string phoneNumber = "6120000000", string email = null)
        {
            try
            {
                connection = new SqlConnection(dataBaseConnection);
                connection.Open();

                command = new SqlCommand($"use {databaseName}\r\nInsertarProveedor", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre", name);
                command.Parameters.AddWithValue("@razon_social", businessName ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@domicilio", address ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@telefono", phoneNumber);
                command.Parameters.AddWithValue("@correo", email ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
                message = "Proveedor insertado correctamente.";
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error al insertar el proveedor: " + ex.Message;
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return message;
        }
        public static string InsertEmployee(string name, decimal salary, DateTime birthDate, string position = "EMPLEADO GENERAL", string phoneNumber = "6120000000", string email = null, string rfc = null)
        {
            try
            {
                connection = new SqlConnection(dataBaseConnection);
                connection.Open();

                command = new SqlCommand($"use {databaseName}\r\nInsertarEmpleado", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre", name);
                command.Parameters.AddWithValue("@puesto", position);
                command.Parameters.AddWithValue("@sueldo", salary);
                command.Parameters.AddWithValue("@telefono", phoneNumber);
                command.Parameters.AddWithValue("@correo", email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@rfc", rfc ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fecha_nacimiento", birthDate);

                command.ExecuteNonQuery();
                message = "Empleado insertado correctamente.";
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error al insertar el empleado: " + ex.Message;
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return message;
        }
        public static string InsertPurchase(DateTime purchaseDate, int idInvoice, int idEmployee, int idSupplier, DateTime? receptionDate = null)
        {
            try
            {
                connection = new SqlConnection(masterConnection);
                connection.Open();

                command = new SqlCommand($"use {databaseName}\r\nInsertarCompra", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@fecha_compra", purchaseDate);
                command.Parameters.AddWithValue("@fecha_recepcion", receptionDate ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@id_factura", idInvoice);
                command.Parameters.AddWithValue("@id_empleado", idEmployee);
                command.Parameters.AddWithValue("@id_proveedor", idSupplier);

                command.ExecuteNonQuery();
                message = "Compra registrada correctamente.";
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error al registrar la compra: " + ex.Message;
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return message;
        }
        public static string InsertProductUsage(DateTime date, int idEmployee, int idProduct, int quantity = 1, string reason = "Sin motivo")
        {
            try
            {
                connection = new SqlConnection(masterConnection);
                connection.Open();

                command = new SqlCommand($"use {databaseName}\r\nInsertarEmpleadoUtilizaProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@fecha", date);
                command.Parameters.AddWithValue("@cantidad", quantity);
                command.Parameters.AddWithValue("@motivo", reason);
                command.Parameters.AddWithValue("@id_empleado", idEmployee);
                command.Parameters.AddWithValue("@id_producto", idProduct);

                command.ExecuteNonQuery();
                message = "Salida de almacén registrada correctamente.";
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error al registrar la salida de almacén: " + ex.Message;
            }
            if (connection.State == ConnectionState.Open) connection.Close();
            return message;
        }
    }
}
