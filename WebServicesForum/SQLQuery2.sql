

create proc sp_cadastrar_usuario
@nome varchar(255),
@login varchar(255),
@senha varchar(255)
as
insert into usuario (nome, login, senha)
values (@nome, @login, @senha)


create proc sp_atualizar_usuario
@id int,
@nome varchar(255),
@login varchar(255),
@senha varchar(255)
as
update usuario
set 
	nome = @nome,
	senha = @senha,
	login = @login
where id = @id


create proc sp_deletar_usuario
@id int
as
delete from usuario
where id = @id


create proc sp_cadastrar_topico
@titulo varchar(255),
@descricao varchar(255)
as
insert into topicoforum (titulo, descricao)
values (@titulo, @descricao)