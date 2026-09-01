
CREATE DATABASE TiendaCocinaDB;
GO

USE TiendaCocinaDB;
GO


CREATE TABLE Categoria (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    Estado BIT NOT NULL DEFAULT 1 -- 1: Activo, 0: Inactivo
);


CREATE TABLE Producto (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Estado BIT NOT NULL DEFAULT 1,
    IdCategoria INT NOT NULL,
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoria) 
        REFERENCES Categoria(IdCategoria)
);


INSERT INTO Categoria (Nombre, Descripcion, Estado) VALUES
('Electrodomésticos', 'Equipos eléctricos para la cocina', 1),
('Sartenes y Ollas', 'Baterías de cocina y utensilios para cocción', 1),
('Utensilios', 'Herramientas de preparación y corte', 1);

INSERT INTO Producto (Nombre, Descripcion, Precio, Stock, Estado, IdCategoria) VALUES
('Licuadora Industrial 1.5L', 'Licuadora de alta potencia con vaso de vidrio', 89.99, 15, 1, 1),
('Freidora de Aire 4.5L', 'Freidora sin aceite con pantalla digital', 110.50, 8, 1, 1),
('Sartén Antiadherente 28cm', 'Sartén de aluminio forjado antiadherente', 25.00, 30, 1, 2),
('Olla de Presión 6L', 'Olla de acero inoxidable de rápida cocción', 55.00, 12, 1, 2),
('Juego de Cuchillos (6 piezas)', 'Cuchillos de acero inoxidable con soporte de madera', 34.90, 20, 1, 3);