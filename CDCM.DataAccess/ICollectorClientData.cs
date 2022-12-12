using CDCM.Domain.Models;

namespace CDCM.DataAccess
{
    public interface ICollectorClientData
    {
        Task<int> DeleteCollectorClient(int id);
        Task<CollectorClient> GetCollectorClient(int id);
        Task<IEnumerable<CollectorClient>> GetCollectorClients();
        Task<int> InsertCollectorClient(CollectorClient collectorClient);
        Task<int> UpdateCollectorClient(CollectorClient collectorClient);
    }
}