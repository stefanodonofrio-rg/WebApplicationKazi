namespace WebApplicationKazim.Interfaces;

public interface IMonitoredEntity
{
    public Guid Id { get; }
    
    public string Name { get; }

    public int Value { get; }
}