INSERT INTO Usuario (id_usuario, nombre, apellido, fechaNacimiento, mail, pais, pfp, genero, celular, fechaIngreso, estado) VALUES
('juanpe1', 'Juan', 'Pérez', '1990-05-15', 'jperez@mail.com', 'Uruguay', 'juan.png', 'M', '099123456', '2024-08-15 00:00:00', 'Online'),
('anagom12', 'Ana', 'Gómez', '1985-08-20', 'agomez@mail.com', 'Argentina', 'ana.png', 'F', '099654321', '2024-08-16 00:00:00', 'Offline'),
('carli5', 'Carlos', 'Rodríguez', '1992-03-22', 'carlor@hotmail.com', 'Brasil', 'carlos.png', 'M', '099876543', '2024-08-17 00:00:00', 'Online'),
('marialopez123', 'María', 'Lopez', '2004-06-09', 'mlopez@gmail.com', 'Bolivia','maria.png','F','094398152','2024-07-31 00:00:00','Offline');

DROP USER 'juanpe1';
DROP USER 'anagom12';
DROP USER 'carli5';
DROP USER 'carlo123';
DROP USER 'marilo99';
DROP USER 'PostLoader';
DROP USER 'UserCheck';

CREATE USER 'juanpe1' IDENTIFIED BY 'juanpe1';
CREATE USER 'anagom12' IDENTIFIED BY 'anagomez';
CREATE USER 'carli5' IDENTIFIED BY 'carlo123';
CREATE USER 'marialopez123' IDENTIFIED BY 'marilo99';

CREATE USER 'UserCheck'@ IDENTIFIED BY 'Xk9rr!23=!0A';
GRANT SELECT ON bdd.Usuario TO 'UserCheck';
GRANT SELECT ON bdd.verUsu TO 'UserCheck';

CREATE USER 'PostLoader'@ IDENTIFIED BY 'Xkjjk)923=!1f';

GRANT SELECT ON bdd.verposts TO 'PostLoader';
GRANT SELECT ON bdd.vercomentarios TO 'PostLoader';
GRANT SELECT ON bdd.likes TO 'PostLoader';

GRANT SELECT ON bdd.likes TO 'juanpe1';
GRANT SELECT ON bdd.verposts TO 'juanpe1';
GRANT SELECT ON bdd.vercomentarios TO 'juanpe1';

GRANT EXECUTE ON PROCEDURE bdd.creaPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.pubCom TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.darLike TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO 'juanpe1';

GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO 'juanpe1';

-- NO FUNCIONAN LOS ASTERISCOS!!!!
GRANT SELECT ON bdd.verposts TO *;
GRANT EXECUTE ON PROCEDURE bdd.creaPost TO *;
GRANT EXECUTE ON PROCEDURE bdd.pubCom TO *;
GRANT EXECUTE ON PROCEDURE bdd.darLike TO *;
GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO *;
GRANT SELECT ON bdd.vercomentarios TO *;
GRANT SELECT ON bdd.likes TO *;
