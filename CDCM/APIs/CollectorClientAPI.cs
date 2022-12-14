using CDCM.DataAccess;
using CDCM.Domain.DTO;
using CDCM.Domain.Models;
using CDCM.Models;
using System.Text.Json;

namespace CDCM.Api.APIs;

public static class CollectorClientAPI
{
    public static void ConfigureCollectorClientAPI(this WebApplication app)
    {
        app.MapGet("/CollectorClient", GetCollectorClients);
        app.MapGet("/CollectorClient/{id}", GetCollectorClient);
        app.MapPost("/CollectorClient", InsertCollectorClient);
        app.MapPut("/CollectorClient", UpdateCollectorClient);
        app.MapDelete("/CollectorClient/{id}", DeleteCollectorClient);
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
                FailOverTo = new CollectorClient() { Id=clientDTO.IdFailOverTo}
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
            CollectorClient client = new CollectorClient()
            {
                Name = clientDTO.Name,
                Description = clientDTO.Description,
                IpAddress = clientDTO.IpAddress,
                Version = "1",
                FailOverTo = new CollectorClient() { Id = clientDTO.IdFailOverTo },
                LastPing = DateTime.Now
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
