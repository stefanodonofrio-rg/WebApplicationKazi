namespace WebApplicationKazim;

public record MonitoredEntityData
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }

    public string Value { get; init; }
}