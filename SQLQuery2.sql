CREATE DATABASE TRMSDB
USE TRMSDB

CREATE TABLE TblLogin(
l_id		int primary key identity(1,1),
UserName	varchar(20) not null,
userPassword	nvarchar(20) not null,
UserType		varchar(20)
)

CREATE TABLE TblEmployee(
empId		int primary key identity(101,1),
firstName	varchar(20),
lastName	varchar(20),
age			int,
gender		varchar(10),
address		nvarchar(50),
phoneNumber	int,
l_id		int foreign key references TblLogin(l_id)
)

CREATE TABLE TblRequest(
requestId		int primary key identity(1,1),
causeTravel	varchar(100),
source		varchar(100),
destination	varchar(100),
mode		varchar(100),
fromDate	Date,
toDate		Date,
noOfDays	int,
priority	varchar(20),
projectId	int foreign key references TblProject(projectId),
empId		int foreign key references TblEmployee(empId),
status		varchar(20),
)

CREATE TABLE TblProject(
projectId		int primary key identity(101,1),
projectName		varchar(100)
)

select * from TblLogin
select * from TblEmployee
select * from TblRequest
select * from TblProject