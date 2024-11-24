create database bdd;
use bdd;

CREATE TABLE Usuario(
	id_usuario varchar(32) unique,
    nombre varchar(32) not null,
    apellido varchar(32) not null,
    fechaNacimiento date,
	mail varchar(64) unique,
    pais varchar(14) not null,
    pfp varchar(255),
    genero enum('H','M','O'),
    celular varchar(15) unique,
    fechaIngreso datetime not null,
    estado enum('Online', 'Offline'),
	descripcion varchar(190),
    
    PRIMARY KEY (id_usuario, celular, mail)
);

CREATE TABLE Preferencias( -- De usuario
	id_usuario varchar(32),
    preferencias varchar(25),
    
    PRIMARY KEY (id_preferencias, preferencias),
    CONSTRAINT FK_id_preferencias FOREIGN KEY (id_preferencias) REFERENCES Usuario(id_usuario)
);

CREATE TABLE BackOffice (
	id int AUTO_INCREMENT not null,
	nombre varchar(16) unique,
	
	primary key (id)
);

CREATE TABLE Solicitud(
	id int auto_increment not null,
    estado enum('Rechazado', 'Pendiente', 'Aceptado'),
	fechaCreacion datetime not null,
    fechaCompletado datetime,
	
	primary key (id)
);

CREATE TABLE Registros(
	solicitud int not null references Solicitud(id),
	id_usuario varchar(32) unique,
    nombre varchar(32) not null,
    apellido varchar(32) not null,
    fechaNacimiento date,
	mail varchar (64) unique not null,
    pais varchar(14) not null,
    genero enum('H','M','O'),
    celular varchar(15) unique,
	pass varchar(25) not null,
    
    PRIMARY KEY (id_usuario, celular, mail),
	constraint foreign key (solicitud) references Solicitud(id)
);

