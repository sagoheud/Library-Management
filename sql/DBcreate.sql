Create database LibraryManagement;

Use LibraryManagement;


create table Login(
id int NOT NULL IDENTITY(1,1) primary key,
username varchar(50) not null,
pass varchar(50) not null
)
insert into Login(username,pass) values ('admin','1234');
select * from Login


create table NewBook(
bid int NOT NULL IDENTITY(1,1) primary key,
bName varchar(150) not null,
bAuthor varchar(50) not null,
bPublic varchar(50) not null,
bPDate varchar(50) not null,
bPrice float not null,
bQty float not null
)
--bName,bAuthor,bPublic,bPDate,bPrice,bQty
select * from NewBook


create table NewStudent(
stuid int NOT NULL IDENTITY(1,1) primary key,
stuName varchar(50) not null,
stuEnroll varchar(50) not null,
studepart varchar(50) not null,
stuSem varchar(50) not null,
stuContact float not null,
stuEmail varchar(150) not null
)
--stuName,stuEnroll,studepart,stuSem,stuContact,stuEmail
select * from NewStudent