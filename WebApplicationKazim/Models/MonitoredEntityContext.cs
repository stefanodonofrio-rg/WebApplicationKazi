using Microsoft.EntityFrameworkCore;
using WebApplicationKazim.Interfaces;

namespace WebApplicationKazim.Models;

public class MonitoredEntityContext : DbContext, IMonitoredEntityContext
{
    public DbSet<IMonitoredEntity> MonitoredEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DEV-LT-KAZIMR;Database=MonitoredEntitiesTable");
    }
}