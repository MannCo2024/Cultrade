DROP VIEW IF EXISTS verposts;
DROP VIEW IF EXISTS vercomentarios;
DROP VIEW IF EXISTS likes;
DROP VIEW IF EXISTS verSolicitudes;
DROP VIEW IF EXISTS verUsu;
DROP FUNCTION IF EXISTS NombreUsuario;
DROP PROCEDURE IF EXISTS creaPost;
DROP PROCEDURE IF EXISTS pubCom;
DROP PROCEDURE IF EXISTS darLike;
DROP PROCEDURE IF EXISTS quitarLike;
DROP PROCEDURE IF EXISTS solicitudUsuario;
DROP PROCEDURE IF EXISTS aceptarSolicitudReg;


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
	s.id AS id,
	s.fechaCreacion AS FechaCreacion,
	s.estado AS Estado,
	s.fechaCompletado AS fechaCompletado,
	r.id_usuario AS Usuario,
	r.nombre AS Nombre,
	r.apellido AS Apellido,
	r.fechaNacimiento AS Nacimiento,
	r.mail AS Mail,
	r.pais AS pais,
	r.celular AS Telefono,
	r.pass
FROM 
	Solicitud s 
JOIN
	Registros r ON r.solicitud = s.id;
	
				-- Crear view verUsu
CREATE VIEW verUsu AS
SELECT
	id_usuario AS Usuario
FROM
	Usuario;
	
				-- Crear función NombreUsuario
DELIMITER //
CREATE FUNCTION NombreUsuario() RETURNS VARCHAR(255)
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
    IN p_genero ENUM('M','F','O'),
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
    VALUES ('🟨', NOW());

    SET @v_solicitud_id = LAST_INSERT_ID();
	
    INSERT INTO Registros (solicitud, id_usuario, nombre, apellido, fechaNacimiento, mail, pais, genero, celular, pass)
    VALUES (@v_solicitud_id, p_id_usuario, p_nombre, p_apellido, p_fechaNacimiento, p_mail, p_pais, p_genero, p_celular, p_pass);
	
    COMMIT;

END //
DELIMITER ;

				-- Crear procedimiento aceptarSolicitudReg
DELIMITER //
CREATE PROCEDURE aceptarSolicitudReg(
    IN solicitudID INT
)
BEGIN
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
    SET estado = '🟩'
    WHERE id = solicitudID;

    COMMIT;
END //
DELIMITER ;

