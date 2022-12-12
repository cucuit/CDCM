namespace CDCM.Domain.Models
{
    public class CollectorClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }
        public CollectorClient FailOverTo { get; set; }
        public DateTime LastPing { get; set; }
    }
}