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
@accountid int
as
insert into transaction_
(opIdFK,transAmMoney,transdate,transDestinyAcc,accIdFK)
values
(@OpId, @money,@date,@destiny,@accountid)
go

create proc login_user
@ci varchar(15),
@password varchar(25)
as
 if (select count(*) from user_ where userCi like @ci) 