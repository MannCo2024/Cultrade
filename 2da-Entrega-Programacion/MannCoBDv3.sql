DROP DATABASE BD;
CREATE DATABASE BD;
USE BD;
-- show engine innodb status;
-- XAMPP: myqsldump -u [usuario] -p [nombreBD].sql > [nombreDB].sql

-------------------------------------------------------------- CONTENIDO DE USUARIO 

/*CREATE TABLE Pais(
	pais varchar(14),
										# TABLA INNECESARIA
    PRIMARY KEY (pais)
);*/

CREATE TABLE Usuario(
	id_usuario varchar(32) unique,
    nombre varchar(32) not null,
    apellido varchar(32) not null,
    fechaNacimiento datetime,
    pais varchar(14) not null,
    pfp varchar(255),
    genero enum('M','F','O'),
    celular varchar(15),
    fechaIngreso datetime not null,
    estado enum('Online', 'Offline'),
    
    PRIMARY KEY (id_usuario)
);

CREATE TABLE Preferencias( -- De usuario
	id_preferencias varchar(32),
    preferencias varchar(25),
    
    PRIMARY KEY (id_preferencias),
    CONSTRAINT FK_id_preferencias FOREIGN KEY (id_preferencias) REFERENCES Usuario(id_usuario)
) ;

/*CREATE TABLE Muro(
	id_muro int AUTO_INCREMENT,
    duenio varchar(32) not null,       ||     NO ES NECESARIO POQUE SE CARGAN DIRECTAMENTE CON EL ID DEL DUEÑO
    
    PRIMARY KEY (id_muro),
	CON*/

CREATE TABLE AniadeAmigo( -- >>> Verificar su función correcta   |   EN TEORÍA ESTA ANDANDO
	id_usuario1 varchar(32) not null references Usuario(id_usuario),
    id_usuario2 varchar(32) not null references Usuario(id_usuario),
    fecha datetime not null
);

-------------------------------------------------------------- CONTENIDO MULTIMEDIA / OTROS

CREATE TABLE Post(
	id_post int auto_increment not null,
    modificado BOOLEAN,
    texto varchar(250),
    
    PRIMARY KEY (id_post)
);

CREATE TABLE Video(
	id_post int not null,
	id_video int ,
    datapath varchar(60),
    
    
    
    PRIMARY KEY (id_post),
    CONSTRAINT FOREIGN KEY (id_post) REFERENCES Post(id_post)
);

CREATE TABLE Imagen(
	id_post int not null,
	id_imagen int auto_increment,
    datapath varchar(60),
    
    PRIMARY KEY (id_imagen),
    CONSTRAINT FOREIGN KEY (id_post) REFERENCES Post(id_post)
);

/*CREATE TABLE Texto(				||				YA NO ES NECESARIO CON EL TEXTO CARGADO EN EL POST MISMO.
	id_texto int,
    
    PRIMARY KEY (id_texto),
    CONSTRAINT FK_id_texto_Post FOREIGN KEY (id_texto) REFERENCES Post(id_post)
);*/

-------------------------------------------------------------- INTERACCIONES / OTROS

CREATE TABLE Comenta(
	id_usuario varchar(32),
    id_post int, 
    fecha datetime not null,
    comentario varchar(500) not null,
    
    PRIMARY KEY (id_usuario, id_post, fecha),
    CONSTRAINT FK_id_usuario_Comenta FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_id_post_Comenta FOREIGN KEY (id_post) REFERENCES Post(id_post)
);

CREATE TABLE Comparte(
	id_usuario varchar(32),
    id_post int,
    
    PRIMARY KEY (id_usuario, id_post),
	CONSTRAINT FK_id_usuario_Comparte FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_id_post_Comparte FOREIGN KEY (id_post) REFERENCES Post(id_post)
);

