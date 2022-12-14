using CDCM.DataAccess;
using CDCM.Domain.DTO;
using CDCM.Domain.Models;

namespace CDCM.Api.APIs;

public static class ConnectorConfigAPI
{
    public static void ConfigureConnectorConfigAPI(this WebApplication app)
    {
        app.MapGet("/ConnectorConfig", GetConnectorConfigs);
        app.MapGet("/ConnectorConfig/{idCollector}/{idConnector}", GetConnectorConfig);
        app.MapPost("/ConnectorConfig", InsertConnectorConfig);
        app.MapPut("/ConnectorConfig", UpdateCollectorClient);
        app.MapDelete("/ConnectorConfig/{idCollector}/{idConnector}", DeleteCollectorClient);
    }

    public static async Task<IResult> GetConnectorConfigs(IConnectorConfigData _data)
    {
        try
        {
            return Results.Ok(await _data.GetConnectorConfigs());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetConnectorConfig(IConnectorConfigData _data, int idCollector, int idConnector)
    {
        try
        {
            return Results.Ok(await _data.GetConnectorConfig(new ConnectorConfigDTO 
            { IdCollector = idCollector, IdConnector = idConnector }));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCollectorClient(IConnectorConfigData _data, int idCollector, int idConnector)
    {
        try
        {
            return Results.Ok(await _data.DeleteConnectorConfig(new ConnectorConfigDTO
            { IdCollector = idCollector, IdConnector = idConnector }));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCollectorClient(IConnectorConfigData _data, ConnectorConfigUpdateDTO connectorConfig)
    {
        try
        {
            return Results.Ok(await _data.UpdateConnectorConfig(new ConnectorConfig
            {
                Collector = new CollectorClient() { Id = connectorConfig.IdCollector },
                Connector = new Connector() { Id = connectorConfig.IdConnector },
                //Configuration = connectorConfig.Configuration,
                FailOverFrom = new CollectorClient() { Id = connectorConfig.idFailedOverFrom },
                Version = connectorConfig.Version
            }));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertConnectorConfig(IConnectorConfigData _data, ConnectorConfigUpdateDTO connectorConfig)
    {
        try
        {
            return Results.Ok(await _data.InsertConnectorConfigt(new ConnectorConfig
            {
                Collector = new CollectorClient() { Id = connectorConfig.IdCollector },
                Connector = new Connector() { Id = connectorConfig.IdConnector },
                //Configuration = connectorConfig.Configuration,
                FailOverFrom = new CollectorClient() { Id = connectorConfig.idFailedOverFrom },
                Version = connectorConfig.Version
            }));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    

}
