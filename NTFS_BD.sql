CREATE DATABASE BD_NFT;


ALTER AUTHORIZATION ON DATABASE::ElectronicsNetcore TO sa;
-- Usar la base de datos



USE BD_NFT;



CREATE TABLE PAIS (
    ID INT PRIMARY KEY,
    ISO CHAR(3) UNIQUE,
    Descripcion VARCHAR(100)
);



CREATE TABLE CLIENTE (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
	Identificacion varchar (50),
    CorreoElectronico VARCHAR(100),
    PaisID INT,
    FOREIGN KEY (PaisID) REFERENCES Pais(ID)
);

-- Insertar datos de ejemplo en la tabla PAIS
INSERT INTO PAIS (ID, ISO, Descripcion) VALUES
(1, 'USA', 'Estados Unidos'),
(2, 'GBR', 'Reino Unido'),
(3, 'MEX', 'México'),
(4, 'ESP', 'España'),
(5, 'CAN', 'Canadá');

-- Insertar datos de ejemplo en la tabla CLIENTE
INSERT INTO CLIENTE (Nombre, Apellidos, Identificacion, CorreoElectronico, PaisID) VALUES
('Juan', 'Pérez', '123456789', 'juan@example.com', 1), -- Cliente en Estados Unidos (ID 1)
('María', 'García', '987654321', 'maria@example.com', 3), -- Cliente en México (ID 3)
('David', 'Smith', '555555555', 'david@example.com', 1); -- Otro cliente en Estados Unidos (ID 1)





CREATE TABLE TARJETA (
    ID INT PRIMARY KEY,
    Tipo VARCHAR(30)
);



CREATE TABLE NFT (
    ID uniqueIdentifier not null default NEWSEQUENTIALID() PRIMARY KEY,
    Nombre VARCHAR(100),
    Autor VARCHAR(100),
    Valor DECIMAL(18, 2),
    CantidadInventario INT,
	Imagen Varbinary(Max) not null,
);



CREATE TABLE PROPIETARIO_NFT (
    NFTID uniqueidentifier PRIMARY KEY,
    ClienteID uniqueidentifier,
    FechaAdquisicion DATE,
    FOREIGN KEY (NFTID) REFERENCES NFT(ID),
    FOREIGN KEY (ClienteID) REFERENCES CLIENTE(ID)
);




CREATE TABLE Factura (
    FacturaID INT PRIMARY KEY,
    ClienteID uniqueidentifier,
    FechaFactura DATE,
    Total DECIMAL(18, 2),
	TarjetaID INT NOT NULL,
	EstadoFactura INT NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ID),
	FOREIGN KEY (TarjetaID) REFERENCES Tarjeta(ID)
);

CREATE TABLE DetalleFactura (
    DetalleID INT PRIMARY KEY DEFAULT NEXT VALUE FOR dbo.NoFactura,
    FacturaID INT,
    NFTID uniqueidentifier,
    Cantidad INT,
    Precio DECIMAL(18, 2),
    TotalLinea DECIMAL(18, 2),
	EstadoFactura INT,
    FOREIGN KEY (FacturaID) REFERENCES Factura(FacturaID),
    FOREIGN KEY (NFTID) REFERENCES NFT(ID),	
);


CREATE TABLE Usuario (
  ID INT PRIMARY KEY,
  NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
  CorreoElectronico VARCHAR(100) UNIQUE NOT NULL,
  Contrasena VARCHAR(255) NOT NULL,
  RolID INT,
  FOREIGN KEY (RolID) REFERENCES Rol(ID)
);

CREATE TABLE Rol (
  ID INT PRIMARY KEY,
  NombreRol VARCHAR(50) UNIQUE NOT NULL,
  Descripcion VARCHAR(100)
);

INSERT INTO Rol (ID, NombreRol, Descripcion) VALUES
(1,'Administrador', 'Acceso completo al sistema'),
(2,'Ventas', 'Acceso a realizar Ventas'),
(3,'Reporteria', 'Acceso a realizar Reportes');

CREATE TABLE UsuarioRol (
  UsuarioID INT,
  RolID INT,
  FOREIGN KEY (UsuarioID) REFERENCES Usuario(ID),
  FOREIGN KEY (RolID) REFERENCES Rol(ID),
  PRIMARY KEY (UsuarioID, RolID)
);