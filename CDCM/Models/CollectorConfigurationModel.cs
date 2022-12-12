
namespace CDCM.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AppSettings
    {
        public bool ShowDiscoveryWizard { get; set; }
        public TableSettings TableSettings { get; set; }
        public Layout Layout { get; set; }
        public bool IsSeedSetupFirstTime { get; set; }
        public IpToolsetDialogSizes IpToolsetDialogSizes { get; set; }
    }

    public class AWS
    {
        public object SortedColumn { get; set; }
        public bool SortOrder { get; set; }
        public int RecordsPerPage { get; set; }
        public int ColumnFitMode { get; set; }
        public ColumnsWidth ColumnsWidth { get; set; }
    }

    public class AWSInstanceNetworkInterfaceLinks
    {
        public object SortedColumn { get; set; }
        public bool SortOrder { get; set; }
        public int RecordsPerPage { get; set; }
        public int ColumnFitMode { get; set; }
        public ColumnsWidth ColumnsWidth { get; set; }
    }

    public class AWSInstances
    {
        public object SortedColumn { get; set; }
        public bool SortOrder { get; set; }
        public int RecordsPerPage { get; set; }
        public int ColumnFitMode { get; set; }
        public ColumnsWidth ColumnsWidth { get; set; }
    }

    public class AWSInstanceVolumeLinks
    {
        public object SortedColumn { get; set; }
        public bool SortOrder { get; set; }
        public int RecordsPerPage { get; set; }
        public int ColumnFitMode { get; set; }
        public ColumnsWidth ColumnsWidth { get; set; }
    }

    public class AWSNetworkInterfaces
    {
        public object SortedColumn { get; set; }
        public bool SortOrder { get; set; }
        public int RecordsPerPage { get; set; }
        public int ColumnFitMode { get; set; }
        public ColumnsWidth ColumnsWidth { get; set; }
    }

    public class AWSVolumes
    {
        public object SortedColumn { get; set; }
        public bool SortOrder { get; set; }
        public int RecordsPerPage { get; set; }
        public int ColumnFitMode { get; set; }
        public ColumnsWidth ColumnsWidth { get; set; }
    }

    public class ColumnsWidth
    {
        public int Account { get; set; }
        public int Region { get; set; }
        public int Attachments { get; set; }
        public int AvailabilityZone { get; set; }
        public int CreateTime { get; set; }
        public int Encrypted { get; set; }
        public int FastRestored { get; set; }
        public int Iops { get; set; }
        public int KmsKeyId { get; set; }
        public int MultiAttachEnabled { get; set; }
        public int OutpostArn { get; set; }
        public int Size { get; set; }
        public int SnapshotId { get; set; }
        public int State { get; set; }
        public int Tags { get; set; }
        public int Throughput { get; set; }
        public int VolumeId { get; set; }
        public int VolumeType { get; set; }
        public int ntObjectStatus { get; set; }
    }

    public class Data
    {
        public DiscoverySettings discoverySettings { get; set; }
        public UploadSettings uploadSettings { get; set; }
        public AppSettings appSettings { get; set; }
        public PollSettings pollSettings { get; set; }
        public LogSettings logSettings { get; set; }
        public SkinSettings skinSettings { get; set; }
        public LanguageSettings languageSettings { get; set; }
        public TrapListenerSettings trapListenerSettings { get; set; }
    }

    public class Discovery
    {
        public int Cycle { get; set; }
        public int Retries { get; set; }
        public int SnmpTimeout { get; set; }
        public int PingTimeout { get; set; }
        public bool Enabled { get; set; }
    }

    public class DiscoverySettings
    {
        public string ConnectorData { get; set; }
        public object LanDiscoverySettings { get; set; }
    }

    public class IpToolsetDialogSizes
    {
        public PING PING { get; set; }
    }

    public class LanguageSettings
    {
        public int LanguageId { get; set; }
    }

    public class Layout
    {
        public bool IsMaximized { get; set; }
        public string WinRect { get; set; }
        public int LeftSplitter { get; set; }
        public int TopSplitter { get; set; }
    }

    public class LogSettings
    {
        public int LogLevel { get; set; }
        public int LogLifeTimeType { get; set; }
    }

    public class PING
    {
        public object Size { get; set; }
    }

    public class Ping2
    {
        public int Cycle { get; set; }
        public int Retries { get; set; }
        public int SnmpTimeout { get; set; }
        public int PingTimeout { get; set; }
        public bool Enabled { get; set; }
    }

    public class Pollers
    {
        public Discovery Discovery { get; set; }
        public PING Ping { get; set; }
    }

    public class PollSettings
    {
        public Pollers Pollers { get; set; }
    }

    public class ProxyData
    {
        public bool Manual { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
    }

    public class CollectorConfigurationModel
    {
        public string version { get; set; }
        public string dataType { get; set; }
        public string description { get; set; }
        public Data data { get; set; }
    }

    public class SkinSettings
    {
        public string SelectedSkinFileName { get; set; }
    }

    public class TableSettings
    {
        public AWS AWS_ { get; set; }
        public AWSInstances AWS_Instances { get; set; }
        public AWSInstanceVolumeLinks AWS_InstanceVolumeLinks { get; set; }
        public AWSVolumes AWS_Volumes { get; set; }
        public AWSNetworkInterfaces AWS_NetworkInterfaces { get; set; }
        public AWSInstanceNetworkInterfaceLinks AWS_InstanceNetworkInterfaceLinks { get; set; }
    }

    public class TrapListenerSettings
    {
        public bool RunOnApplicationStart { get; set; }
    }

    public class UploadSettings
    {
        public string AgentName { get; set; }
        public long NtDiagramId { get; set; }
        public string NtConnectorType { get; set; }
        public string NtContainerType { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool AutoRefreshEnabled { get; set; }
        public int AutoRefreshPeriod { get; set; }
        public ProxyData ProxyData { get; set; }
    }

}