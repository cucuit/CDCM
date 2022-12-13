using CDCM.Domain.Models;

namespace CDCM.DataAccess
{
    public interface IConnectorData
    {
        Task<Connector> GetConnector(int id);
        Task<IEnumerable<Connector>> GetConnectors();
    }
}