using System.Data.SqlClient;
using CDCM.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;


namespace CDCM.DataAccess;

public class ConnectorData : IConnectorData
{
    private readonly IConfiguration _configuration;

    public ConnectorData(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Connector> GetConnector(int id)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.Connectors
                        where id = {id}";
            var category = await connection.QueryAsync<Connector>(sql);

            return category.FirstOrDefault();
        }
    }
    public async Task<IEnumerable<Connector>> GetConnectors()
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.Connectors";
            var category = await connection.QueryAsync<Connector>(sql);

            return category;
        }
    }
}

