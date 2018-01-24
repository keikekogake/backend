create database BancoForum

use BancoForum

GO
create table usuario (
	id int primary key identity,
	nome varchar(255) not null,
	login varchar(255) unique not null,
	senha varchar(255) not null,
	datacadastro datetime default getdate()
);

GO
create table topicoforum (
	id int primary key identity,
	titulo varchar(255) not null,
	descricao varchar(255) not null,
	datacadastro datetime default getdate()
);

GO
create table postagem (
	id int primary key identity,
	idtopico int foreign key references topicoforum (id),
	idusuario int foreign key references usuario (id),
	mensagem text not null,
	datapublicacao datetime default getdate()
);
