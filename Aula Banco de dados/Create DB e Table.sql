--CREATE DATABASE Papelaria
--on (
--	name = 'Papelaria_data',
--	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\Data\Papelaria_data.mdf',
--	size = 20mb,
--	maxsize = 100mb,
--	filegrowth = 10mb
--)
--log on (
--	name = 'Papelaria_log',
--	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\Data\Papelaria_log.ldf',
--	size = 30mb,
--	maxsize = 200mb,
--	filegrowth = 10mb
--)

--GO

--USE Papelaria

--GO

--CREATE TABLE Cliente (
--	id_cliente int identity primary key,
--	nome_cliente varchar(50) not null,
--	email_cliente varchar(50) not null,
--	cpf_cliente varchar(15) not null unique,
--	data_cadastro datetime default getdate()
--)

--GO

--CREATE TABLE Categoria (
--	id_categoria int identity primary key,
--	titulo varchar(30) not null
--)

--GO

--CREATE TABLE Produto (
--	id_produto int identity primary key,
--	nome_produto varchar(50),
--	descricao text  not null,
--	id_categoria int foreign key references Categoria (id_categoria) not null,
--	preco decimal (10,2)
--)

--GO

--CREATE TABLE Estoque (
--	id_estoque int identity primary key,
--	id_produto int foreign key references Produto (id_produto) not null,
--	quantidade int not null
--)

--GO

--CREATE TABLE Funcionario (
--	id_funcionario int identity primary key,
--	nome_funcionario varchar(50) not null,
--	cargo varchar(50) not null,
--	departamento varchar(50) not null
--)

--GO

--CREATE TABLE Usuario (
--	id_usuario int identity primary key,
--	id_funcionario int foreign key references Funcionario (id_funcionario) not null,
--	nome_usuario varchar(50) not null,
--	senha varchar(50) not null
--)

--GO

--CREATE TABLE Pedido (
--	id_pedido int identity primary key,
--	id_cliente int foreign key references Cliente (id_cliente) not null,
--	id_funcionario int foreign key references Funcionario (id_funcionario) not null,
--	data_pedido datetime default getdate()
--)

--GO

--CREATE TABLE DetalhePedido (
--	id_detalhe_pedido int identity primary key,
--	id_pedido int foreign key references Pedido (id_pedido) not null,
--	id_produto int foreign key references Produto (id_produto) not null,
--	quantidadeComprada int not null check (quantidadeComprada > 0)
--)

--select * from Categoria;

--INSERT INTO Categoria (titulo) 
--VALUES
--	('Escolar'),
--	('Informática')

--select * from Produto

--insert into Produto (nome_produto, descricao, id_categoria, preco)
--values ('Caneta', 'Caneta preta', 1, 5.90)

--update Produto
--set descricao = concat('Caneta ',id_produto)

--update Produto
--set preco = preco * 1.2 where id_produto = 6

delete from Produto
where id_produto > 6

GO
select * from Produto