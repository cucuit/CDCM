using System.Data.SqlClient;
using CDCM.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;


namespace CDCM.DataAccess;

public partial class CollectorClientData : ICollectorClientData
{
    private readonly IConfiguration _configuration;

    public CollectorClientData(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<CollectorClient> GetCollectorClient(int id)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.CollectorClient
                        where id = {id}";
            var category = await connection.QueryAsync<CollectorClient>(sql);

            return category.FirstOrDefault();
        }
    }
    public async Task<IEnumerable<CollectorClient>> GetCollectorClients()
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Select *
                        From dbo.CollectorClient";
            var category = await connection.QueryAsync<CollectorClient>(sql);

            return category;
        }
    }

    public async Task<int> InsertCollectorClient(CollectorClient collectorClient)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"insert into dbo.CollectorClient ([name], [IpAddress], Description) values ('{collectorClient.Name}', '{collectorClient.IpAddress}','{collectorClient.Description}') ";
            var i = await connection.ExecuteAsync(sql);

            return i;
        }
    }
    public async Task<int> UpdateCollectorClient(CollectorClient collectorClient)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sql = @$"Update dbo.CollectorClient set [name]={collectorClient.Name}, IpAddress={collectorClient.IpAddress}, Description={collectorClient.Description}, Version={collectorClient.Version}, IdFailOverTo={collectorClient.FailOverTo.Id} where id = {collectorClient.Id} ";
            var i = await connection.ExecuteAsync(sql);

            return i;
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

