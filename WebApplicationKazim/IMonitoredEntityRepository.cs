namespace WebApplicationKazim;

public interface IMonitoredEntityRepository
{
    public MonitoredEntity Get(string id);
    public bool Delete(string id);
    public bool Update(MonitoredEntity updatedEntity);
    public bool Add(MonitoredEntity addedEntity);
}