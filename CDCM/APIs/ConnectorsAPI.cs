using CDCM.DataAccess;

namespace CDCM.APIs
{
    public static class ConnectorsAPI
    {
        public static void ConfigureConnectorsAPI(this WebApplication app)
        {
            app.MapGet("/Connectors", GetConnectors);
            app.MapGet("/Connectors/{id}", GetConnector);
        }

        private static async Task<IResult> GetConnector(IConnectorData _data, int id)
        {
            try
            {
                return Results.Ok(await _data.GetConnector(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> GetConnectors(IConnectorData _data)
        {
            try
            {
                return Results.Ok(await _data.GetConnectors());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}