using CDCM.Models;
using System.Text.Json;
using System.IO;

namespace CDCM.APIs
{

    public static class CollectorConfigurationAPI
    {
        public static void ConfigureCollectorConfigurationAPI(this WebApplication app)
        {
            app.MapGet("/CollectorConfig", () =>
            {
                string jsonString = File.ReadAllText("CollectorSettings.json");
                CollectorConfigurationModel obj = JsonSerializer.Deserialize<CollectorConfigurationModel>(jsonString);
                return obj;
            });
        }
    }
}