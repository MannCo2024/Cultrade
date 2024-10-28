create view verposts as
select pub.id_usuario as 'Usuario', p.id_post as 'Post', p.texto as 'Texto', i.datapath as 'Imagen', p.modificado as 'Modificado', pub.fechaCreacion as FechaCreacion
from Post p join Publica pub ON p.id_post = pub.id_post 
left join Imagen i ON p.id_post = i.id_post;
/*
CREATE PROCEDURE creaPost
    @IdUsuario varchar(32) not null,
    @Texto varchar(250),
    @Imagen varchar(60)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @IdPost INT;
		
        INSERT INTO Post(modificado, texto) VALUES(0, @Texto);
        SET @IdPost = LAST_INSERT_ID();
        INSERT INTO Imagen(id_post, datapath) VALUES(@IdPost, @Imagen);
        INSERT INTO Publica(id_usuario, id_post, fechaCreacion) VALUES(@IdUsuario, @IdPost, NOW());
		
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;*/

DELIMITER //
CREATE PROCEDURE creaPost(
    IN IdUsuario VARCHAR(32),
    IN Texto VARCHAR(250),
    IN Imagen VARCHAR(60)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
    DECLARE IdPost INT;
	
    INSERT INTO Post(modificado, texto) VALUES(FALSE, Texto);
    SET IdPost = LAST_INSERT_ID();
    INSERT INTO Imagen(id_post, datapath) VALUES(IdPost, Imagen);
    INSERT INTO Publica(id_usuario, id_post, fechaCreacion) VALUES(IdUsuario, IdPost, NOW());

    COMMIT;
END //
DELIMITER ;




create view vercomentarios as
SELECT u.id_usuario AS Usuario, c.id_post AS Post, c.comentario AS Comentario 
FROM Comenta c JOIN Usuario u ON c.id_usuario = u.id_usuario;

