-- Crear Base de Datos
CREATE DATABASE IF NOT EXISTS webAppClima;
USE webAppClima;

-- Crear Tabla de Catalogo de Roles
CREATE TABLE catRoles (
    rol_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_rol VARCHAR(8) NOT NULL
);

-- Insertar Datos en Tabla catRoles
INSERT INTO catRoles (nombre_rol) VALUES ('admin'), ('user');

-- Crear Tabla de Catalogo de Actividades
CREATE TABLE catActividades (
    actividad_id INT AUTO_INCREMENT PRIMARY KEY,
    descripcion VARCHAR(8) NOT NULL
);

-- Insertar Datos en Tabla catActividades
INSERT INTO catActividades (descripcion) VALUES ('log in'), ('log out');

-- Crear Tabla de Usuarios
CREATE TABLE tblUsuarios (
    usuario_id INT AUTO_INCREMENT PRIMARY KEY,
    user VARCHAR(8) NOT NULL,
    passwd VARCHAR(12) NOT NULL,
    rol_id INT,
    FOREIGN KEY (rol_id) REFERENCES catRoles(rol_id)
);

-- Crear Tabla de Lecturas Climaticas
CREATE TABLE tblLecturas (
    lectura_id INT AUTO_INCREMENT PRIMARY KEY,
    fecha_hora DATETIME NOT NULL,
    temperatura FLOAT,
    presion FLOAT,
    altitud FLOAT
);

-- Crear Tabla de Logs de Actividades
CREATE TABLE tblLogs (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    usuario_id INT,
    actividad_id INT,
    fecha_hora DATETIME NOT NULL,
    FOREIGN KEY (usuario_id) REFERENCES tblUsuarios(usuario_id),
    FOREIGN KEY (actividad_id) REFERENCES catActividades(actividad_id)
);


-- Insertar Datos en Tabla tblUsuarios
INSERT INTO tblUsuarios (user, passwd, rol_id) VALUES 
('admin', 'admin123', 1), 
('user1', 'user1234', 2), 
('user2', 'user1234', 2), 
('user3', 'user1234', 2);