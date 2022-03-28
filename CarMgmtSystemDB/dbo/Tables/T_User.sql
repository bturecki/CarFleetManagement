CREATE TABLE [dbo].[T_User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NULL, 
    [surname] NVARCHAR(50) NULL, 
    [DateOfBirth] DATE NULL, 
    [IsAdmin] INT NULL, 
    [Email] NVARCHAR(150) NULL
)
