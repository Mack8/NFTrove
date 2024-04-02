USE MASTER
-- Verificar si la base de datos existe y eliminarla si es necesario
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'BD_NFT')
BEGIN
    ALTER DATABASE BD_NFT SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BD_NFT;
END;
GO

-- Crear la base de datos
CREATE DATABASE BD_NFT;
GO

-- Usar la base de datos
USE BD_NFT;
GO

ALTER AUTHORIZATION ON DATABASE::BD_NFT TO sa;
GO

-- Crear la tabla Rol
CREATE TABLE Rol (
    ID INT PRIMARY KEY,
    NombreRol VARCHAR(50) UNIQUE NOT NULL,
    Descripcion VARCHAR(100)
);

-- Insertar datos de ejemplo en la tabla Rol
INSERT INTO Rol (ID, NombreRol, Descripcion) VALUES
(1, 'Administrador', 'Acceso completo al sistema'),
(2, 'Ventas', 'Acceso a realizar Ventas'),
(3, 'Reporteria', 'Acceso a realizar Reportes');

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    ID INT PRIMARY KEY,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    CorreoElectronico VARCHAR(100) UNIQUE NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    RolID INT,
    FOREIGN KEY (RolID) REFERENCES Rol(ID)
);

-- Crear la tabla PAIS
CREATE TABLE PAIS (
    ID INT PRIMARY KEY,
    ISO CHAR(3) UNIQUE,
    Descripcion VARCHAR(100)
);

-- Crear la tabla CLIENTE
CREATE TABLE CLIENTE (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
    Identificacion VARCHAR(50),
    CorreoElectronico VARCHAR(100),
    PaisID INT,
    FOREIGN KEY (PaisID) REFERENCES Pais(ID)
);

-- Insertar datos de ejemplo en la tabla PAIS
INSERT INTO PAIS (ID, ISO, Descripcion) VALUES
(1, 'USA', 'Estados Unidos'),
(2, 'GBR', 'Reino Unido'),
(3, 'MEX', 'M�xico'),
(4, 'ESP', 'Espa�a'),
(5, 'CAN', 'Canad�');

-- Insertar datos de ejemplo en la tabla CLIENTE
INSERT INTO CLIENTE (Nombre, Apellidos, Identificacion, CorreoElectronico, PaisID) VALUES
('Juan', 'P�rez', '123456789', 'juan@example.com', 1),
('Mar�a', 'Garc�a', '987654321', 'maria@example.com', 3),
('David', 'Smith', '555555555', 'david@example.com', 1);

-- Crear la tabla TARJETA
CREATE TABLE TARJETA (
    ID INT PRIMARY KEY,
    Tipo VARCHAR(30)
);

-- Crear la tabla NFT
CREATE TABLE NFT (
    ID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
    Nombre VARCHAR(100),
    Autor VARCHAR(100),
    Valor DECIMAL(18, 2),
    CantidadInventario INT,
    Imagen VARBINARY(MAX) NOT NULL
);

-- Crear la tabla PROPIETARIO_NFT
CREATE TABLE PROPIETARIO_NFT (
    NFTID UNIQUEIDENTIFIER PRIMARY KEY,
    ClienteID UNIQUEIDENTIFIER,
    FechaAdquisicion DATE,
    FOREIGN KEY (NFTID) REFERENCES NFT(ID),
    FOREIGN KEY (ClienteID) REFERENCES CLIENTE(ID)
);

-- Crear la tabla Factura
CREATE TABLE Factura (
    FacturaID INT PRIMARY KEY,
    ClienteID UNIQUEIDENTIFIER,
    FechaFactura DATE,
    Total DECIMAL(18, 2),
    TarjetaID INT NOT NULL,
    EstadoFactura INT NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ID),
    FOREIGN KEY (TarjetaID) REFERENCES Tarjeta(ID)
);

-- Crear la secuencia NoFactura
CREATE SEQUENCE NoFactura START WITH 1;

-- Crear la tabla DetalleFactura
CREATE TABLE DetalleFactura (
    DetalleID INT PRIMARY KEY DEFAULT NEXT VALUE FOR NoFactura,
    FacturaID INT,
    NFTID UNIQUEIDENTIFIER,
    Cantidad INT,
    Precio DECIMAL(18, 2),
    TotalLinea DECIMAL(18, 2),
    EstadoFactura INT,
    FOREIGN KEY (FacturaID) REFERENCES Factura(FacturaID),
    FOREIGN KEY (NFTID) REFERENCES NFT(ID)    
);

-- Crear la tabla UsuarioRol
CREATE TABLE UsuarioRol (
    UsuarioID INT,
    RolID INT,
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(ID),
    FOREIGN KEY (RolID) REFERENCES Rol(ID),
    PRIMARY KEY (UsuarioID, RolID)
);
