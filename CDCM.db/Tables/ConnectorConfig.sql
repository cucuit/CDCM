CREATE TABLE [dbo].[ConnectorConfig]
(
    [idConnector] INT NOT NULL, 
    [idCollector] INT NOT NULL, 
    [Configuration] VARCHAR(MAX) NULL, 
    [idFailedOverFrom] NCHAR(10) NULL, 
    [Version] VARCHAR(50) NULL, 
    CONSTRAINT [PK_ConnectorConfig] PRIMARY KEY ([idConnector], [idCollector])
)
