create database livraria;
use livraria;
show tables;

create table tb_livro(
	id_livro int primary key auto_increment,
    nome varchar(100),
    autor varchar(100),
    linguagem varchar(30),
    preco decimal(15,2),
    disponivel bool,
    publicado date
);

create table tb_cliente(
	id_cliente int primary key auto_increment,
    nome varchar(100),
    nascimento date,
    telefone varchar(20),
    email varchar(50)
);

create table tb_funcionario(
	id_funcionario int primary key auto_increment,
    nome varchar(100),
    nascimento date,
    telefone varchar(20),
    endereco varchar(30),
    email varchar(50),
    salario decimal(15,2)
);

create table tb_livro_cliente(
	id_livro_cliente int primary key auto_increment,
    id_livro int,
    id_cliente int,
    data_compra date,
    foreign key(id_livro) references tb_livro (id_livro),
    foreign key (id_cliente) references tb_cliente (id_cliente)
);

select * from tb_cliente;
select * from tb_funcionario;
select * from tb_livro_cliente;
select * from tb_funcionario;

insert into tb_livro(nome,autor,linguagem,preco,disponivel,publicado)
values('Harry Potter','Michael Owen','Ingles',140.90,true,'2014-01-1');

insert into tb_cliente(nome,nascimento,telefone,email)
values('Bruno Gomes','2001-01-11','13932451234','bruno@gmail.com');

insert into tb_funcionario(nome,nascimento,telefone,endereco,email,salario)
values('Gabriel Gomes','2000-10-01','11932441234','rua lisboa lodon','gabriel@gmail.com',1200);

insert into tb_livro_cliente(id_livro,id_cliente,data_compra)
values(1,1,'2019-02-10');