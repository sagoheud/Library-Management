Create database LibraryManagement;

Use LibraryManagement;


create table Login(
id int NOT NULL IDENTITY(1,1) primary key,
username varchar(50) not null,
pass varchar(50) not null
);
insert into Login(username,pass) values ('admin','1234');
select * from Login


create table NewBook(
bid int NOT NULL IDENTITY(1,1) primary key,
bName varchar(250) not null,
bAuthor varchar(50) not null,
bPublic varchar(50) not null,
bPDate varchar(50) not null,
bPrice float not null,
bQty float not null
);
--bName,bAuthor,bPublic,bPDate,bPrice,bQty
select * from NewBook

-- 테이블 칼럼 속성 변경
ALTER TABLE dbo.NewBook ALTER COLUMN bName VARCHAR(250) NOT NULL


create table NewStudent(
stuid int NOT NULL IDENTITY(1,1) primary key,
stuName varchar(50) not null,
stuEnroll varchar(50) not null,
studepart varchar(50) not null,
stuSem varchar(50) not null,
stuContact float not null,
stuEmail varchar(150) not null
);
--stuName,stuEnroll,studepart,stuSem,stuContact,stuEmail
select * from NewStudent


create table IRBook(
id int NOT NULL IDENTITY(1,1) primary key,
std_enroll varchar(150) not null,
std_name varchar(150) not null,
std_depart varchar(150) not null,
std_sem varchar(150) not null,
std_contact float not null,
std_email varchar(150) not null,
book_name varchar(250) not null,
book_issue_date varchar(150) not null,
book_return_date varchar(150),
);
select * from IRBook
--select * from IRBook where std_enroll = '1234' and book_return_date IS NULL