namespace WebApplicationKazim;

public class MonitoredEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string Value { get; set; }

    public MonitoredEntity(Guid id = default(Guid), string name = "", string value = "")
    {
        Id = id;
        Name = name;
        Value = value;
    }
}