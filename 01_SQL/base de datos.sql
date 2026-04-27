
-- 1. Crear la base de datos
CREATE DATABASE Libreria1;     ------ 1
GO

-- 2. Usar la base de datos recién creada
USE Libreria1;                 ------   2
GO

-- 3. Crear la tabla CATEGORIA
CREATE TABLE CATEGORIA (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,  -------3
    Descripcion VARCHAR(100) NOT NULL
);
GO

-- 4. Crear la tabla AUTOR
CREATE TABLE AUTOR (
    IdAutor INT IDENTITY(1,1) PRIMARY KEY, --------4
    Nombre VARCHAR(100) NOT NULL,
    Nacionalidad VARCHAR(50)
);
GO

-- 5. Insertar 4 registros en CATEGORIA 
INSERT INTO CATEGORIA (Descripcion) VALUES ('Cuento Costumbrista');
INSERT INTO CATEGORIA (Descripcion) VALUES ('Poesía Salvadoreña'); ------------ 5
INSERT INTO CATEGORIA (Descripcion) VALUES ('Novela Testimonial');
INSERT INTO CATEGORIA (Descripcion) VALUES ('Ensayo y Crítica');
GO

-- 6. Insertar 4 registros en AUTOR (Autores Salvadoreños) 
INSERT INTO AUTOR (Nombre, Nacionalidad) VALUES ('Salarrué (Salvador Salazar Arrué)', 'Salvadoreña');
INSERT INTO AUTOR (Nombre, Nacionalidad) VALUES ('Claudia Lars', 'Salvadoreña');
INSERT INTO AUTOR (Nombre, Nacionalidad) VALUES ('Roque Dalton', 'Salvadoreña');            ---------- 6
INSERT INTO AUTOR (Nombre, Nacionalidad) VALUES ('Francisco Gavidia', 'Salvadoreña');
GO

SELECT*FROM AUTOR;                         
SELECT*FROM CATEGORIA;
