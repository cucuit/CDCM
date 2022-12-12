CREATE TABLE [dbo].[Connectors]
(
	[Id] INT NOT NULL PRIMARY KEY identity (1,1), 
    [Name] VARCHAR(50) NULL, 
    [Version] VARCHAR(50) NULL, 
    [Template] VARCHAR(MAX) NULL
)
