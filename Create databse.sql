--Data Definition Language

create database NbgAccountSystem;
go

use NbgAccountSystem
go


create table Account(
	Id int primary key identity(1,1), Balance money , StartDate datetime default getdate()
	);
	
create table AccountCustomer(
	Id int primary key identity(1,1), AccountId int , CustomerId int
	);
	
create table Customer(
	Id int primary key identity(1,1), Name varchar(50) , Address varchar(50) ,
	Email varchar(50) , StartDate datetime default getdate(), IsActive bit default 1
	);
	
create table CustomerStore(
	Id int primary key identity(1,1), StoreId int , CustomerId int
	);
	
create table Artifact(
	Id int primary key identity(1,1), Name varchar(50) , Price money
	);
	
create table [Transaction](
	Id int primary key identity(1,1), Description varchar(50) , TotalAmount money, 
	Type varchar(50), ArtifactId int, AccountId int , CustomerId int, InvoiceId int
	);
	
create table Invoice (
	Id int primary key identity(1,1), Date datetime default getdate(), CustomerId int, EmployeeId int, StoreId int
	);
	
create table Employee(
	Id int primary key identity(1,1), Name varchar(50) , Email varchar(50) , StartDate datetime default getdate(), 
	IsActive bit default 1, ManagerId int, StoreId int
	);
	
create table Store(
	Id int primary key identity(1,1), Name varchar(50), Address varchar(50)
	);
	


---Relationships


 
alter table 	AccountCustomer
add foreign key (CustomerId) references Customer(Id);	
alter table 	AccountCustomer
add foreign key (AccountId) references Account(Id);

alter table 	CustomerStore
add foreign key (StoreId) references Store(Id);
alter table 	CustomerStore
add foreign key (CustomerId) references Customer(Id);


alter table 	[Transaction]
add foreign key (CustomerId) references Customer(Id);	
alter table 	[Transaction]
add foreign key (ArtifactId) references Artifact(Id);	
alter table 	[Transaction]
add foreign key (AccountId) references Account(Id);
alter table 	[Transaction]
add foreign key (InvoiceId) references Invoice(Id);

alter table 	Invoice
add foreign key (CustomerId) references Customer(Id);	
alter table 	Invoice
add foreign key (StoreId) references Store(Id);	
alter table 	Invoice
add foreign key (EmployeeId) references Employee(Id);	


alter table 	Employee
add foreign key (StoreId) references Store(Id);	
alter table 	Employee
add foreign key (ManagerId) references Employee(Id);	
	