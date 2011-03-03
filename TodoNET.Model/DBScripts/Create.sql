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

















