use master;
go

create database PizzaBoxDb;
go

drop database PizzaBoxDb;
go

use PizzaBoxDb;
go

create schema Pizza;
go

create table Pizza.[User]
(
  UserId int not null identity(1,1),
  name NVARCHAR(200) not null,
  constraint PK_UserId primary key (UserId)
);
drop table Pizza.Store;
go
create table Pizza.Store
(
  StoreId int not null identity(1,1),
  [name] NVARCHAR(200) not null,
  constraint PK_StoreId primary key (StoreId)
);
create table Pizza.[Order]
(
  OrderId int not null identity(1,1),
  UserId int not null,
  StoreId int not null,
  Done BINARY not null,
  dateOrdered DATETIME2 not null,
  constraint PK_OrderId primary key (OrderId),
  constraint FK_UserId foreign key (UserId) REFERENCES Pizza.[User](UserId),
  constraint FK_StoreId foreign key (StoreId) references Pizza.Store(StoreId)
);
create table Pizza.Pizza
(
  PizzaId int not null identity(1,1),
  OrderId int not null,
  Crust nvarchar(200) not null,
  Size nvarchar(200) not null,
  [Name] nvarchar(200) not null,
  constraint PK_PizzaId primary key (PizzaId),
  constraint FK_OrderId foreign key (OrderId) references Pizza.[Order](OrderId)
);
create table Pizza.Toppings
(
  PizzaId int not null,
  [Name] nvarchar(200) not null,
  constraint FK_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId)
);

