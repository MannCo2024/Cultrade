-- Inserciones en Preferencias
INSERT INTO Preferencias (id_preferencias, preferencias) VALUES
("juanpe1", "Futbol"),
("anagom12", "Cocina"),
("carli5", "Deportes"),
("marilo99", "Yoga");

-- Inserciones en BackOffice
INSERT INTO BackOffice (nombre) VALUES
("Admin"),
("Moderador"),
("Soporte");

-- Inserciones en Solicitud
INSERT INTO Solicitud (estado, fechaCreacion, fechaCompletado) VALUES
("Aceptado", "2024-01-01 10:00:00", "2024-01-02 14:00:00"),
("Pendiente", "2024-01-02 11:00:00", NULL),
("Rechazado", "2024-01-03 12:00:00", "2024-01-03 18:00:00");

-- Inserciones en Registros
INSERT INTO Registros (solicitud, id_usuario, nombre, apellido, fechaNacimiento, mail, pais, genero, celular, pass) VALUES
(1, "juanpe1", "Juan", "Pérez", "1990-05-12", "juanpe1@mail.com", "España", "H", "123456789", "pass123"),
(2, "anagom12", "Ana", "Gómez", "1985-08-22", "anagom12@mail.com", "México", "M", "987654321", "pass456"),
(3, "carli5", "Carlos", "Lima", "1992-02-15", "carli5@mail.com", "Argentina", "H", "456789123", "pass789"),
(2, "marilo99", "María", "López", "1987-11-30", "marilo99@mail.com", "Chile", "M", "321654987", "pass321");

-- Inserciones en AniadeAmigo
INSERT INTO AniadeAmigo (id_usuario1, id_usuario2, fecha) VALUES
("juanpe1", "anagom12", "2024-01-05 15:30:00"),
("juanpe1", "carli5", "2024-01-06 16:30:00"),
("carli5", "marilo99", "2024-01-07 17:30:00");

-- Inserciones en Post
INSERT INTO Post (modificado, texto) VALUES
(FALSE, "Este es mi primer post!"),
(TRUE, "Actualización de estado"),
(FALSE, "Hoy ha sido un gran día");

-- Inserciones en Video
INSERT INTO Video (id_post, id_video, datapath) VALUES
(1, 101, "video1.mp4"),
(2, 102, "video2.mp4");

-- Inserciones en Imagen
INSERT INTO Imagen (id_post, datapath) VALUES
(1, "img_29799.png"),
(2, "img_85489.png"),
(3, "img_39012.png");

-- Inserciones en Comenta
INSERT INTO Comenta (id_usuario, id_post, fecha, comentario) VALUES
("juanpe1", 1, "2024-01-05 10:00:00", "¡Gran post!"),
("anagom12", 2, "2024-01-06 11:00:00", "Estoy de acuerdo"),
("carli5", 3, "2024-01-07 12:00:00", "¡Qué bien!");

-- Inserciones en Comparte
INSERT INTO Comparte (id_usuario, id_post) VALUES
("juanpe1", 1),
("anagom12", 2),
("marilo99", 3);

-- Inserciones en Reacciona
INSERT INTO Reacciona (id_usuario, id_post, reaccion) VALUES
("juanpe1", 1, "corazon"),
("anagom12", 2, "comico"),
("marilo99", 3, "sorprendido");

-- Inserciones en Publica
INSERT INTO Publica (id_usuario, id_post, fechaCreacion) VALUES
("juanpe1", 1, "2024-01-05 10:00:00"),
("anagom12", 2, "2024-01-06 11:00:00"),
("carli5", 3, "2024-01-07 12:00:00");

-- Inserciones en Red
INSERT INTO Red (fechaCreacion, nombre, descripcion) VALUES
("2024-01-01 10:00:00", "Red de Viajeros", "Una red para compartir experiencias de viaje"),
("2024-01-02 11:00:00", "Cine y Series", "Red para amantes del cine");

-- Inserciones en CreaRed
INSERT INTO CreaRed (id_red, id_usuario) VALUES
(1, "juanpe1"),
(2, "anagom12");

-- Inserciones en UsuarioIngresa
INSERT INTO UsuarioIngresa (red, usuario, fecha) VALUES
(1, "juanpe1", "2024-01-01 11:00:00"),
(1, "marilo99", "2024-01-02 12:00:00"),
(2, "carli5", "2024-01-03 13:00:00");

-- Inserciones en Comunidad
INSERT INTO Comunidad (id_red) VALUES
(1),
(2);

-- Inserciones en Grupo
INSERT INTO Grupo (id_red) VALUES
(1),
(2);

-- Inserciones en Roles
INSERT INTO Roles (id_usuario, id_red, rol) VALUES
("juanpe1", 1, "Dueño"),
("marilo99", 1, "Usuario"),
("carli5", 2, "Moderador");

-- Inserciones en Evento
INSERT INTO Evento (id_evento, id_red, organizador, imagen, descripcion, tipo, fechaInicio, FechaFin, ubicacion, quienPuedeCrearPost) VALUES
(1, 1, "juanpe1", "img_32255.jpeg", "Reunión de viajeros", "Presencial", "2024-01-10 10:00:00", "2024-01-10 18:00:00", "Parque Central", "Moderador"),
(2, 2, "anagom12", "img_47871.png", "Maratón de Cine", "Streaming", "2024-01-15 20:00:00", "2024-01-16 02:00:00", NULL, "Dueño");

-- Inserciones en MensajeRed
INSERT INTO MensajeRed (id_usuario, id_red, fechaEnvio, mensaje) VALUES
("juanpe1", 1, "2024-01-04 14:30:00", "Hola a todos en la red de viajeros!"),
("anagom12", 2, "2024-01-04 15:30:00", "Bienvenidos a los amantes del cine");

-- Inserciones en MensajeriaPrivada
INSERT INTO MensajeriaPrivada (id_usuario1, id_usuario2, fechaEnvio, mensaje) VALUES
("juanpe1", "carli5", "2024-01-05 16:00:00", "Hola, Carlos, cómo estás?"),
("anagom12", "marilo99", "2024-01-06 17:00:00", "Hola, María, te interesa el evento de cine?");
