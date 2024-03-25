CREATE DATABASE BD_NTF;


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




CREATE TABLE VentaNFT (
    VentaID INT PRIMARY KEY,
    NFTID uniqueidentifier,
    ClienteID uniqueidentifier,
    TarjetaID INT,
    FechaVenta DATE,
    Estado VARCHAR(20),
    FOREIGN KEY (NFTID) REFERENCES NFT(ID),
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ID),
    FOREIGN KEY (TarjetaID) REFERENCES Tarjeta(ID)
);
