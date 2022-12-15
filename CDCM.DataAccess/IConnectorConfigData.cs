using CDCM.Domain.DTO;
using CDCM.Domain.Models;

namespace CDCM.DataAccess
{
    public interface IConnectorConfigData
    {
        Task<int> DeleteConnectorConfig(ConnectorConfigDTO connectorDeleteModel);
        Task<ConnectorConfigUpdateDTO> GetConnectorConfig(ConnectorConfigDTO connectorConfig);
        Task<IEnumerable<ConnectorConfigUpdateDTO>> GetConnectorConfigs();
        Task<IEnumerable<ConnectorConfigUpdateDTO>> GetConnectorConfigsByIdClient(int idClient);
        Task<int> InsertConnectorConfigt(ConnectorConfig connectorConfig);
        Task<int> UpdateConnectorConfig(ConnectorConfig connectorConfig);
        Task FailConnectorsConfig(IEnumerable<ConnectorConfigUpdateDTO> myConfigs);
    }
}