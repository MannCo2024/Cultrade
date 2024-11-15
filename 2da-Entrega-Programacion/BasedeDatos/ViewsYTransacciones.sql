/*
DROP VIEW IF EXISTS verposts;
DROP VIEW IF EXISTS vercomentarios;
DROP VIEW IF EXISTS likes;
DROP VIEW IF EXISTS verSolicitudes;
DROP VIEW IF EXISTS verUsu;
DROP VIEW IF EXISTS verBO;
DROP VIEW IF EXISTS verMensajes;
DROP VIEW IF EXISTS verEventos;
DROP VIEW IF EXISTS redes;
DROP VIEW IF EXISTS rolRed;
		DROP VIEW IF EXISTS verGuardados;

DROP FUNCTION IF EXISTS NombreUsuario;

DROP PROCEDURE IF EXISTS creaPost;
DROP PROCEDURE IF EXISTS pubCom;
DROP PROCEDURE IF EXISTS darLike;
DROP PROCEDURE IF EXISTS quitarLike;
DROP PROCEDURE IF EXISTS solicitudUsuario;
DROP PROCEDURE IF EXISTS aceptarSolicitudReg;
DROP PROCEDURE IF EXISTS rechazarSolicitudReg;
DROP PROCEDURE IF EXISTS crearUsuBO;

*/

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
SELECT vp.*
FROM
	verposts vp
JOIN
	Guarda g on vp.Post = g.id_post;
    
				-- View verAmigos
CREATE VIEW verAmigos AS 
SELECT 
	id_usuario2 AS Usuario
FROM
	
	
    
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

    COMMIT;
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