CREATE TABLE Roles
(
RolId int not null primary key
,RolName nvarchar(max)
,RolDescription nvarchar(max)
)

CREATE TABLE Users
(
UserId int not null primary key
,UserName nvarchar(max)
,Pass varbinary(max)
,RolId int foreign key references Roles(RolId)
)
drop table ErrorLog
create table ErrorLog
(
	ErrorLogId int not null primary key identity
	internalException nvarchar(max)
	,errorMessage nvarchar(max)
	,browser nvarchar(max)
	,stackTrace nvarchar(max)
	,errorType nvarchar(max)
	,sessionKeys nvarchar (max)
	,errorTimeStamp nvarchar(max)
)