INSERT INTO Usuario (id_usuario, nombre, apellido, fechaNacimiento, mail, pais, pfp, genero, celular, fechaIngreso, estado, descripcion) VALUES
('juanpe1', 'Juan', 'Pérez', '1990-05-15', 'jperez@mail.com', 'Uruguay', 'juan.png', 'M', '099123456', '2024-08-15 00:00:00', 'Online', 'ESTA ES UNA DESCRIPCIOND DE PRUEBA, PARA PROBAR COMO FUNCIONA LAS NEWLINE Y TODO ESO...'),
('anagom12', 'Ana', 'Gómez', '1985-08-20', 'agomez@mail.com', 'Argentina', 'ana.png', 'F', '099654321', '2024-08-16 00:00:00', 'Offline', 'ESTA ES OTRA DESCRIPCION EN LA QUE HABLA DE COMO LE GUSTA LA MANTECA'),
('carli5', 'Carlos', 'Rodríguez', '1992-03-22', 'carlor@hotmail.com', 'Brasil', 'carlos.png', 'M', '099876543', '2024-08-17 00:00:00', 'Online', 'HOOOOLAAAAAAA, ME GUSTA JUGAR AL MINECRAFTT!!!!! ESCRIBANME AL DISCORD PARA UNIRSE A MI SERBIDOR DE MINECRAFT'),
('marialopez123', 'María', 'Lopez', '2004-06-09', 'mlopez@gmail.com', 'Bolivia','maria.png','F','094398152','2024-07-31 00:00:00','Offline', 'HMM...');

UPDATE Usuario SET descripcion = 'ESTA ES UNA DESCRIPCIOND DE PRUEBA, PARA PROBAR COMO FUNCIONA LAS NEWLINE Y TODO ESO...' WHERE id_usuario = 'juanpe1';
UPDATE Usuario SET descripcion = 'ESTA ES OTRA DESCRIPCION EN LA QUE HABLA DE COMO LE GUSTA LA MANTECA' WHERE id_usuario = 'anagom12';
UPDATE Usuario SET descripcion = 'HOOOOLAAAAAAA, ME GUSTA JUGAR AL MINECRAFTT!!!!! ESCRIBANME AL DISCORD PARA UNIRSE A MI SERBIDOR DE MINECRAFT' WHERE id_usuario = 'carli5';
UPDATE Usuario SET descripcion = 'HMM...' WHERE id_usuario = 'marialopez123';

DROP USER 'juanpe1';
DROP USER 'anagom12';
DROP USER 'carli5';
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

GRANT EXECUTE ON PROCEDURE bdd.creaPost TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.pubCom TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.darLike TO 'juanpe1';
GRANT EXECUTE ON PROCEDURE bdd.quitarLike TO 'juanpe1';

GRANT EXECUTE ON FUNCTION bdd.NombreUsuario TO 'juanpe1';

-- NO FUNCIONAN LOS ASTERISCOS!!!!
