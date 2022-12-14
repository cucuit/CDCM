using System.Data.SqlClient;
using System.Dynamic;
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

    public async Task<ConnectorConfigUpdateDTO> GetConnectorConfig(ConnectorConfigDTO connectorConfig)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.ConnectorConfig
                        where   idConnector = {connectorConfig.IdConnector} and 
                                idCollector = {connectorConfig.IdCollector}";
            var result = await connection.QueryAsync<ConnectorConfigUpdateDTO>(sql);
            return result.FirstOrDefault();
        }
    }
    public async Task<IEnumerable<ConnectorConfigUpdateDTO>> GetConnectorConfigs()
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select idConnector, idCollector, [Configuration],idFailedOverFrom,[Version]
                        From dbo.ConnectorConfig";
            
            IEnumerable<ConnectorConfigUpdateDTO> connectorConfig2 = await connection.QueryAsync<ConnectorConfigUpdateDTO>(sql);
            return connectorConfig2;
        }
    }
    public async Task<IEnumerable<ConnectorConfigUpdateDTO>> GetConnectorConfigsByIdClient(int idClient)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select idConnector, idCollector, [Configuration],idFailedOverFrom,c.[Version], c.name
                        From dbo.ConnectorConfig, dbo.Connectors c
                        Where idCollector = {idClient} and idconnector = c.id";
         
            IEnumerable<ConnectorConfigUpdateDTO> connectorConfig2 = await connection.QueryAsync<ConnectorConfigUpdateDTO>(sql);
            return connectorConfig2;
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
                            set [Configuration]='{connectorConfig.Configuration}',
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

