use master
create database csharpCamadas
go
use csharpCamadas
go

create table Veiculo(
vei_id int primary key identity(1,1),
vei_nome varchar(255),
vei_placa varchar(255)
)

insert Veiculo(vei_nome, vei_placa) values ('Fiat', 'JHB-3467')
select * from Veiculo

create table Posto(
pos_id int primary key identity(1,1),
pos_nome varchar(255),
pos_cidade varchar(255),
pos_endereco varchar(255)
)

insert Posto(pos_nome, pos_cidade,pos_endereco) values ('Vitoria', 'Estancia','Rodovia')
select * from Posto

create table Motorista(
mot_id int primary key identity(1,1),
mot_nome varchar(255),
mot_idade int,
vei_id int FOREIGN KEY REFERENCES Veiculo(vei_id) ON DELETE SET NULL
)

insert Motorista(mot_nome, mot_idade, vei_id) values ('Carlos', '18', 1)
select * from Motorista

create table TiposDeCombustivel(
Tipo_id int primary key identity(1,1),
Tipo_nome varchar(255),
Tipo_valor float,
pos_id int FOREIGN KEY REFERENCES Posto(pos_id) ON DELETE CASCADE
)

insert TiposDeCombustivel(Tipo_nome, Tipo_valor,pos_id) values ('Gasolina', 6, 2)
select * from TiposDeCombustivel