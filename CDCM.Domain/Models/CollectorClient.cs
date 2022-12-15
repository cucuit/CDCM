using CDCM.Domain.DTO;
using System.Text.Json.Serialization;

namespace CDCM.Domain.Models
{
    public class CollectorClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }
        public int IdFailOverTo { get; set; }
        
        [JsonIgnore]
        public CollectorClient FailOverTo { get; set; }
        public DateTime LastPing { get; set; }
        public List<ConnectorConfigUpdateDTO> Connectors { get; set; } = new List<ConnectorConfigUpdateDTO>();
        public string Hash { get; set; }
    }
}