-- show engine innodb status;
-- XAMPP: myqsldump -u [usuario] -p [nombreBD].sql > [nombreDB].sql

-------------------------------------------------------------- CONTENIDO DE USUARIO 

CREATE TABLE Usuario(
	id_usuario varchar(32) unique,
    nombre varchar(32) not null,
    apellido varchar(32) not null,
    fechaNacimiento datetime,
	mail varchar(64) unique,
    pais varchar(14) not null,
    pfp varchar(255),
    genero enum('M','F','O'),
    celular varchar(15) unique,
    fechaIngreso datetime not null,
    estado enum('Online', 'Offline'),
    
    PRIMARY KEY (id_usuario, celular, mail)
);

CREATE TABLE Preferencias( -- De usuario
	id_preferencias varchar(32),
    preferencias varchar(25),
    
    PRIMARY KEY (id_preferencias),
    CONSTRAINT FK_id_preferencias FOREIGN KEY (id_preferencias) REFERENCES Usuario(id_usuario)
) ;

CREATE TABLE Registros(
	id_usuario varchar(32) unique,
    nombre varchar(32) not null,
    apellido varchar(32) not null,
    fechaNacimiento datetime,
	mail varchar (64) unique not null,
    pais varchar(14) not null,
    pfp varchar(255),
    genero enum('M','F','O'),
    celular varchar(15) unique,
    fechaAceptado datetime not null,
    estado enum('En Espera', 'Aceptado', 'Rechazado'),
    
    PRIMARY KEY (id_usuario, celular, mail)
);


CREATE TABLE AniadeAmigo( -- >>> Verificar su función correcta   |   EN TEORÍA ESTA ANDANDO
	id_usuario1 varchar(32) not null references Usuario(id_usuario),
    id_usuario2 varchar(32) not null references Usuario(id_usuario),
    fecha datetime not null
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
    duenio varchar(64) not null,
    fechaCreacion datetime not null,
	nombre varchar(32) not null,
    descripcion varchar(200),
    
    PRIMARY KEY (id_red),
    CONSTRAINT FK_duenio_Red FOREIGN KEY (duenio) REFERENCES Usuario(id_usuario)
); 

CREATE TABLE UsuarioIngresa(
	red int not null,
	usuario varchar(64) not null,
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

CREATE TABLE MensajeRed(
	id_usuario varchar(32) not null,
    id_red int not null,
    fechaEnvio datetime,
    mensaje varchar(500),
    
    PRIMARY KEY (id_usuario, id_red),
    CONSTRAINT FK_id_usuario_MensajeRed FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_id_red_MensajeRed FOREIGN KEY (id_red) REFERENCES Red(id_red)
);

CREATE TABLE MensajeriaPrivada(
	id_usuario1 varchar(32) not null references Usuario(id_usuario),
    id_usuario2 varchar(32) not null references Usuario(id_usuario),
	fechaEnvio datetime,
    mensaje varchar(500)
);



-------------------------------------------------------------- CONSULTAS

-- Ver los mensajes de un usuario
-- ¨¨ los post de un usuario
-- ¨¨ los eventos de una comunidad
-- ¨¨ las redes que creó un usuario
-- ¨¨ el rol que tiene un usuario en una comunidad
/*

			# Ver mensajes que un usuario envio
select id_usuario1 as 'Origen', id_usuario2 as 'Destinatario', mensaje as 'Mensaje', fechaEnvio  as 'Fecha de Envio'
from MensajeriaPrivada
where id_usuario1 = 'juanpe1';

			# Ver los posts de un usuario
select pub.id_usuario as 'Usuario', p.id_post as 'Post', p.texto as 'Texto', i.datapath as 'Imagen', v.id_video as 'Video', p.modificado as 'Modificado'
from Post p
join Publica pub ON p.id_post = pub.id_post
left join Video v ON p.id_post = v.id_post
left join Imagen i ON p.id_post = i.id_post
where pub.id_usuario is not null
order by pub.fechaCreacion;
			# Ver los eventos de una comunidad
select e.id_evento as Evento, c.id_red as Comunidad, e.imagen, e.descripcion, e.tipo, e.organizador, e.ubicacion, e.fechaInicio as Inicio, e.fechaFin as Fin
from evento e
join Comunidad c on e.id_red = c.id_red
left join Red r on c.id_red = r.id_red
where c.id_red = '1';

			# Redes que creo un usuario
select r.id_red as Red, u.id_usuario as Dueño, r.nombre as Nombre, r.fechaCreacion as 'Fecha de Creacion'
from Red r join Usuario u on r.duenio = u.id_usuario
where u.id_usuario = 'juanpe1';

			# Rol de un usuario en una comunidad
select u.id_usuario as Usuario, rl.id_red as Red, r.nombre as Nombre
from Comunidad c join Red r on c.id_red = r.id_red
left join Roles rl on c.id_red = rl.id_red
left join Usuario u on rl.id_usuario = u.id_usuario
where c.id_red = '1' and u.id_usuario = 'juanpe1' ;

SELECT COUNT(*) as Likes 
FROM Reacciona 
WHERE id_post = '1' AND reaccion = 'corazon';

select *
from Reacciona
where id_post = '1' AND id_usuario = 'juanpe1';

show engine innodb status;