CREATE TABLE Reacciona(
	id_usuario varchar(32) not null,
    id_post int not null,
    reaccion enum('corazon','comico','llorando','enamorado','preocupado','sorprendido','enojado') not null,
    -- REFERENCIAS: '❤','😆','😭','😍','😥','😱','😡'
    
    PRIMARY KEY (id_usuario, id_post),
	CONSTRAINT FK_id_usuario_Reacciona FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_id_post_Reacciona FOREIGN KEY (id_post) REFERENCES Post(id_post)
);

CREATE TABLE Publica(
	id_usuario varchar(32),
    id_post int,
    fechaCreacion datetime not null,
    
    PRIMARY KEY (id_usuario, id_post),
	CONSTRAINT FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FOREIGN KEY (id_post) REFERENCES Post(id_post)
);

/*CREATE TABLE Contiene(				||				TABLA INNECESARIA?
	id_usuario varchar(32),
    id_post int,
    -- atrib contenido?
    
    PRIMARY KEY (id_usuario, id_post),
	CONSTRAINT FK_id_usuario_Contiene FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_id_post_Contiene FOREIGN KEY (id_post) REFERENCES Post(id_post)
);*/

-------------------------------------------------------------- CONTENIDO RED / OTROS

CREATE TABLE Red(
	id_red int AUTO_INCREMENT,
    duenio varchar(32) not null,
	nombre varchar(32) not null,
    descripcion varchar(200),
    participantes int not null, -- lo mismo que el comentario de abajo.
    fechaCreacion datetime not null,
    fechaEntrada datetime not null, -- Fecha en la que un usuario ingresa. Habría que crear una tabla de usuario_ingresa con el id del usuario y la fecha
    
    PRIMARY KEY (id_red),
    CONSTRAINT FK_duenio_Red FOREIGN KEY (duenio) REFERENCES Usuario(id_usuario)
); 

CREATE TABLE Comunidad(
	id_red int,

	PRIMARY KEY (id_red),
	CONSTRAINT FK_id_red_Comunidad FOREIGN KEY (id_red) REFERENCES Red(id_red)
);

CREATE TABLE Grupo(
	id_red int,

	PRIMARY KEY (id_red),
	CONSTRAINT FK_id_red_Grupo FOREIGN KEY (id_red) REFERENCES Red(id_red)
);

CREATE TABLE Roles(
	id_usuario varchar(32),
    id_red int,
    rol enum('Usuario','Moderador','Dueño'),
    
    PRIMARY KEY (id_usuario, id_red),
    CONSTRAINT FK_id_usuario_Roles FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),	
    CONSTRAINT FK_id_red_Roles FOREIGN KEY (id_red) REFERENCES Red(id_red)
);

CREATE TABLE Evento(
	id_evento int AUTO_INCREMENT,
    id_red int,
    organizador varchar(32) not null,
	imagen varchar(255),
    descripcion varchar(200),
    tipo enum('Streaming','Presencial','Ambos') not null,
    fechaInicio datetime not null,
    FechaFin datetime not null,
    ubicacion varchar(25),
    quienPuedeCrearPost enum('Usuario','Moderador','Dueño'),

	PRIMARY KEY (id_evento, id_red),
	CONSTRAINT FK_id_red_Evento FOREIGN KEY (id_red) REFERENCES Red(id_red),
    CONSTRAINT FK_organizador FOREIGN KEY (organizador) REFERENCES Usuario(id_usuario)
);

-------------------------------------------------------------- MENSAJERÍA

CREATE TABLE MensajeRed(
	id_usuario varchar(32) not null,
    id_red int not null,
    fechaEnvio datetime,
    mensaje varchar(500),
    
    PRIMARY KEY (id_usuario, id_red),
    CONSTRAINT FK_id_usuario_MensajeRed FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_id_red_MensajeRed FOREIGN KEY (id_red) REFERENCES Red(id_red)
);

