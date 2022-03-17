CREATE TABLE [dbo].[T_Car_Milage_Logs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CarId] INT NOT NULL, 
    [milage] INT NOT NULL, 
    [i_date] DATE NOT NULL DEFAULT NOW()
)
