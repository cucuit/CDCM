using System.Data.SqlClient;
using CDCM.Domain.DTO;
using CDCM.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;


namespace CDCM.DataAccess;

public class ConnectorConfigData : IConnectorConfigData
{
    private readonly IConfiguration _configuration;

    public ConnectorConfigData(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<ConnectorConfig> GetConnectorConfig(ConnectorConfigDTO connectorConfig)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.ConnectorConfig
                        where   idConnector = {connectorConfig.IdConnector} and 
                                idCollector = {connectorConfig.IdCollector}";
            var result = await connection.QueryAsync<ConnectorConfig>(sql);
            return result.FirstOrDefault();
        }
    }
    public async Task<IEnumerable<ConnectorConfig>> GetConnectorConfigs()
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.ConnectorConfig";
            IEnumerable<ConnectorConfig>? connectorConfig = await connection.QueryAsync<ConnectorConfig>(sql);
            var returnList = new List<ConnectorConfig>();
            foreach (var connectorConfigDTO in connectorConfig)
            {
                returnList.Add(new ConnectorConfig()
                {
                    Collector = new CollectorClient() { Id = connectorConfigDTO.Collector.Id },
                    Connector = new Connector() { Id = connectorConfigDTO.Connector.Id },
                    FailOverFrom = new CollectorClient() { Id = connectorConfigDTO.FailOverFrom.Id },
                    Configuration = connectorConfigDTO.Configuration,
                    Version = connectorConfigDTO.Version
                });
            }
            return returnList;
        }
    }

    public async Task<int> InsertConnectorConfigt(ConnectorConfig connectorConfig)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"insert into dbo.connectorConfig (idConnector, idCollector, [Configuration],idFailedOverFrom,[Version] ) 
                    values ({connectorConfig.Connector.Id},
                            {connectorConfig.Collector.Id},
                            '{connectorConfig.Configuration}',
                            {connectorConfig.FailOverFrom.Id},
                            '{connectorConfig.Version}') ";
            var i = await connection.ExecuteAsync(sql);
            return i;
        }
    }
    public async Task<int> UpdateConnectorConfig(ConnectorConfig connectorConfig)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Update dbo.ConnectorConfig 
                            set [Configuration]={connectorConfig.Configuration},
                            idFailedOverFrom={connectorConfig.FailOverFrom.Id},
                            version='{connectorConfig.Version}'
                        where idConnector = {connectorConfig.Connector.Id} and 
                            idCollector = {connectorConfig.Collector.Id}";
            var i = await connection.ExecuteAsync(sql);
            return i;
        }
    }
    public async Task<int> DeleteConnectorConfig(ConnectorConfigDTO connectorDeleteModel)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Delete dbo.ConnectorConfig 
                        where   idConnector = {connectorDeleteModel.IdConnector} and 
                                idCollector = {connectorDeleteModel.IdCollector}";
            var i = await connection.ExecuteAsync(sql);
            return i;
        }
    }
}

