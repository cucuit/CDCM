CREATE TABLE [dbo].[CollectorClient]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),  
    [Name] VARCHAR(50) NULL, 
    [Version] VARCHAR(50) NULL, 
    [IpAddress] VARCHAR(50) NULL, 
    [Description] VARCHAR(50) NULL, 
    [IdFailOverTo] INT NULL DEFAULT 0, 
    [LastPing] DATETIME2 NULL DEFAULT GetDate(), 
    [Hash] VARCHAR(MAX) NULL
)
