using System.Data.SqlClient;
using CDCM.Domain.DTO;
using CDCM.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;


namespace CDCM.DataAccess;

public class CollectorClientData : ICollectorClientData
{
    private readonly IConfiguration _configuration;
    private readonly IConnectorConfigData _connectorConfigData;

    public CollectorClientData(IConfiguration configuration, IConnectorConfigData connectorConfigData)
    {
        _configuration = configuration;
        _connectorConfigData = connectorConfigData;
    }

    public async Task<CollectorClient> GetCollectorClient(int id)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.CollectorClient
                        where id = {id}";
            var queryResult = await connection.QueryAsync<CollectorClient>(sql);
            var client = queryResult.First();

            var clientCnnectors = await _connectorConfigData.GetConnectorConfigsByIdClient(id);

            client.Connectors.AddRange(clientCnnectors);

            return client;
        }
    }
    public async Task<IEnumerable<CollectorClient>> GetCollectorClients()
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.CollectorClient";
            var clients = await connection.QueryAsync<CollectorClient>(sql);

            foreach (var client in clients)
            {
                var clientCnnectors = await _connectorConfigData.GetConnectorConfigsByIdClient(client.Id);
                client.Connectors.AddRange(clientCnnectors);
            }

            return clients;
        }
    }

    public async Task<CollectorClient> InsertCollectorClient(CollectorClient collectorClient)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"insert into dbo.CollectorClient ([name], [IpAddress], Description)
                            values ('{collectorClient.Name}',
                                    '{collectorClient.IpAddress}',
                                    '{collectorClient.Description}') ";

            var i = await connection.ExecuteAsync(sql);

            sql = @$"Select top 1 *
                        From dbo.CollectorClient
                        order by id desc;";

            return connection.QueryAsync<CollectorClient>(sql).Result.FirstOrDefault();
        }
    }
    public async Task<CollectorClient> UpdateCollectorClient(CollectorClient collectorClient)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Update dbo.CollectorClient set [name]='{collectorClient.Name}',
                            IpAddress='{collectorClient.IpAddress}',
                            Description='{collectorClient.Description}',
                            Version='{collectorClient.Version}',
                            IdFailOverTo={collectorClient.FailOverTo.Id}
                        where id = {collectorClient.Id} ";

            var i = await connection.ExecuteAsync(sql);

            sql = @$"Select top 1 *
                        From dbo.CollectorClient
                        where id = {collectorClient.Id};";

            return connection.QueryAsync<CollectorClient>(sql).Result.FirstOrDefault();
        }
    }
    public async Task<int> DeleteCollectorClient(int id)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Delete dbo.CollectorClient where id={id}";
            var i = await connection.ExecuteAsync(sql);

            return i;
        }
    }

}

