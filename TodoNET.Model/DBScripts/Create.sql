/*** Create Script ***/

CREATE DATABASE Todo
GO
USE Todo
GO


CREATE TABLE Projects (
	[ProjectId] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Project PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(300)
)
GO

CREATE TABLE Items (
	[ItemId] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Item PRIMARY KEY,
	[ProjectId] INT NOT NULL CONSTRAINT FK_Item_Project FOREIGN KEY REFERENCES Projects(ProjectId),
	[Summary] NVARCHAR(100) NOT NULL,
	[Detail] NVARCHAR(300),
	CompletedDate DateTime
)
GO

-- Membership
CREATE TABLE Users
(
	UserId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_User PRIMARY KEY,
	UserName nvarchar(50) NOT NULL CONSTRAINT UQ_Users_UserName UNIQUE,
	Email nvarchar(100) NOT NULL CONSTRAINT UQ_Users_Email UNIQUE,
	Password nvarchar(50) NOT NULL
)
GO

CREATE TABLE Roles 
(
    RoleId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Role PRIMARY KEY,
    Name nvarchar(50) NOT NULL CONSTRAINT UQ_Roles_Name UNIQUE
)
GO

CREATE TABLE UserRoles (
    UserId int NOT NULL CONSTRAINT FK_UserRole FOREIGN KEY REFERENCES Users(UserId),
    RoleId int NOT NULL CONSTRAINT FK_RoleUser FOREIGN KEY REFERENCES Roles(RoleId),
    CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId)
)	
GO

-- Test Membership Data
INSERT INTO Roles(name) VALUES('Admin')
INSERT INTO Roles(name) VALUES('Member')
GO

INSERT INTO Users(UserName, Email, Password) VALUES('admin', 'admin@christattum.co.uk', 'adminpass123')
INSERT INTO Users(UserName, Email, Password) VALUES('chris', 'mail@christattum.co.uk', 'chrispass123')

-- One user in Admin role
INSERT INTO UserRoles(RoleId, UserId) VALUES(1, 1) -- admin

-- One user is in Member role
INSERT INTO UserRoles(RoleId, UserId) VALUES(2, 2) -- chris


-- Test Project Data
INSERT INTO Projects([Name], [Description]) 
	VALUES('Test', 'Test Project')
GO

INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Set up Mercurial')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install NHibernate')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Hookup Castle')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Add tests')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Home Page')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Test Data')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Render index page')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install SQL Server')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Setup IIS')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Find Hosting company')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Set up Mercurial2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install NHibernate2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Hookup Castle2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Add tests2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Home Page2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Test Data2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Render index page2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install SQL Server2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Setup IIS2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Find Hosting company2')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Set up Mercurial3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install NHibernate3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Hookup Castle3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Add tests3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Home Page3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Test Data3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Render index page3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install SQL Server3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Setup IIS3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Find Hosting company3')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Set up Mercurial4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install NHibernate4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Hookup Castle4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Add tests4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Home Page4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Test Data4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Render index page4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Install SQL Server4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Setup IIS4')
INSERT INTO Items([ProjectId], [Summary]) VALUES(1, 'Find Hosting company4')

GO

















