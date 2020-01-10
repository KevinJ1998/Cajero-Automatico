/*creacion de base de datos*/
create database cajero

use cajero
go
create table user_ (
userId int identity (1,1) primary key not null,
userName varchar (30) null,
userCi varchar (15) not null,
userPwd varchar (25) not null
)

create table type_acc(
typeaccID int identity (1,1) primary key not null,
typeaccDesc varchar (10) not null
)

create table account(
accId int identity (1,1) primary key not null,
accNum varchar (15) not null,
accTypeFK int not null,
userIdFK int not null,
accAvMoney money not null,
foreign key (userIdFK) references user_(userId),
foreign key (accTypeFK) references type_acc(typeaccID)
)


create table operation(
opId int identity primary key not null,
opDesc varchar (12) not null
)


create table transaction_(
transID int identity (1,1) primary key not null,
opIdFK int not null,
transAmMoney money not null,
transdate datetime not null,
transDestinyAcc varchar(15),
accIdFK int not null,
foreign key (accIdFK) references account(accId),
foreign key (opIdFK) references operation(opId) 
)


insert into user_ values
('Nicole Zambrano','1723666507','0112' ),
('Kevin Segovia','1723707624','0086'),
('Sebastián Morales','1718976010','0056'),
('Juanito Perez','1723142702','2702')

select*from user_

insert into type_acc values
('Ahorro'),
('Corriente')

select*from type_acc 

insert into account values
('2256895618',1,1,850.10),
('2256895618',2,1,1199.99),
('2231008605',1,2,900),
('2231008605',2,2,1200.25),
('6725469204',1,3,1000),
('6725469204',2,3,2800.70),
('7347259724',1,4,10000),
('7347259724',2,4,3000)

insert into operation values 
('Consulta'),
('Retiro'),
('Deposito')
go

/*Procedimientos almacenados*/
create procedure transactions
@OpId int,
@money money,
@date datetime,
@destiny varchar(15),
@accountid int,
@iduser int,
@typeaccount int
as
begin
insert into transaction_
(opIdFK,transAmMoney,transdate,transDestinyAcc,accIdFK)
values
(@OpId, @money,@date,@destiny,@accountid)
exec Retiro @monto = @money, @userid = @iduser, @accountType = @typeaccount
exec Deposito @monto = @money, @userid = @iduser, @accountType = @typeaccount
end
go

create procedure Consulta
@userid int,
@accountType int
as
Select accAvMoney from account where
userIdFK=@userid and accTypeFK=@accountType

go
create procedure Retiro
@monto money,
@userid int,
@accountType int
as
if ((select accAvMoney from account) < @monto or (select accAvMoney from account) = 0)
 begin
	raiserror('Saldo insuficiente',16,1)
 end
else
 begin
	update account
	set accAvMoney = accAvMoney-@monto
	where userIdFK=@userid and accTypeFK=@accountType
 end

go
create procedure Deposito
@monto money,
@userid int,
@accountType int
as
update account
set accAvMoney = accAvMoney+@monto
where userIdFK=@userid and accTypeFK=@accountType
go

create proc _login 
@userci varchar(15),
@pwd varchar(25)
as
select * from user_ where
userCi = @userci and userPwd = @pwd
go

/*Triggers*/
create trigger confirm_transaction
on transaction_
for insert
as
	if (select count(*) from inserted)>1
	begin
	print 'Transacction realizada correctamente'
end
go



