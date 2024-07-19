namespace WebApplicationKazim;

public record MonitoredEntity
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }

    public string Value { get; init; }
}