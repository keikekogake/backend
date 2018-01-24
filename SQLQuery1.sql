select * from ClienteTemp

BEGIN TRAN CadCliente

declare @nome varchar(50);
declare @email varchar(100);
declare @idade int;

set @nome = 'Keike Kogake';
set @email = 'keikekogake@gmail.com';
set @idade = 10;

insert into ClienteTemp (nome, email, data_cad, idade)
values (@nome, @email, getdate(), @idade)

if (@idade < 18)
	begin
		print 'Idade abaixo de 18 anos';
	rollback tran CadCliente
end
else
	begin
		print 'Cadastro feito com sucesso';
	commit tran CadCliente
end