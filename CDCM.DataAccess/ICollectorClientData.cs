using CDCM.Domain.Models;

namespace CDCM.DataAccess
{
    public interface ICollectorClientData
    {
        Task<int> DeleteCollectorClient(int id);
        Task<CollectorClient> GetCollectorClient(int id);
        Task<IEnumerable<CollectorClient>> GetCollectorClients();
        Task<CollectorClient> InsertCollectorClient(CollectorClient collectorClient);
        Task<CollectorClient> UpdateCollectorClient(CollectorClient collectorClient);
    }
}