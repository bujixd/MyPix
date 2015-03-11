CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [full_name] NVARCHAR(50) NOT NULL, 
    [user_name] NVARCHAR(30) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(20) NOT NULL, 
    [user_profile] IMAGE NULL, 
    [visually_impaired] BIT NULL, 
    [confirmed] BIT NOT NULL, 
    [WhenRegistered] DATETIME NOT NULL, 
    [WhenConfirmed] DATETIME NOT NULL
)
