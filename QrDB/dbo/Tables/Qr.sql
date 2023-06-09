CREATE TABLE [dbo].[Qr]
(
	[GUID] INT NOT NULL PRIMARY KEY, 
    [PID] INT NOT NULL, 
    [Description] VARCHAR(50) NULL, 
    [Quantity] INT NOT NULL, 
    [From] INT NULL, 
    [To] INT NOT NULL, 
    [Date] SMALLDATETIME NOT NULL
)
