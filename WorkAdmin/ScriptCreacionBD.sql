-- Creación de la base de datos
-- Creación de la base de datos
IF DB_ID('Workadmin') IS NULL
BEGIN
    CREATE DATABASE Workadmin;
END
GO

USE Workadmin;
GO

-- Creación de las tablas
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Proveedor' AND xtype='U')
BEGIN
    CREATE TABLE Proveedor (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) UNIQUE NOT NULL,
        razon_social VARCHAR(150) UNIQUE,
        domicilio VARCHAR(200),
        telefono VARCHAR(10) DEFAULT '6120000000' CHECK (LEN(telefono) = 10),
        correo VARCHAR(100) UNIQUE
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Producto' AND xtype='U')
BEGIN
    CREATE TABLE Producto (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) UNIQUE NOT NULL,
        descripcion VARCHAR(200),
        unidad_medida VARCHAR(50),
        especificacion VARCHAR(100),
        categoria VARCHAR(50) DEFAULT 'REFACCION' CHECK (LEN(categoria) > 4)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empleado' AND xtype='U')
BEGIN
    CREATE TABLE Empleado (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100),
        puesto VARCHAR(50) DEFAULT 'EMPLEADO GENERAL',
        sueldo DECIMAL(10, 2),
        telefono VARCHAR(10) DEFAULT '6120000000',
        correo VARCHAR(100) UNIQUE,
        rfc VARCHAR(13) UNIQUE,
        fecha_nacimiento DATE CHECK (fecha_nacimiento > '1900-01-01' AND (YEAR(GETDATE()) - YEAR(fecha_nacimiento)) >= 18)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Compra' AND xtype='U')
