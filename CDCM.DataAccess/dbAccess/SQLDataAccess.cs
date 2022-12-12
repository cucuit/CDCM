using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CDCM.DataAccess;

public class SQLDataAccess : ISQLDataAccess
{
    private readonly IConfiguration _configuration;

    public SQLDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        return await connection.QueryAsync<T>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storeProcedure, T parameters, string connectionID = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionID));
        await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
