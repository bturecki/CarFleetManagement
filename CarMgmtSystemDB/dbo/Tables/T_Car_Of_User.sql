CREATE TABLE [dbo].[T_Car_Of_User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] INT NOT NULL, 
    [car_id] INT NOT NULL, 
    CONSTRAINT [FK_T_Car_Of_User_T_User] FOREIGN KEY (user_id) REFERENCES T_User(Id),
    CONSTRAINT [FK_T_Car_Of_User_T_Car] FOREIGN KEY (car_id) REFERENCES T_Car(Id)
)