CREATE TABLE MensajeriaPrivada(
	id_usuario1 varchar(32) not null references Usuario(id_usuario),
    id_usuario2 varchar(32) not null references Usuario(id_usuario),
	fechaEnvio datetime,
    mensaje varchar(500)
);

-------------------------------------------------------------- POBLACIÓN
-- 21 TABLAS



INSERT INTO Usuario (id_usuario, nombre, apellido, fechaNacimiento, pais, pfp, genero, celular, fechaIngreso, estado) VALUES
('juanpe1', 'Juan', 'Pérez', '1990-05-15', 'Uruguay', 'juan.png', 'M', '099123456', '2024-08-15 00:00:00', 'Online'),
('anagom12', 'Ana', 'Gómez', '1985-08-20', 'Argentina', 'ana.png', 'F', '099654321', '2024-08-16 00:00:00', 'Offline'),
('carli5', 'Carlos', 'Rodríguez', '1992-03-22', 'Brasil', 'carlos.png', 'M', '099876543', '2024-08-17 00:00:00', 'Online'),
('marialopez123', 'María', 'Lopez', '2004-06-09','Bolivia','maria.png','F','094398152','2024-07-31 00:00:00','Offline');
/*
CREATE USER 'juanpe1' IDENTIFIED BY 'juanpe1';
#REVOKE ALL PRIVILEGES ON bd.* FROM 'juanpe1'; #TIRA ERROR PERO ANDA IGUAL, NO SE POR QUE REVOKE FROM ES ASÍ
GRANT SELECT ON bd.* TO 'juanpe1';

CREATE USER 'anagom12' IDENTIFIED BY 'anagomez';
#REVOKE ALL PRIVILEGES ON bd.* FROM 'anagom12'; #TIRA ERROR PERO ANDA IGUAL, NO SE POR QUE REVOKE FROM ES ASÍ
GRANT SELECT ON bd.* TO 'anagom12';

CREATE USER 'carli5' IDENTIFIED BY 'carlo123';
#REVOKE ALL PRIVILEGES ON bd.* FROM 'carli5'; #TIRA ERROR PERO ANDA IGUAL, NO SE POR QUE REVOKE FROM ES ASÍ
GRANT SELECT ON bd.* TO 'carli5';

CREATE USER 'marialopez123' IDENTIFIED BY 'marilo99';
#REVOKE ALL PRIVILEGES ON bd.* FROM 'marialopez123'; #TIRA ERROR PERO ANDA IGUAL, NO SE POR QUE REVOKE FROM ES ASÍ
GRANT SELECT ON bd.* TO 'marialopez123';

CREATE USER 'UserCheck' IDENTIFIED BY 'Xk9rr!23=!0A';
#REVOKE ALL PRIVILEGES ON md.* FROM 'UserCheck';
GRANT SELECT ON bd.Usuario TO 'UserCheck';
*/
#CREATE USER 'PostLoader' IDENTIFIED BY 'Xkjjk)923=!1f';
#REVOKE ALL PRIVILEGES ON md.* FROM 'PostLoader';
GRANT SELECT ON bd.Usuario TO 'PostLoader';
GRANT SELECT ON bd.Post TO 'PostLoader';
GRANT SELECT ON bd.Comenta TO 'PostLoader';
GRANT SELECT ON bd.Publica TO 'PostLoader';
GRANT SELECT ON bd.Video TO 'PostLoader';
GRANT SELECT ON bd.Imagen TO 'PostLoader';
GRANT SELECT ON bd.Reacciona TO 'PostLoader';

#CREATE USER 'PostMaker' IDENTIFIED BY 'Xkjjk)923=!1f';
#REVOKE ALL PRIVILEGES ON md.* FROM 'PostLoader';
GRANT INSERT ON bd.Post TO 'PostMaker';
GRANT SELECT ON bd.Post TO 'PostMaker';
GRANT INSERT ON bd.Comenta TO 'PostMaker';
GRANT INSERT ON bd.Publica TO 'PostMaker';
GRANT INSERT ON bd.Video TO 'PostMaker';
GRANT INSERT ON bd.Imagen TO 'PostMaker';
GRANT SELECT ON bd.Reacciona TO 'PostMaker';

