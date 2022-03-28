﻿CREATE TABLE [dbo].[T_Car_Of_User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [CarId] INT NOT NULL, 
    CONSTRAINT [FK_T_Car_Of_User_T_User] FOREIGN KEY ([UserId]) REFERENCES T_User([UserId]),
    CONSTRAINT [FK_T_Car_Of_User_T_Car] FOREIGN KEY ([CarId]) REFERENCES T_Car([CarId])
)
