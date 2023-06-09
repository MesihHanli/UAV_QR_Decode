CREATE TABLE [dbo].[Qr]
(
	[GUID] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [PID] INT NOT NULL, 
    [Description] VARCHAR(50) NULL, 
    [Quantity] INT NOT NULL, 
    [Source] INT NULL, 
    [Destinition] INT NOT NULL, 
    [Date] SMALLDATETIME NOT NULL, 
    CONSTRAINT [FK_Qr_ToProduct] FOREIGN KEY (PID) REFERENCES dbo.Product(PID), 
    CONSTRAINT [FK_Qr_ToCitySource] FOREIGN KEY (Source) REFERENCES dbo.City(CID),
    CONSTRAINT [FK_Qr_ToCityDestinition] FOREIGN KEY (Destinition) REFERENCES dbo.City(CID)
)
