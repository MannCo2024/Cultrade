
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
INSERT INTO Red (duenio,fechaCreacion) VALUES
('juanpe1','2024-08-15 00:00:00'),
('anagom12', '2024-08-16 00:00:00');

-- Insertar datos en la tabla Comunidad
INSERT INTO Comunidad (id_red) VALUES
(1),
(2);

-- Insertar datos en la tabla Grupo
INSERT INTO Grupo (id_red) VALUES
(1),
(2),

-- Insertar datos en la tabla Roles
INSERT INTO Roles (id_usuario, id_red, rol) VALUES
('juanpe1', 1, 'Duenio'),
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
