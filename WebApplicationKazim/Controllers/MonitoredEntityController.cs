using System.Data;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebApplicationKazim.Controllers;

[ApiController]
[Route("[controller]")]
public class MonitoredEntityController : ControllerBase
{
    private readonly ILogger<MonitoredEntityController> _logger;

    public MonitoredEntityController(ILogger<MonitoredEntityController> logger)
    {
        _logger = logger;
    }

    private void DatabaseConnector()
    {
        string connectionString = "Server=DEV-LT-KAZIMR"
        using var dbConnection;
        
    }

    private IDbConnection DatabaseConnection()
    {
        return DbTyp
    }

    [HttpGet]
    public IEnumerable<MonitoredEntity> Get()
    {
        return new MonitoredEntity[]{};
    }

    [HttpDelete]
    public void Delete(Guid valToDelete)
    {
        
    }
}