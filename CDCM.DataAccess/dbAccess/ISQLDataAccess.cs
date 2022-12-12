
namespace CDCM.DataAccess
{
    public interface ISQLDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters, string connectionID = "Default");

        Task SaveData<T>(string storeProcedure, T parameters, string connectionID = "Default");

    }
}