#select user();


-- Insertar datos en la tabla Preferencias
INSERT INTO Preferencias (id_preferencias, preferencias) VALUES
('juanpe1', 'Deportes, Música'),
('anagom12', 'Lectura, Viajes'),
('carli5', 'Cine, Tecnología'),
('marialopez123', 'Series, Juegos');

-- Insertar datos en la tabla AniadeAmigo
INSERT INTO AniadeAmigo (id_usuario1, id_usuario2, fecha) VALUES
('juanpe1', 'anagom12', '2024-08-16 00:00:00'),
('anagom12', 'carli5', '2024-08-17 00:00:00'),
('carli5', 'marialopez123', '2024-08-18 00:00:00');

-- Insertar datos en la tabla Post
INSERT INTO Post (id_post, modificado, texto) VALUES
(1, TRUE, '¡Este es un post de prueba!'),
(2, FALSE, 'Otro post para probar el sistema.'),
(3, TRUE, 'Probando post con más contenido.'),
(4, FALSE, 'Post final de ejemplo.');
/*
-- Insertar datos en la tabla Video
INSERT INTO Video (id_post, id_video) VALUES
(1, 101),
(2, 102),
(3, 103),
(4, 104);
*/
-- Insertar datos en la tabla Imagen
INSERT INTO Imagen (id_post, datapath) VALUES
(1, 'img_68543.png'),
(2, 'img_70254.jpeg'),
(3, 'img_63373.png'),
(4, 'img_85489.png');

-- Insertar datos en la tabla Comenta
INSERT INTO Comenta (id_usuario, id_post, fecha, comentario) VALUES
('juanpe1', 1, '2024-08-16', '¡Qué interesante!'),
('anagom12', 2, '2024-08-17', 'Me encanta este post.'),
('carli5', 3, '2024-08-18', 'Muy buen contenido.'),
('marialopez123', 4, '2024-08-19', 'Gran post, gracias por compartir.');
/*
-- Insertar datos en la tabla Comparte
INSERT INTO Comparte (id_usuario, id_post) VALUES
('juanpe1', 1),
('anagom12', 2),
('carli5', 3),
('marialopez123', 4);
*/
-- Insertar datos en la tabla Reacciona
INSERT INTO Reacciona (id_usuario, id_post, reaccion) VALUES
('juanpe1', 1, 'corazon'),
('anagom12', 1, 'corazon');

-- Insertar datos en la tabla Publica
INSERT INTO Publica (id_usuario, id_post, fechaCreacion) VALUES
('juanpe1', 1, '2024-08-15'),
('anagom12', 2, '2024-08-16'),
('carli5', 3, '2024-08-17'),
('marialopez123', 4, '2024-08-18');

-- Insertar datos en la tabla Red
INSERT INTO Red (duenio, nombre, descripcion, participantes, fechaCreacion, fechaEntrada) VALUES
('juanpe1', 'Red Social A', 'Descripción de la Red A', 10, '2024-08-15 00:00:00', '2024-08-15 00:00:00'),
('anagom12', 'Red Social B', 'Descripción de la Red B', 20, '2024-08-16 00:00:00', '2024-08-16 00:00:00');

-- Insertar datos en la tabla Comunidad
INSERT INTO Comunidad (id_red) VALUES
(1),
(2);

-- Insertar datos en la tabla Grupo
INSERT INTO Grupo (id_red) VALUES
(1),
(2);

-- Insertar datos en la tabla Roles
INSERT INTO Roles (id_usuario, id_red, rol) VALUES
('juanpe1', 1, 'Dueño'),
('anagom12', 2, 'Moderador'),
('carli5', 1, 'Usuario'),
('marialopez123', 2, 'Usuario');

