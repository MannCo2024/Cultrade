DROP VIEW IF EXISTS verposts;
DROP VIEW IF EXISTS vercomentarios;
DROP VIEW IF EXISTS likes;
DROP PROCEDURE IF EXISTS creaPost;
DROP PROCEDURE IF EXISTS pubCom;
DROP PROCEDURE IF EXISTS darLike;
DROP PROCEDURE IF EXISTS quitarLike;


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
    INSERT INTO Publica(id_usuario, id_post, fechaCreacion) VALUES(CURRENT_USER(), IdPost, NOW());

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
	
    INSERT INTO Comenta(id_usuario, id_post, fecha, comentario) VALUES (CURRENT_USER(), IdPost, NOW(), Texto);
	
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
	
    INSERT INTO Reacciona(id_usuario, id_post, reaccion) VALUES (CURRENT_USER(), IdPost, 'corazon');
	
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
	
    DELETE FROM Reacciona WHERE id_usuario = CURRENT_USER() AND id_post = IdPost; 
	
    COMMIT;
END //
DELIMITER ;

-- Crear vista vercomentarios
CREATE VIEW vercomentarios AS
SELECT u.id_usuario AS Usuario, c.id_post AS Post, c.comentario AS Comentario 
FROM Comenta c JOIN Usuario u ON c.id_usuario = u.id_usuario;

-- Crear vista likes para contar reacciones
CREATE VIEW likes AS 
SELECT id_post as Post, id_usuario as Usuario, COUNT(*) AS Likes 
FROM Reacciona
GROUP BY id_post;

-- Crear función NombreUsuario
DELIMITER //
CREATE FUNCTION NombreUsuario() RETURNS VARCHAR(255)
DETERMINISTIC
BEGIN
    RETURN SUBSTRING_INDEX(USER(), '@', 1);
END //
DELIMITER ;
