namespace WebApplicationKazim;

public record MonitoredEntityDTO
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }

    public string Value { get; init; }
}