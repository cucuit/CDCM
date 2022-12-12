﻿namespace CDCM.Domain.Models
{
    public class ConnectorConfig
    {
        public Connector Connector { get; set; }
        public CollectorClient Collector { get; set; }
        public string Configuration { get; set; }
        public string Version { get; set; }
        public CollectorClient FailOverFrom { get; set; }
    }
}