CREATE TABLE AniadeAmigo(
	id_usuario1 varchar(32) references Usuario(id_usuario),
    id_usuario2 varchar(32) references Usuario(id_usuario),
    fecha datetime not null,
    
    primary key (id_usuario1, id_usuario2)
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

-------------------------------------------------------------- INTERACCIONES / OTROS

CREATE TABLE Comenta(
	id_usuario varchar(32),
    id_post int, 
    fecha datetime not null,
    comentario varchar(500) not null,
    
    PRIMARY KEY (id_usuario, id_post, fecha),
    CONSTRAINT FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FOREIGN KEY (id_post) REFERENCES Post(id_post)
);

CREATE TABLE Comparte(
	id_usuario varchar(32),
    id_post int,
    fecha datetime,
    
    PRIMARY KEY (id_usuario, id_post),
	CONSTRAINT FK_id_usuario_Comparte FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_id_post_Comparte FOREIGN KEY (id_post) REFERENCES Post(id_post)
);
CREATE TABLE Guarda(
	id_usuario varchar(32),
    id_post int,
    fecha datetime,
    
    PRIMARY KEY (id_usuario, id_post),
	CONSTRAINT FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FOREIGN KEY (id_post) REFERENCES Post(id_post)
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

-------------------------------------------------------------- CONTENIDO RED / OTROS

CREATE TABLE Red(
	id_red int AUTO_INCREMENT,
    fechaCreacion datetime not null,
	nombre varchar(32) not null,
    descripcion varchar(200),
    
    PRIMARY KEY (id_red)
); 

CREATE TABLE CreaRed(
	id_red int references Red(id_red),
    id_usuario varchar(32) references Usuario(id_usuario),
    
    primary key (id_red, id_usuario)
);

CREATE TABLE UsuarioIngresa(
	red int not null,
	usuario varchar(32) not null,
	fecha datetime not null,
	
	primary key (red, usuario, fecha),
	constraint foreign key (red) references Red(id_red),
	constraint foreign key (usuario) references Usuario(id_usuario)
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

CREATE TABLE MensajeRed ( 
    id_usuario varchar(32) not null, 
    id_red int not null, 
    fechaEnvio datetime, 
    mensaje varchar(300), 
    
    PRIMARY KEY (id_usuario, id_red, fechaEnvio), 
    CONSTRAINT FK_id_usuario_MensajeRed FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario), 
    CONSTRAINT FK_id_red_MensajeRed FOREIGN KEY (id_red) REFERENCES Red(id_red) 
);


CREATE TABLE MensajeriaPrivada(
	id_usuario1 varchar(32) references Usuario(id_usuario),
    id_usuario2 varchar(32) references Usuario(id_usuario),
	fechaEnvio datetime,
    mensaje varchar(300)
);

-------------------------------------------------------------- VIEWS Y TRANSACCIONES


				-- view verposts
CREATE VIEW verposts AS
SELECT 
    pub.id_usuario AS Usuario, 
    p.id_post AS Post, 
    p.texto AS Texto, 
    i.datapath AS Imagen, 
    p.modificado AS Modificado 
FROM 
    Post p 
JOIN 
    Publica pub ON p.id_post = pub.id_post 
LEFT JOIN 
    Imagen i ON p.id_post = i.id_post;

				-- Crear vista vercomentarios
CREATE VIEW vercomentarios AS
SELECT u.id_usuario AS Usuario, c.id_post AS Post, c.comentario AS Comentario 
FROM Comenta c JOIN Usuario u ON c.id_usuario = u.id_usuario;

				-- Crear vista likes para contar reacciones
CREATE VIEW likes AS 
SELECT id_post as Post, id_usuario as Usuario
FROM Reacciona
GROUP BY id_post, id_usuario;

				-- view verSolicitudes
CREATE VIEW verSolicitudes AS
SELECT 
	s.id AS ID,
	s.fechaCreacion AS 'Fecha Creacion',
	s.estado AS Estado,
	s.fechaCompletado AS 'fecha Completado',
	r.id_usuario AS Usuario,
	r.nombre AS Nombre,
	r.apellido AS Apellido,
	r.fechaNacimiento AS 'Fecha Nacimiento',
	r.genero AS Genero,
	r.mail AS Correo,
	r.pais AS Pais,
	r.celular AS Telefono,
	r.pass AS 'pass'
FROM 
	Solicitud s 
JOIN
	Registros r ON r.solicitud = s.id;
	
				-- Crear view verUsu
CREATE VIEW verUsu AS 
SELECT 
    id_usuario AS Usuario, 
    nombre AS Nombre, 
    apellido AS Apellido, 
    TIMESTAMPDIFF(YEAR, fechaNacimiento, CURDATE()) AS Edad, 
    mail AS Mail, 
    descripcion AS Dcr 
FROM Usuario;

	
				-- Crear view verBO
CREATE VIEW verBO AS
SELECT
	id AS ID,
	nombre AS Usuario
FROM
	BackOffice;
    
				-- View verMensajes
CREATE VIEW verMensajes AS
select 
	id_usuario1 as 'Origen',
	id_usuario2 as 'Destinatario',
	mensaje as 'Mensaje',
	fechaEnvio as 'Fecha de Envio'
from
	MensajeriaPrivada;
    
				-- view verEventos
CREATE VIEW verEventos AS
select
	e.id_evento as Evento,
	c.id_red as Comunidad,
	e.imagen, e.descripcion,
	e.tipo, e.organizador,
	e.ubicacion,
	e.fechaInicio as Inicio,
	e.fechaFin as Fin
from 
	evento e
join 
	Comunidad c on e.id_red = c.id_red
left join 
	Red r on c.id_red = r.id_red;
    
				-- View redes
CREATE VIEW redes AS 
select 
	r.id_red as Red, 
    u.id_usuario as Duenio, 
    r.nombre as Nombre, 
    r.fechaCreacion as 'Fecha de Creacion' 
from 
	Red r 
join 
	CreaRed cr on cr.id_red = r.id_red 
left join 
	Usuario u on u.id_usuario = cr.id_usuario;
    
				-- View rolRed 
CREATE VIEW rolRed AS
select 
	u.id_usuario as Usuario, 
	rl.id_red as Red, 
    r.nombre as Nombre
from 
	Comunidad c 
join 
	Red r on c.id_red = r.id_red
left join 
	Roles rl on c.id_red = rl.id_red
left join 
	Usuario u on rl.id_usuario = u.id_usuario;
    
				-- View verGuardados
CREATE VIEW verGuardados AS
SELECT g.id_usuario as GUsuario , vp.*
FROM
	verposts vp
JOIN
	Guarda g on vp.Post = g.id_post;
    
				-- View verAmigos
CREATE VIEW verAmigos AS 
SELECT 
	id_usuario1 AS Usuario,
    id_usuario2 AS Amigo
FROM
	AniadeAmigo;
	
	
    
-------------------------------------------------------------------------------------------------------------------

				-- Crear función NombreUsuario
DELIMITER //
CREATE FUNCTION NombreUsuario() RETURNS VARCHAR(80)
DETERMINISTIC
BEGIN
    RETURN SUBSTRING_INDEX(USER(), '@', 1);
END //
DELIMITER ;

				-- Procedimiento creaPost
DELIMITER //
CREATE PROCEDURE creaPost(
    IN Texto VARCHAR(250) ,
    IN Imagen VARCHAR(60) 
)
BEGIN
    DECLARE IdPost INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
	
    INSERT INTO Post(modificado, texto) VALUES(FALSE, Texto);
    SET IdPost = LAST_INSERT_ID();
    INSERT INTO Imagen(id_post, datapath) VALUES(IdPost, Imagen);
    INSERT INTO Publica(id_usuario, id_post, fechaCreacion) VALUES(NombreUsuario(), IdPost, NOW());

    COMMIT;
END //
DELIMITER ;

				-- Procedimiento pubCom
DELIMITER //
CREATE PROCEDURE pubCom(
    IN IdPost INT,
    IN Texto VARCHAR(500)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
	
    START TRANSACTION;
	
    INSERT INTO Comenta(id_usuario, id_post, fecha, comentario) VALUES (NombreUsuario(), IdPost, NOW(), Texto);
	
    COMMIT;
END //
DELIMITER ;

				-- Procedimiento darLike
DELIMITER //
CREATE PROCEDURE darLike(
    IN IdPost INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
	
    START TRANSACTION;
	
    INSERT INTO Reacciona(id_usuario, id_post, reaccion) VALUES (NombreUsuario(), IdPost, 'corazon');
	
    COMMIT;
END //
DELIMITER ;

				-- Procedimiento quitarLike
DELIMITER //
CREATE PROCEDURE quitarLike(
    IN IdPost INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		
        ROLLBACK;
    END;
	
    START TRANSACTION;
	
    DELETE FROM Reacciona WHERE id_usuario = NombreUsuario() AND id_post = IdPost; 
	
    COMMIT;
END //
DELIMITER ;

				-- Crear función solicitudUsuario
DELIMITER //
CREATE PROCEDURE solicitudUsuario(
    IN p_id_usuario VARCHAR(32),
    IN p_nombre VARCHAR(32),
    IN p_apellido VARCHAR(32),
    IN p_fechaNacimiento DATETIME,
    IN p_mail VARCHAR(64),
    IN p_pais VARCHAR(14),
    IN p_genero ENUM('H','M','O'),
    IN p_celular VARCHAR(15),
	IN p_pass VARCHAR(25)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;
	
    START TRANSACTION;
    INSERT INTO Solicitud (estado, fechaCreacion)
    VALUES ('Pendiente', NOW());

    SET @v_solicitud_id = LAST_INSERT_ID();
	
    INSERT INTO Registros (solicitud, id_usuario, nombre, apellido, fechaNacimiento, mail, pais, genero, celular, pass)
    VALUES (@v_solicitud_id, p_id_usuario, p_nombre, p_apellido, p_fechaNacimiento, p_mail, p_pais, LEFT(p_genero, 1), p_celular, p_pass);
	
    COMMIT;

END //
DELIMITER ;

				-- Crear procedimiento aceptarSolicitudReg    (POR QUE TENÍA QUE SER TAN TOSCO HACER ESTA 😭😭)

DELIMITER //
CREATE PROCEDURE aceptarSolicitudReg(
    IN solicitudID INT
)
BEGIN
    DECLARE userName VARCHAR(32);
    DECLARE userPass VARCHAR(25);
    DECLARE sqlQuery VARCHAR(100);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;


    INSERT INTO Usuario (id_usuario, nombre, apellido, fechaNacimiento, mail, pais, genero, celular, fechaIngreso, estado)
    SELECT id_usuario, nombre, apellido, fechaNacimiento, mail, pais, genero, celular, NOW(), 'Offline'
    FROM Registros
    WHERE solicitud = solicitudID;


    UPDATE Solicitud
    SET estado = 'Aceptado', fechaCompletado = NOW()
    WHERE id = solicitudID;
	


    SELECT id_usuario, pass INTO userName, userPass
    FROM Registros
    WHERE solicitud = solicitudID;

--
    SET sqlQuery = CONCAT('CREATE USER "', userName, '"@"%" IDENTIFIED BY "', userPass, '"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.verposts TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.vercomentarios TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.likes TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.verUsu TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.verMensajes TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.verEventos TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.redes TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.rolRed TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.verGuardados TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

--
    SET sqlQuery = CONCAT('GRANT SELECT ON bdd.verAmigos TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

--
    SET sqlQuery = CONCAT('GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.creaPost TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.pubCom TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.darLike TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
--
    SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO "', userName, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.guardarPost TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.quitarGuardarPost TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.compartirPost TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.quitarCompartirPost TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.agregarAmigo TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeP TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeR TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
    
    COMMIT;  ----- No olvidarse de agregar los permisos de tablas a medida que se crean mas
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE rechazarSolicitudReg(
    IN solicitudID INT
)
BEGIN

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    UPDATE Solicitud
    SET estado = 'Rechazado', fechaCompletado = NOW()
    WHERE id = solicitudID;

    COMMIT;
END //
DELIMITER ;

				-- Procedimiento crearUsuBO
DELIMITER //
CREATE PROCEDURE crearUsuBO(
	IN x_nombre VARCHAR(16),
	in x_pass VARCHAR(25)
)
BEGIN
	DECLARE sqlQuery VARCHAR(100);

	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
	END;
	
	START TRANSACTION;
	
	INSERT INTO BackOffice(nombre) VALUES(x_nombre);

	SET sqlQuery = CONCAT('CREATE USER "', x_nombre, '"@"%" IDENTIFIED BY "', x_pass, '"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT SELECT ON bdd.verSolicitudes TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.aceptarSolicitudReg TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON PROCEDURE bdd.rechazarSolicitudReg TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
	
	SET sqlQuery = CONCAT('GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO "', x_nombre, '"@"%"');
    PREPARE stmt FROM sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
														
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE guardarPost(
	IN g_IdPost INT
)
BEGIN
	DECLARE	EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
    INSERT INTO Guarda(id_usuario, id_post, fecha) 
    VALUES (NombreUsuario(), g_IdPost, NOW());
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE compartirPost(
	IN c_IdPost INT
)
BEGIN
	DECLARE	EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
    INSERT INTO Comparte(id_usuario, id_post, fecha) 
    VALUES (NombreUsuario(), g_IdPost, NOW());
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE quitarGuardarPost(
	IN g_IdPost INT
)
BEGIN
	DECLARE	EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
    DELETE FROM Guarda 
    WHERE id_usuario = NombreUsuario() 
    AND id_post = g_IdPost;
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE quitarCompartirPost(
	IN c_IdPost INT
)
BEGIN
	DECLARE	EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
    DELETE FROM Comparte
    WHERE id_usuario = NombreUsuario() 
    AND id_post = c_IdPost;
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE agregarAmigo(
	IN a_usuario2 VARCHAR(32)
)
BEGIN
	DECLARE	EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
    INSERT INTO AniadeAmigo(id_usuario1, id_usuario2, fecha)
    VALUES (NombreUsuario(), a_usuario2, NOW());
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE enviarMensajeP(
	IN m_usuario2 VARCHAR(32),
    IN m_mensaje VARCHAR(300)
)
BEGIN
	DECLARE	EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
    INSERT INTO MensajeriaPrivada(id_usuario1, id_usuario2, fecha, mensaje)
    VALUES (NombreUsuario(), a_usuario2, NOW(), m_mensaje);
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE enviarMensajeR(
	IN m_usuario2 VARCHAR(32),
    IN m_mensaje VARCHAR(300)
)
BEGIN
	DECLARE	EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
	END;
    
    START TRANSACTION;
    
    INSERT INTO MensajeriaPrivada(id_usuario1, id_usuario2, fecha, mensaje)
    VALUES (NombreUsuario(), a_usuario2, NOW(), m_mensaje);
    
    COMMIT;
END //
DELIMITER ;

#------------------------------------------------------------------------USUARIOS
CREATE USER 'juanpe1' IDENTIFIED BY 'juanpe1';
CREATE USER 'anagom12' IDENTIFIED BY 'anagomez';
CREATE USER 'carli5' IDENTIFIED BY 'carlo123';
CREATE USER 'marialopez123' IDENTIFIED BY 'marilo99';

CREATE USER 'UserCheck'@ IDENTIFIED BY 'Xk9rr!23=!0A';
GRANT SELECT ON bdd.Usuario TO 'UserCheck';
GRANT SELECT ON bdd.verUsu TO 'UserCheck';

CREATE USER 'Backoffice' IDENTIFIED BY 'Backoffice';
GRANT SELECT ON bdd.verSolicitudes TO 'Backoffice';
GRANT EXECUTE ON PROCEDURE bdd.aceptarSolicitudReg TO 'Backoffice';
GRANT EXECUTE ON PROCEDURE bdd.rechazarSolicitudReg TO 'Backoffice';

CREATE USER 'PostLoader'@ IDENTIFIED BY 'Xkjjk)923=!1f';
GRANT SELECT ON bdd.verposts TO 'PostLoader';
GRANT SELECT ON bdd.vercomentarios TO 'PostLoader';
GRANT SELECT ON bdd.likes TO 'PostLoader';
GRANT SELECT ON bdd.verUsu TO 'PostLoader';

GRANT SELECT ON bdd.likes TO 'juanpe1';
GRANT SELECT ON bdd.verposts TO 'juanpe1';
GRANT SELECT ON bdd.vercomentarios TO 'juanpe1';
GRANT SELECT ON bdd.verUsu TO 'juanpe1';
GRANT SELECT ON bdd.verMensajes TO 'juanpe1';
GRANT SELECT ON bdd.verEventos TO 'juanpe1';
GRANT SELECT ON bdd.redes TO 'juanpe1';
GRANT SELECT ON bdd.rolRed TO 'juanpe1';
GRANT SELECT ON bdd.verGuardados TO 'juanpe1';
GRANT SELECT ON bdd.verAmigos TO 'juanpe1';

GRANT EXECUTE ON PROCEDURE bdd.creaPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.pubCom TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.darLike TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.guardarPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.compartirPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.guardarPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.quitarGuardarPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.compartirPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.agregarAmigo TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeP TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeR TO 'juanpe1';

GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO 'juanpe1';

GRANT SELECT ON bdd.likes TO 'anagom12';
GRANT SELECT ON bdd.verposts TO 'anagom12';
GRANT SELECT ON bdd.vercomentarios TO 'anagom12';
GRANT SELECT ON bdd.verUsu TO 'anagom12';
GRANT SELECT ON bdd.verMensajes TO 'anagom12';
GRANT SELECT ON bdd.verEventos TO 'anagom12';
GRANT SELECT ON bdd.redes TO 'anagom12';
GRANT SELECT ON bdd.rolRed TO 'anagom12';
GRANT SELECT ON bdd.verGuardados TO 'anagom12';
GRANT SELECT ON bdd.verAmigos TO 'anagom12';

GRANT EXECUTE ON PROCEDURE bdd.creaPost TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.pubCom TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.darLike TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.guardarPost TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.compartirPost TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.quitarGuardarPost TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.agregarAmigo TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeP TO 'anagom12';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeR TO 'anagom12';

GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO 'anagom12';

GRANT SELECT ON bdd.likes TO 'carli5';
GRANT SELECT ON bdd.verposts TO 'carli5';
GRANT SELECT ON bdd.vercomentarios TO 'carli5';
GRANT SELECT ON bdd.verUsu TO 'carli5';
GRANT SELECT ON bdd.verMensajes TO 'carli5';
GRANT SELECT ON bdd.verEventos TO 'carli5';
GRANT SELECT ON bdd.redes TO 'carli5';
GRANT SELECT ON bdd.rolRed TO 'carli5';
GRANT SELECT ON bdd.verGuardados TO 'carli5';
GRANT SELECT ON bdd.verAmigos TO 'carli5';

GRANT EXECUTE ON PROCEDURE bdd.creaPost TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.pubCom TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.darLike TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.guardarPost TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.compartirPost TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.quitarGuardarPost TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.agregarAmigo TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeP TO 'carli5';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeR TO 'carli5';

GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO 'carli5';

GRANT SELECT ON bdd.likes TO 'marialopez123';
GRANT SELECT ON bdd.verposts TO 'marialopez123';
GRANT SELECT ON bdd.vercomentarios TO 'marialopez123';
GRANT SELECT ON bdd.verUsu TO 'marialopez123';
GRANT SELECT ON bdd.verMensajes TO 'marialopez123';
GRANT SELECT ON bdd.verEventos TO 'marialopez123';
GRANT SELECT ON bdd.redes TO 'marialopez123';
GRANT SELECT ON bdd.rolRed TO 'marialopez123';
GRANT SELECT ON bdd.verGuardados TO 'marialopez123';
GRANT SELECT ON bdd.verAmigos TO 'marialopez123';

GRANT EXECUTE ON PROCEDURE bdd.creaPost TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.pubCom TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.darLike TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.guardarPost TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.compartirPost TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.quitarGuardarPost TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.agregarAmigo TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeP TO 'marialopez123';
GRANT EXECUTE ON PROCEDURE bdd.enviarMensajeR TO 'marialopez123';

GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO 'marialopez123';

#----------------------------------------------------------------------- Población

INSERT INTO Usuario (id_usuario, nombre, apellido, fechaNacimiento, mail, pais, pfp, genero, celular, fechaIngreso, estado, descripcion) VALUES
('juanpe1', 'Juan', 'Pérez', '1990-05-15', 'jperez@mail.com', 'Uruguay', 'juan.png', 'M', '099123456', '2024-08-15 00:00:00', 'Online', 'ESTA ES UNA DESCRIPCIOND DE PRUEBA, PARA PROBAR COMO FUNCIONA LAS NEWLINE Y TODO ESO...'),
('anagom12', 'Ana', 'Gómez', '1985-08-20', 'agomez@mail.com', 'Argentina', 'ana.png', 'F', '099654321', '2024-08-16 00:00:00', 'Offline', 'ESTA ES OTRA DESCRIPCION EN LA QUE HABLA DE COMO LE GUSTA LA MANTECA'),
('carli5', 'Carlos', 'Rodríguez', '1992-03-22', 'carlor@hotmail.com', 'Brasil', 'carlos.png', 'M', '099876543', '2024-08-17 00:00:00', 'Online', 'HOOOOLAAAAAAA, ME GUSTA JUGAR AL MINECRAFTT!!!!! ESCRIBANME AL DISCORD PARA UNIRSE A MI SERBIDOR DE MINECRAFT'),
('marialopez123', 'María', 'Lopez', '2004-06-09', 'mlopez@gmail.com', 'Bolivia','maria.png','F','094398152','2024-07-31 00:00:00','Offline', 'HMM...');

INSERT INTO Preferencias (id_usuario, preferencias)
VALUES 
('juanpe1', 'Deportes'),
('juanpe1', 'Tecnología'),
('anagom12', 'Moda'),
('anagom12', 'Cocina'),
('carli5', 'Viajes'),
('carli5', 'Fotografía'),
('marialopez123', 'Arte'),
('marialopez123', 'Historia');

INSERT INTO BackOffice (nombre)
VALUES 
('Administrador'),
('Moderador'),
('Soporte');

INSERT INTO AniadeAmigo (id_usuario1, id_usuario2, fecha)
VALUES
('juanpe1', 'anagom12', '2024-05-01 11:00:00'),
('juanpe1', 'carli5', '2024-05-02 13:30:00'),
('anagom12', 'marialopez123', '2024-05-03 14:00:00'),
('carli5', 'juanpe1', '2024-05-04 15:00:00'),
('marialopez123', 'carli5', '2024-05-05 16:00:00');

INSERT INTO Post (modificado, texto)
VALUES
(FALSE, 'Primer post de Juan'),
(FALSE, 'Ana comparte su receta favorita'),
(TRUE, 'Carlos publica su reseña de un libro'),
(TRUE, 'María muestra su última obra de arte'),
(FALSE, 'Un post más sobre tecnología por Juan');

-- Insertando datos en la tabla Imagen (vinculado a un Post)
INSERT INTO Imagen (id_post, datapath)
VALUES
(1, 'img_39255.jpeg'),
(2, 'img_47871.png'),
(3, 'img_63373.png'),
(4, 'img_76843.png'),
(5, 'img_85489.png');

-- Insertando datos en la tabla Comenta
INSERT INTO Comenta (id_usuario, id_post, fecha, comentario)
VALUES
('juanpe1', 2, '2024-05-02 15:00:00', '¡Qué buena receta, Ana!'),
('anagom12', 3, '2024-05-03 10:00:00', 'Me gusta mucho este libro'),
('carli5', 4, '2024-05-04 12:00:00', 'Impresionante obra de arte, María'),
('marialopez123', 1, '2024-05-05 13:00:00', 'Interesante post, Juan'),
('juanpe1', 5, '2024-05-06 14:00:00', 'Otra gran actualización de tecnología');

-- Insertando datos en la tabla Comparte
INSERT INTO Comparte (id_usuario, id_post, fecha)
VALUES
('juanpe1', 2, '2024-05-02 16:00:00'),
('anagom12', 3, '2024-05-03 11:00:00'),
('carli5', 10, '2024-05-04 13:00:00'),
('marialopez123', 1, '2024-05-05 14:00:00');

-- Insertando datos en la tabla Guarda
INSERT INTO Guarda (id_usuario, id_post, fecha)
VALUES
('juanpe1', 1, '2024-05-06 17:00:00'),
('anagom12', 2, '2024-05-06 18:00:00'),
('carli5', 3, '2024-05-07 08:00:00'),
('marialopez123', 10, '2024-05-07 09:00:00');

-- Insertando datos en la tabla Reacciona
INSERT INTO Reacciona (id_usuario, id_post, reaccion)
VALUES
('juanpe1', 1, 'corazon'),
('anagom12', 2, 'enamorado'),
('carli5', 3, 'comico'),
('marialopez123', 4, 'sorprendido'),
('juanpe1', 5, 'enojado');

-- Insertando datos en la tabla Publica
INSERT INTO Publica (id_usuario, id_post, fechaCreacion)
VALUES
('juanpe1', 1, '2024-05-01 12:00:00'),
('anagom12', 2, '2024-05-02 13:00:00'),
('carli5', 3, '2024-05-03 14:00:00'),
('marialopez123', 4, '2024-05-04 15:00:00'),
('juanpe1', 5, '2024-05-05 16:00:00');
