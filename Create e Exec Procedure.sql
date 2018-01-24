use Papelaria

select * from Cliente

CREATE PROCEDURE sp_CadCliente
@nome varchar (50),
@email varchar(100),
@cpf varchar(20)
as
INSERT INTO Cliente (nome_cliente, email_cliente, cpf_cliente)
VALUES (@nome, @email, @cpf)


EXEC sp_CadCliente 'Keike','keike.kogake@gmail.com','40314256865'


CREATE PROCEDURE sp_DelCliente
@id int
as
DELETE FROM Cliente
WHERE id_cliente = @id

