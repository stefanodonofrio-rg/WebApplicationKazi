using WebApplicationKazim.Interfaces;

namespace WebApplicationKazim;

public class MonitoredEntity : IMonitoredEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public int Value { get; set; }
}