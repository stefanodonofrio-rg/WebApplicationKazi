using Microsoft.EntityFrameworkCore;

namespace WebApplicationKazim.Interfaces;

public interface IMonitoredEntityContext
{
    public DbSet<IMonitoredEntity> MonitoredEntities { get;  }
    
}