use master;
go

create database PizzaBoxDb;
go

use PizzaBoxDb;
go

create schema Pizza;
go

create table Pizza.Pizza
(
  PizzaId int not null identity(1,1),
  OrderId int not null,
  Crust nvarchar(200) not null,
  Size nvarchar(200) not null,
  [Name] nvarchar(200) not null,
  constraint PK_PizzaId primary key (PizzaId),
  constraint FK_OrderId primary key Pizza.Order(OrderId)
);
create table Pizza.Toppings
(
  PizzaId int not null,
  [Name] nvarchar(200) not null,
  constraint FK_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId)
);
create table Pizza.Order
(
  OrderId int not null identity(1,1),
  UserId int not null,
  StoreId int not null,
  Done BINARY not null,
  dateOrdered DATETIME2 not null,
  constraint PK_OrderId primary key (OrderId),
  constraint FK_UserId primary key Pizza.User(UserId),
  constraint FK_StoreId primary key Pizza.Store(StoreID)
);
create table Pizza.User
(
  UserId int not null identity(1,1),
  name NVARCHAR(200) not null,
  constraint PK_UserId primary key (UserId)
);
create table Pizza.Store
(
  StoreId int not null identity(1,1),
  name NVARCHAR(200) not null
);