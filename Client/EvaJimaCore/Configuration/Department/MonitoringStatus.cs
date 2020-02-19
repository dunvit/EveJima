
namespace EveJimaCore.Configuration.Department
{
    public class MonitoringStatus
    {
        public string PilotsList => ConfigurationTools.GetConfigOptionalStringValue("Monitoring");

        public bool IsMonitoringEnabled { get; set; } = false;

        public string Message { get; set; } = "";
    }
}
