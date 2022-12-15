CREATE TABLE [dbo].[ConnectorConfig]
(
    [idConnector] INT NOT NULL, 
    [idCollector] INT NOT NULL, 
    [Configuration] VARCHAR(MAX) NULL, 
    [idFailedOverFrom] INT NULL, 
    [Version] VARCHAR(50) NULL, 
    [Id] INT NOT NULL identity (1,1), 
    CONSTRAINT [PK_ConnectorConfig] PRIMARY KEY ([Id])
)
