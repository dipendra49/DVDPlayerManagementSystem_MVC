CREATE TABLE [User]
(
UserNumber BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL
,UserName VARCHAR(250)
,UserType VARCHAR(250)
,UserPassword NVARCHAR(500)
)