-- Insertar datos en la tabla Evento
INSERT INTO Evento (id_evento, id_red, organizador, imagen, descripcion, tipo, fechaInicio, FechaFin, ubicacion, quienPuedeCrearPost) VALUES
(1, 1, 'juanpe1', 'evento1.png', 'Evento de prueba 1', 'Presencial', '2024-09-01 00:00:00', '2024-09-02 00:00:00', 'Montevideo', 'Moderador'),
(2, 2, 'anagom12', 'evento2.png', 'Evento de prueba 2', 'Streaming', '2024-09-03 00:00:00', '2024-09-04 00:00:00', 'Buenos Aires', 'Usuario');

-- Insertar datos en la tabla MensajeRed
INSERT INTO MensajeRed (id_usuario, id_red, fechaEnvio, mensaje) VALUES
('juanpe1', 1, '2024-08-15 00:00:00', 'Hola a todos en la Red Social A!'),
('anagom12', 2, '2024-08-16 00:00:00', 'Bienvenidos a la Red Social B.');

-- Insertar datos en la tabla MensajeriaPrivada
INSERT INTO MensajeriaPrivada (id_usuario1, id_usuario2, fechaEnvio, mensaje) VALUES
('juanpe1', 'anagom12', '2024-08-16 00:00:00', '¡Hola Ana! ¿Cómo estás?'),
('carli5', 'marialopez123', '2024-08-17 00:00:00', 'Hola María, ¿qué tal?');


-------------------------------------------------------------- CONSULTAS

-- Ver los mensajes de un usuario
-- ¨¨ los post de un usuario
-- ¨¨ los eventos de una comunidad
-- ¨¨ las redes que creó un usuario
-- ¨¨ el rol que tiene un usuario en una comunidad


			# Ver mensajes que un usuario envio
select id_usuario1 as 'Origen', id_usuario2 as 'Destinatario', mensaje as 'Mensaje', fechaEnvio  as 'Fecha de Envio'
from MensajeriaPrivada
where id_usuario1 = 'juanpe1';

			# Ver los posts de un usuario
select pub.id_usuario as 'Usuario', p.id_post as 'Post', p.texto as 'Texto', i.datapath as 'Imagen', v.id_video as 'Video', p.modificado as 'Modificado'
from Post p
join Publica pub ON p.id_post = pub.id_post
left join Video v ON p.id_post = v.id_post
left join Imagen i ON p.id_post = i.id_post
where pub.id_usuario is not null
order by pub.fechaCreacion;
			# Ver los eventos de una comunidad
select e.id_evento as Evento, c.id_red as Comunidad, e.imagen, e.descripcion, e.tipo, e.organizador, e.ubicacion, e.fechaInicio as Inicio, e.fechaFin as Fin
from evento e
join Comunidad c on e.id_red = c.id_red
left join Red r on c.id_red = r.id_red
where c.id_red = '1';

			# Redes que creo un usuario
select r.id_red as Red, u.id_usuario as Dueño, r.nombre as Nombre, r.fechaCreacion as 'Fecha de Creacion'
from Red r join Usuario u on r.duenio = u.id_usuario
where u.id_usuario = 'juanpe1';

			# Rol de un usuario en una comunidad
select u.id_usuario as Usuario, rl.id_red as Red, r.nombre as Nombre
from Comunidad c join Red r on c.id_red = r.id_red
left join Roles rl on c.id_red = rl.id_red
left join Usuario u on rl.id_usuario = u.id_usuario
where c.id_red = '1' and u.id_usuario = 'juanpe1' ;

SELECT COUNT(*) as Likes 
FROM Reacciona 
WHERE id_post = '1' AND reaccion = 'corazon';

select *
from Reacciona
where id_post = '1' AND id_usuario = 'juanpe1';

show engine innodb status;