BEGIN
    CREATE TABLE Compra (
        id INT IDENTITY(1,1) PRIMARY KEY,
        fecha_compra DATE CHECK (fecha_compra <= GETDATE()) NOT NULL,
        fecha_recepcion DATE,
        id_factura INT UNIQUE NOT NULL,
        id_empleado INT DEFAULT 1,
        id_proveedor INT NOT NULL,
        FOREIGN KEY (id_empleado) REFERENCES Empleado(id),
        FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Factura' AND xtype='U')
BEGIN
    CREATE TABLE Factura (
        id INT IDENTITY(1,1) PRIMARY KEY,
        folio VARCHAR(50) UNIQUE NOT NULL,
        metodo_pago VARCHAR(50),
        subtotal DECIMAL(10, 2),
        total DECIMAL(10, 2),
        estado_pago VARCHAR(50) DEFAULT 'POR PAGAR',
        fecha_emision DATE CHECK(fecha_emision <= GETDATE())
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Compra_tiene_Producto' AND xtype='U')
BEGIN
    CREATE TABLE Compra_tiene_Producto (
        cantidad INT CHECK (cantidad > 0),
        precio_unitario DECIMAL(10, 2),
        estado VARCHAR(50) DEFAULT 'Nuevo',
        observaciones VARCHAR(200),
        id_compra INT NOT NULL,
        id_producto INT NOT NULL,
        FOREIGN KEY (id_compra) REFERENCES Compra(id),
        FOREIGN KEY (id_producto) REFERENCES Producto(id)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empleado_utiliza_Producto' AND xtype='U')
BEGIN
    CREATE TABLE Empleado_utiliza_Producto (
        fecha DATE CHECK (fecha <= GETDATE()),
        cantidad INT DEFAULT 1 CHECK (cantidad > 0),
        motivo VARCHAR(200),
        id_empleado INT NOT NULL,
        id_producto INT NOT NULL,
        FOREIGN KEY (id_empleado) REFERENCES Empleado(id),
        FOREIGN KEY (id_producto) REFERENCES Producto(id)
    );
END
GO

-- Creación de la base de datos
IF DB_ID('Workadmin') IS NULL
BEGIN
    CREATE DATABASE Workadmin;
END
GO

USE Workadmin;
GO

-- Creación de las tablas principales
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Proveedor' AND xtype='U')
BEGIN
    CREATE TABLE Proveedor (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) UNIQUE NOT NULL,
        razon_social VARCHAR(150) UNIQUE,
        domicilio VARCHAR(200),
        telefono VARCHAR(10) DEFAULT '6120000000' CHECK (LEN(telefono) = 10),
        correo VARCHAR(100) UNIQUE
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Producto' AND xtype='U')
BEGIN
    CREATE TABLE Producto (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) UNIQUE NOT NULL,
        descripcion VARCHAR(200),
        unidad_medida VARCHAR(50),
        especificacion VARCHAR(100),
        categoria VARCHAR(50) DEFAULT 'REFACCION' CHECK (LEN(categoria) > 4)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empleado' AND xtype='U')
BEGIN
    CREATE TABLE Empleado (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100),
        puesto VARCHAR(50) DEFAULT 'EMPLEADO GENERAL',
        sueldo DECIMAL(10, 2),
        telefono VARCHAR(10) DEFAULT '6120000000',
        correo VARCHAR(100) UNIQUE,
        rfc VARCHAR(13) UNIQUE,
        fecha_nacimiento DATE CHECK (fecha_nacimiento > '1900-01-01' AND (YEAR(GETDATE()) - YEAR(fecha_nacimiento)) >= 18)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Compra' AND xtype='U')
BEGIN
    CREATE TABLE Compra (
        id INT IDENTITY(1,1) PRIMARY KEY,
        fecha_compra DATE CHECK (fecha_compra <= GETDATE()) NOT NULL,
        fecha_recepcion DATE,
        id_factura INT UNIQUE NOT NULL,
        id_empleado INT DEFAULT 1,
        id_proveedor INT NOT NULL,
        FOREIGN KEY (id_empleado) REFERENCES Empleado(id),
        FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Factura' AND xtype='U')
BEGIN
    CREATE TABLE Factura (
        id INT IDENTITY(1,1) PRIMARY KEY,
        folio VARCHAR(50) UNIQUE NOT NULL,
        metodo_pago VARCHAR(50),
        subtotal DECIMAL(10, 2),
        total DECIMAL(10, 2),
        estado_pago VARCHAR(50) DEFAULT 'POR PAGAR',
        fecha_emision DATE CHECK(fecha_emision <= GETDATE())
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Compra_tiene_Producto' AND xtype='U')
BEGIN
    CREATE TABLE Compra_tiene_Producto (
        cantidad INT CHECK (cantidad > 0),
        precio_unitario DECIMAL(10, 2),
        estado VARCHAR(50) DEFAULT 'Nuevo',
        observaciones VARCHAR(200),
        id_compra INT NOT NULL,
        id_producto INT NOT NULL,
        FOREIGN KEY (id_compra) REFERENCES Compra(id),
        FOREIGN KEY (id_producto) REFERENCES Producto(id)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empleado_utiliza_Producto' AND xtype='U')
BEGIN
    CREATE TABLE Empleado_utiliza_Producto (
        fecha DATE CHECK (fecha <= GETDATE()),
        cantidad INT DEFAULT 1 CHECK (cantidad > 0),
        motivo VARCHAR(200),
        id_empleado INT NOT NULL,
        id_producto INT NOT NULL,
        FOREIGN KEY (id_empleado) REFERENCES Empleado(id),
        FOREIGN KEY (id_producto) REFERENCES Producto(id)
    );
END
GO

-- Creación de tablas de respaldo
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Proveedor_Backup' AND xtype='U')
BEGIN
    CREATE TABLE Proveedor_Backup (
        id INT,
        nombre VARCHAR(100),
        razon_social VARCHAR(150),
        domicilio VARCHAR(200),
        telefono VARCHAR(10),
        correo VARCHAR(100),
        fecha_respaldo DATETIME DEFAULT GETDATE()
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Producto_Backup' AND xtype='U')
BEGIN
    CREATE TABLE Producto_Backup (
        id INT,
        nombre VARCHAR(100),
        descripcion VARCHAR(200),
        unidad_medida VARCHAR(50),
        especificacion VARCHAR(100),
        categoria VARCHAR(50),
        fecha_respaldo DATETIME DEFAULT GETDATE()
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Refacciones' AND xtype='U')
BEGIN
    CREATE TABLE Refacciones (
        id INT,
        nombre VARCHAR(100),
        descripcion VARCHAR(200),
        unidad_medida VARCHAR(50),
        especificacion VARCHAR(100),
        categoria VARCHAR(50),
        fecha_respaldo DATETIME DEFAULT GETDATE()
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empleado_Backup' AND xtype='U')
BEGIN
    CREATE TABLE Empleado_Backup (
        id INT,
        nombre VARCHAR(100),
        puesto VARCHAR(50),
        sueldo DECIMAL(10, 2),
        telefono VARCHAR(10),
        correo VARCHAR(100),
        rfc VARCHAR(13),
        fecha_nacimiento DATE,
        fecha_respaldo DATETIME DEFAULT GETDATE()
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Compra_Backup' AND xtype='U')
BEGIN
    CREATE TABLE Compra_Backup (
        id INT,
        fecha_compra DATE,
        fecha_recepcion DATE,
        id_factura INT,
        id_empleado INT,
        id_proveedor INT,
        fecha_respaldo DATETIME DEFAULT GETDATE()
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Factura_Backup' AND xtype='U')
BEGIN
    CREATE TABLE Factura_Backup (
        id INT,
        folio VARCHAR(50),
        metodo_pago VARCHAR(50),
        subtotal DECIMAL(10,2),
        total DECIMAL(10,2),
        estado_pago VARCHAR(50),
        fecha_emision DATE,
        fecha_respaldo DATETIME DEFAULT GETDATE()
    );
END
GO
-- Triggers para insertar en las tablas de respaldo
CREATE TRIGGER trg_Proveedor_Insert_Backup
ON Proveedor
AFTER INSERT
AS
BEGIN
    INSERT INTO Proveedor_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO
CREATE TRIGGER trg_Producto_Insert_Backup
ON Producto
AFTER INSERT
AS
BEGIN
    INSERT INTO Producto_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO
CREATE TRIGGER trg_Empleado_Insert_Backup
ON Empleado
AFTER INSERT
AS
BEGIN
    INSERT INTO Empleado_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO

IF EXISTS ( SELECT name FROM sysobjects WHERE type = 'TR' AND name = 'RespaldarRefaccion' )
DROP TRIGGER RespaldarRefaccion
GO
CREATE TRIGGER RespaldarRefaccion ON Producto FOR INSERT
AS
	BEGIN

		INSERT INTO Refacciones
		SELECT *, GETDATE() FROM inserted WHERE categoria = 'REFACCION'
	END
GO

CREATE TRIGGER trg_Compra_Insert_Backup
ON Compra
AFTER INSERT
AS
BEGIN
    INSERT INTO Compra_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO
CREATE TRIGGER trg_Factura_Insert_Backup
ON Factura
AFTER INSERT
AS
BEGIN
    INSERT INTO Factura_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO

-- Triggers adicionales
CREATE TRIGGER trg_Proveedor_Update_Backup
ON Proveedor
AFTER UPDATE
AS
BEGIN
    INSERT INTO Proveedor_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO
CREATE TRIGGER trg_Producto_Update_Backup
ON Producto
AFTER UPDATE
AS
BEGIN
    INSERT INTO Producto_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO
CREATE TRIGGER trg_Empleado_Update_Backup
ON Empleado
AFTER UPDATE
AS
BEGIN
    INSERT INTO Empleado_Backup
    SELECT *, GETDATE() FROM inserted;
END;
GO
-- Inserción de registros
INSERT INTO Proveedor (nombre, razon_social, domicilio, telefono, correo)
VALUES 
('Proveedor A', 'Razon Social A', 'Calle 1, Colonia Centro', '6121234567', 'proveedora@example.com'),
('Proveedor B', 'Razon Social B', 'Calle 2, Colonia Norte', '6122345678', 'proveedorb@example.com'),
('Proveedor C', 'Razon Social C', 'Calle 3, Colonia Sur', '6123456789', 'proveedorc@example.com'),
('Proveedor D', 'Razon Social D', 'Calle 4, Colonia Este', '6124567890', 'proveedord@example.com'),
('Proveedor E', 'Razon Social E', 'Calle 5, Colonia Oeste', '6125678901', 'proveedore@example.com'),
('Proveedor F', 'Razon Social F', 'Calle 6, Colonia Centro', '6126789012', 'proveedorf@example.com'),
('Proveedor G', 'Razon Social G', 'Calle 7, Colonia Norte', '6127890123', 'proveedorg@example.com'),
('Proveedor H', 'Razon Social H', 'Calle 8, Colonia Sur', '6128901234', 'proveedorh@example.com'),
('Proveedor I', 'Razon Social I', 'Calle 9, Colonia Este', '6129012345', 'proveedori@example.com'),
('Proveedor J', 'Razon Social J', 'Calle 10, Colonia Oeste', '6120123456', 'proveedorj@example.com');

INSERT INTO Producto (nombre, descripcion, unidad_medida, especificacion, categoria)
VALUES 
('Producto 1', 'Descripcion 1', 'Pieza', 'Especificacion 1', 'TORNILLERIA'),
('Producto 2', 'Descripcion 2', 'Litro', 'Especificacion 2', 'MOTOR'),
('Producto 3', 'Descripcion 3', 'Pieza', 'Especificacion 3', 'LIMPIEZA'),
('Producto 4', 'Descripcion 4', 'Litro', 'Especificacion 4', 'TRANSMISION'),
('Producto 5', 'Descripcion 5', 'Pieza', 'Especificacion 5', 'LLANTERA'),
('Producto 6', 'Descripcion 6', 'Pieza', 'Especificacion 6', 'FRENOS'),
('Producto 7', 'Descripcion 7', 'm', 'Especificacion 7', 'ACCESORIOS'),
('Producto 8', 'Descripcion 8', 'Pieza', 'Especificacion 8', 'MOTOR'),
('Producto 9', 'Descripcion 9', 'mm', 'Especificacion 9', 'TORNILLERIA'),
('Producto 10', 'Descripcion 10', 'mm', 'Especificacion 10', 'TORNILLERIA');

INSERT INTO Empleado (nombre, puesto, sueldo, telefono, correo, rfc, fecha_nacimiento)
VALUES 
('Juan Perez', 'Gerente', 25000.00, '6121111111', 'juan@example.com', 'PERJ800101ABC', '1980-01-01'),
('Mario Lopez', 'Mecanico', 8000.00, '6122222222', 'mario@example.com', 'LOPM850202ABC', '1985-02-02'),
('Carlos Sanchez', 'Encargado de compras', 12000.00, '6123333333', 'carlos@example.com', 'SANC900303ABC', '1990-03-03'),
('Axel Garcia', 'Contador', 16000.00, '6124444444', 'axel@example.com', 'GARA750404ABC', '1975-04-04'),
('Luis Martinez', 'Almacenista', 10000.00, '6125555555', 'luis@example.com', 'MART950505ABC', '1995-05-05'),
('David Ramirez', 'Ayudante de mecanico', 6000.00, '6126666666', 'david@example.com', 'RAMS800606ABC', '1980-06-06'),
('Pedro Hernandez', 'Supervisor', 20000.00, '6127777777', 'pedro@example.com', 'HERP850707ABC', '1985-07-07'),
('Eduardo Diaz', 'Mecanico', 8000.00, '6128888888', 'eduardo@example.com', 'DIAZ900808ABC', '1990-08-08'),
('Jorge Torres', 'Almacenista', 11000.00, '6129999999', 'jorge@example.com', 'TORJ750909ABC', '1975-09-09'),
('Martin Flores', 'Encargado de almacen', 16000.00, '6120000000', 'martin@example.com', 'FLOM951010ABC', '1995-10-10');

INSERT INTO Factura (folio, metodo_pago, subtotal, total, estado_pago, fecha_emision)
VALUES 
('F001', 'Efectivo', 1000.00, 1160.00, 'PAGADO', '2023-01-01'),
('F002', 'Tarjeta', 2000.00, 2320.00, 'PAGADO', '2023-02-01'),
('F003', NULL, 3000.00, 3480.00, 'POR PAGAR', '2023-03-01'),
('F004', 'Efectivo', 4000.00, 4640.00, 'PAGADO', '2023-04-01'),
('F005', 'Tarjeta', 5000.00, 5800.00, 'PAGADO', '2023-05-01'),
('F006', 'Transferencia', 6000.00, 6960.00, 'PAGADO', '2023-06-01'),
('F007', NULL, 7000.00, 8120.00, 'POR PAGAR', '2023-07-01'),
('F008', 'Tarjeta', 8000.00, 9280.00, 'PAGADO', '2023-08-01'),
('F009', 'Transferencia', 9000.00, 10440.00, 'PAGADO', '2023-09-01'),
('F010', 'Efectivo', 10000.00, 11600.00, 'PAGADO', '2023-10-01');

INSERT INTO Compra (fecha_compra, fecha_recepcion, id_factura, id_empleado, id_proveedor)
VALUES 
('2023-01-01', '2023-01-05', 1, 1, 1),
('2023-02-01', '2023-02-05', 2, 1, 2),
('2023-03-01', '2023-03-05', 3, 3, 3),
('2023-04-01', '2023-04-05', 4, 3, 4),
('2023-05-01', '2023-05-05', 5, 3, 1),
('2023-06-01', '2023-06-05', 6, 1, 6),
('2023-07-01', '2023-07-05', 7, 3, 7),
('2023-08-01', '2023-08-05', 8, 3, 2),
('2023-09-01', '2023-09-05', 9, 3, 9),
('2023-10-01', '2023-10-05', 10, 3, 10);

INSERT INTO Compra_tiene_Producto (cantidad, precio_unitario, estado, observaciones, id_compra, id_producto)
VALUES 
(10, 100.00, 'Nuevo', 'Sin observaciones', 1, 1),
(20, 200.00, 'Seminuevo', 'Sin observaciones', 2, 2),
(30, 300.00, 'Nuevo', 'Sin observaciones', 3, 3),
(40, 400.00, 'Nuevo', 'Sin observaciones', 4, 4),
(10, 500.00, 'Nuevo', NULL, 5, 5),
(30, 600.00, 'Seminuevo', 'Sin observaciones', 6, 6),
(20, 700.00, 'Seminuevo', 'Sin observaciones', 7, 7),
(15, 800.00, 'Nuevo', 'Sin observaciones', 8, 8),
(10, 900.00, 'Nuevo', 'Sin observaciones', 9, 9),
(10, 1000.00, 'Nuevo', 'Sin observaciones', 10, 10);

INSERT INTO Empleado_utiliza_Producto (fecha, cantidad, motivo, id_empleado, id_producto)
VALUES 
('2023-01-01', 1, 'Uso general', 2, 1),
('2023-02-01', 5, 'Uso general', 2, 2),
('2023-03-01', 10, 'Uso general', 6, 3),
('2023-04-01', 5, 'Uso general', 2, 4),
('2023-05-01', 3, 'Uso general', 8, 5),
('2023-06-01', 4, 'Uso general', 8, 6),
('2023-07-01', 5, 'Uso general', 6, 7),
('2023-08-01', 10, 'Uso general', 2, 8),
('2023-09-01', 9, 'Uso general', 8, 9),
('2023-10-01', 5, 'Uso general', 6, 10);

-- Procedimiento para insertar en Proveedor
IF OBJECT_ID('InsertarProveedor', 'P') IS NOT NULL
    DROP PROCEDURE InsertarProveedor;
GO
CREATE PROCEDURE InsertarProveedor
    @nombre VARCHAR(100),
    @razon_social VARCHAR(150) = NULL,
    @domicilio VARCHAR(200) = NULL,
    @telefono VARCHAR(10) = '6120000000',
    @correo VARCHAR(100) = NULL
AS
BEGIN
    BEGIN TRY
        INSERT INTO Proveedor (nombre, razon_social, domicilio, telefono, correo)
        VALUES (@nombre, @razon_social, @domicilio, @telefono, @correo);
    END TRY
    BEGIN CATCH
        SELECT ERROR_NUMBER(), ERROR_MESSAGE();
    END CATCH
END;
GO
-- Procedimiento para insertar en Producto
IF OBJECT_ID('InsertarProducto', 'P') IS NOT NULL
    DROP PROCEDURE InsertarProducto;
GO
CREATE PROCEDURE InsertarProducto
    @nombre VARCHAR(100),
    @descripcion TEXT = NULL,
    @unidad_medida VARCHAR(50) = NULL,
    @especificacion VARCHAR(100) = NULL,
    @categoria VARCHAR(50) = 'REFACCION'
AS
BEGIN
    BEGIN TRY
        INSERT INTO Producto (nombre, descripcion, unidad_medida, especificacion, categoria)
        VALUES (@nombre, @descripcion, @unidad_medida, @especificacion, @categoria);
    END TRY
    BEGIN CATCH
        SELECT ERROR_NUMBER(), ERROR_MESSAGE();
    END CATCH
END;
GO
-- Procedimiento para insertar en Empleado
IF OBJECT_ID('InsertarEmpleado', 'P') IS NOT NULL
    DROP PROCEDURE InsertarEmpleado;
GO
CREATE PROCEDURE InsertarEmpleado
    @nombre VARCHAR(100),
    @puesto VARCHAR(50) = 'EMPLEADO GENERAL',
    @sueldo DECIMAL(10, 2),
    @telefono VARCHAR(10) = '6120000000',
    @correo VARCHAR(100) = NULL,
    @rfc VARCHAR(13) = NULL,
    @fecha_nacimiento DATE
AS
BEGIN
    BEGIN TRY
        INSERT INTO Empleado (nombre, puesto, sueldo, telefono, correo, rfc, fecha_nacimiento)
        VALUES (@nombre, @puesto, @sueldo, @telefono, @correo, @rfc, @fecha_nacimiento);
    END TRY
    BEGIN CATCH
        SELECT ERROR_NUMBER(), ERROR_MESSAGE();
    END CATCH
END;
GO
-- Procedimiento para insertar en Factura
IF OBJECT_ID('InsertarFactura', 'P') IS NOT NULL
    DROP PROCEDURE InsertarFactura;
GO
CREATE PROCEDURE InsertarFactura
    @folio VARCHAR(50),
    @metodo_pago VARCHAR(50) = NULL,
    @subtotal DECIMAL(10,2),
    @total DECIMAL(10,2),
    @estado_pago VARCHAR(50) = 'POR PAGAR',
    @fecha_emision DATE
AS
BEGIN
    BEGIN TRY
        INSERT INTO Factura (folio, metodo_pago, subtotal, total, estado_pago, fecha_emision)
        VALUES (@folio, @metodo_pago, @subtotal, @total, @estado_pago, @fecha_emision);
    END TRY
    BEGIN CATCH
        SELECT ERROR_NUMBER(), ERROR_MESSAGE();
    END CATCH
END;
GO

-- Procedimiento para insertar en Compra
IF OBJECT_ID('InsertarCompra', 'P') IS NOT NULL
    DROP PROCEDURE InsertarCompra;
GO
CREATE PROCEDURE InsertarCompra
    @fecha_compra DATE,
    @fecha_recepcion DATE = NULL,
    @id_factura INT,
    @id_empleado INT = 1,
    @id_proveedor INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Compra (fecha_compra, fecha_recepcion, id_factura, id_empleado, id_proveedor)
        VALUES (@fecha_compra, @fecha_recepcion, @id_factura, @id_empleado, @id_proveedor);
    END TRY
    BEGIN CATCH
        SELECT ERROR_NUMBER(), ERROR_MESSAGE();
    END CATCH
END;
GO

-- Procedimiento para insertar en Compra_tiene_Producto
IF OBJECT_ID('InsertarCompraProducto', 'P') IS NOT NULL
    DROP PROCEDURE InsertarCompraProducto;
GO
CREATE PROCEDURE InsertarCompraProducto
    @cantidad INT,
    @precio_unitario DECIMAL(10,2),
    @estado VARCHAR(50) = 'Nuevo',
    @observaciones TEXT = NULL,
    @id_compra INT,
    @id_producto INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Compra_tiene_Producto (cantidad, precio_unitario, estado, observaciones, id_compra, id_producto)
        VALUES (@cantidad, @precio_unitario, @estado, @observaciones, @id_compra, @id_producto);
    END TRY
    BEGIN CATCH
        SELECT ERROR_NUMBER(), ERROR_MESSAGE();
    END CATCH
END;
GO

-- Procedimiento para insertar en Empleado_utiliza_Producto
IF OBJECT_ID('InsertarEmpleadoUtilizaProducto', 'P') IS NOT NULL
    DROP PROCEDURE InsertarEmpleadoUtilizaProducto;
GO
CREATE PROCEDURE InsertarEmpleadoUtilizaProducto
    @fecha DATE,
    @cantidad INT = 1,
    @motivo VARCHAR(200),
    @id_empleado INT,
    @id_producto INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Empleado_utiliza_Producto (fecha, cantidad, motivo, id_empleado, id_producto)
        VALUES (@fecha, @cantidad, @motivo, @id_empleado, @id_producto);
    END TRY
	BEGIN CATCH
        SELECT ERROR_NUMBER(), ERROR_MESSAGE();
    END CATCH
END;
GO
-- 1. Vista de inventario actual
CREATE OR ALTER VIEW Inventario AS
SELECT p.id, p.nombre, p.unidad_medida, p.descripcion,
       (SELECT COALESCE(SUM(ctp.cantidad), 0) FROM Compra_tiene_Producto ctp WHERE ctp.id_producto = p.id) -
       (SELECT COALESCE(SUM(eup.cantidad), 0) FROM Empleado_utiliza_Producto eup WHERE eup.id_producto = p.id) AS existencias
FROM Producto p;
GO

-- 2. Vista de productos y su cantidad comprada
CREATE OR ALTER VIEW Vista_Productos_Cantidad_Comprada AS
SELECT p.id AS id_producto, p.nombre AS producto, SUM(ctp.cantidad) AS total_comprado
FROM Producto p
JOIN Compra_tiene_Producto ctp ON p.id = ctp.id_producto
GROUP BY p.id, p.nombre;
GO

-- 3. Vista de empleados y su uso de productos
CREATE OR ALTER VIEW Vista_Empleados_Uso_Productos AS
SELECT e.id AS id_empleado, e.nombre AS empleado, eup.id_producto, p.nombre AS producto, SUM(eup.cantidad) AS total_usado
FROM Empleado e
JOIN Empleado_utiliza_Producto eup ON e.id = eup.id_empleado
JOIN Producto p ON eup.id_producto = p.id
GROUP BY e.id, e.nombre, eup.id_producto, p.nombre;
GO

-- 4. Vista de facturas pendientes de pago
CREATE OR ALTER VIEW Vista_Facturas_Pendientes AS
SELECT id AS id_factura, folio, metodo_pago, subtotal, total, estado_pago, fecha_emision
FROM Factura
WHERE estado_pago = 'POR PAGAR';
GO

-- 5. Vista de compras con detalles de productos
CREATE OR ALTER VIEW Vista_Compras_Detalles AS
SELECT c.id AS id_compra, c.fecha_compra, c.id_factura, c.id_proveedor, p.nombre AS proveedor, 
ctp.id_producto, pr.nombre AS producto, ctp.cantidad, ctp.precio_unitario
FROM Compra c
JOIN Compra_tiene_Producto ctp ON c.id = ctp.id_compra
JOIN Producto pr ON ctp.id_producto = pr.id
JOIN Proveedor p ON c.id_proveedor = p.id;
GO

----------------------------------------------------------------------------------------------------

-- 6. Vista de proveedores con sus productos más comprados
CREATE OR ALTER VIEW Vista_Proveedores_Productos_Mas_Comprados AS
SELECT p.id AS id_proveedor, p.nombre AS proveedor, pr.id AS id_producto, pr.nombre AS producto, SUM(ctp.cantidad) AS total_comprado
FROM Proveedor p
JOIN Compra c ON p.id = c.id_proveedor
JOIN Compra_tiene_Producto ctp ON c.id = ctp.id_compra
JOIN Producto pr ON ctp.id_producto = pr.id
GROUP BY p.id, p.nombre, pr.id, pr.nombre
GO

-- 7. Vista de empleados y sus datos de contacto
CREATE OR ALTER VIEW Vista_Empleados_Contacto AS
SELECT id AS id_empleado, nombre, puesto, telefono, correo
FROM Empleado;
GO

-- 8. Vista de compras realizadas por cada empleado
CREATE OR ALTER VIEW Vista_Compras_Por_Empleado AS
SELECT e.id AS id_empleado, e.nombre AS empleado, COUNT(c.id) AS total_compras
FROM Empleado e
JOIN Compra c ON e.id = c.id_empleado
GROUP BY e.id, e.nombre;
GO

-- 9. Vista de productos que han sido utilizados
CREATE OR ALTER VIEW Vista_Productos_Utilizados AS
SELECT p.id AS id_producto, p.nombre AS producto, SUM(eup.cantidad) AS total_utilizado
FROM Producto p
JOIN Empleado_utiliza_Producto eup ON p.id = eup.id_producto
GROUP BY p.id, p.nombre;
GO

-- 10. Vista de historial de compras y facturas
CREATE OR ALTER VIEW Vista_Historial_Compras_Facturas AS
SELECT c.id AS id_compra, c.fecha_compra, f.id AS id_factura, f.folio, f.metodo_pago, f.subtotal, f.total, f.estado_pago, f.fecha_emision
FROM Compra c
JOIN Factura f ON c.id_factura = f.id;