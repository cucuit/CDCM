using CDCM.DataAccess;
using CDCM.Domain.Models;
using CDCM.Models;
using System.Text.Json;

namespace CDCM.APIs
{
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


        private static async Task<IResult> UpdateCollectorClient(ICollectorClientData _data, CollectorClient client)
        {
            try
            {
                return Results.Ok(await _data.UpdateCollectorClient(client));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertCollectorClient(ICollectorClientData _data, CollectorClient client)
        {
            try
            {
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
}