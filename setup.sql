-- Crear la base de datos
CREATE DATABASE taskmanagerdb;
GO
-- Crear el login
CREATE LOGIN anthotamayo WITH PASSWORD = 'Pass123456789_';
GO
-- Usar la base de datos
USE taskmanagerdb;
GO
-- Crear el usuario y asignar el login
CREATE USER anthotamayo FOR LOGIN anthotamayo;
GO
-- Asignar permisos al usuario
ALTER ROLE db_owner ADD MEMBER anthotamayo;
GO
SELECT name FROM sys.databases;
GO
SELECT name FROM sys.sql_logins;
GO
SELECT name FROM sys.database_principals;
GO
