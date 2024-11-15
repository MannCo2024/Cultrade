-- show engine innodb status;
-- XAMPP: myqsldump -u [usuario] -p [nombreBD].sql > [nombreDB].sql

-------------------------------------------------------------- CONTENIDO DE USUARIO 

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



-------------------------------------------------------------- CONSULTAS

-- ¨¨ Ver los mensajes de un usuario
-- ¨¨ los post de un usuario
-- ¨¨ los eventos de una comunidad
-- ¨¨ las redes que creó un usuario
-- ¨¨ el rol que tiene un usuario en una comunidad
/*


