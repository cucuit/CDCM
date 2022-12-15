using CDCM.DataAccess;
using CDCM.Domain.DTO;
using CDCM.Domain.Models;
using CDCM.Models;
using System.Text.Json;
using System.Linq;

namespace CDCM.Api.APIs;

public static class CollectorClientAPI
{
    public static void ConfigureCollectorClientAPI(this WebApplication app)
    {
        app.MapGet("/CollectorClient", GetCollectorClients);
        app.MapGet("/CollectorClient/{id}", GetCollectorClient);
        app.MapGet("/CollectorClient/GetByHash/{Hash}", GetCollectorClientByHash);
        app.MapPost("/CollectorClient", InsertCollectorClient);
        app.MapPost("/CollectorClient/WentOffLine/{id}", WentOffLine);
        app.MapPut("/CollectorClient", UpdateCollectorClient);
        app.MapDelete("/CollectorClient/{id}", DeleteCollectorClient);
    }


    private static async Task<IResult> GetCollectorClientByHash(ICollectorClientData _data, string hash)
    {
        try
        {
            var client = await _data.GetCollectorClientByHash(hash);
            await _data.IsAlive(client.Id);
            return Results.Ok(client);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> WentOffLine(ICollectorClientData _Clientdata, IConnectorConfigData _connectorsConfigData, int id)
    {
        var myClient = await _Clientdata.GetCollectorClient(id);
        if (myClient.FailOverTo == null) return Results.Ok("This Client was not seted up with HA");

        IEnumerable<ConnectorConfigUpdateDTO>? myConfigs = await _connectorsConfigData.GetConnectorConfigsByIdClient(id);

        //set idFailedOverFrom with the original collector Id to know where to come back when the collector is back online
        myConfigs.Select(c => { c.idFailedOverFrom = id; return c; }).ToList();
        myConfigs.Select(c => { c.IdCollector = myClient.FailOverTo.Id; return c; }).ToList();

        //Get the new collector to put the connectors
        var backupClient = await _Clientdata.GetCollectorClient(myClient.FailOverTo.Id);

        _connectorsConfigData.FailConnectorsConfig(myConfigs);

        return Results.Ok();
    }

    private static async Task<IResult> DeleteCollectorClient(ICollectorClientData _data, int id)
    {
        try
        {
            return Results.Ok(await _data.DeleteCollectorClient(id));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCollectorClient(ICollectorClientData _data, CollectorClientPutDTO clientDTO)
    {
        try
        {
            CollectorClient client = new CollectorClient()
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                Description = clientDTO.Description,
                IpAddress = clientDTO.IpAddress,
                LastPing = DateTime.Now,
                FailOverTo = new CollectorClient() { Id = clientDTO.IdFailOverTo }
            };
            return Results.Ok(await _data.UpdateCollectorClient(client));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertCollectorClient(ICollectorClientData _data, CollectorClientPostDTO clientDTO)
    {
        try
        {
            var clientvalidation = await _data.GetCollectorClientByHash(clientDTO.Hash);
            if (clientvalidation == null)
            {
                return Results.BadRequest();
            }

            CollectorClient client = new CollectorClient()
            {
                Name = clientDTO.Name,
                Description = clientDTO.Description,
                IpAddress = clientDTO.IpAddress,
                Version = "1",
                FailOverTo = new CollectorClient() { Id = clientDTO.IdFailOverTo },
                LastPing = DateTime.Now,
                Hash = clientDTO.Hash
            };
            return Results.Ok(await _data.InsertCollectorClient(client));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetCollectorClient(ICollectorClientData _data, int id)
    {
        try
        {
            await _data.IsAlive(id);
            return Results.Ok(await _data.GetCollectorClient(id));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> GetCollectorClients(ICollectorClientData _data)
    {
        try
        {
            return Results.Ok(await _data.GetCollectorClients());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


}
