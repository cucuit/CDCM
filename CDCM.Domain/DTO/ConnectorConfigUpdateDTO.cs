using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCM.Domain.DTO
{
    public class ConnectorConfigUpdateDTO
    {
        public int IdConnector { get; set; }
        public int IdCollector { get; set; }
        public string Configuration { get; set; }
        public string Version { get; set; }
        public int idFailedOverFrom { get; set; }
    }

    public class CollectorClientPostDTO
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }
        public int IdFailOverTo { get; set; }
    }
    public class CollectorClientPutDTO : CollectorClientPostDTO
    {
        public int Id { get; set; }

    }
}

