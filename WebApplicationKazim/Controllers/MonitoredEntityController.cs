using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace WebApplicationKazim.Controllers;

[ApiController]
[Route("[controller]")]
public class MonitoredEntityController : ControllerBase
{
    private readonly ILogger<MonitoredEntityController> _logger;
    private DatabaseOperator _databaseFunctionality;

    public MonitoredEntityController(ILogger<MonitoredEntityController> logger)
    {
        _logger = logger;
        DatabaseConnector();
    }

    private void DatabaseConnector()
    {
        _databaseFunctionality = new();
    }

    [HttpGet]
    public MonitoredEntity Get(string id)
    {
        return _databaseFunctionality.Get(id);
    }

    [HttpDelete]
    public bool Delete(Guid id)
    {
        return _databaseFunctionality.Delete(id);
    }
    [HttpPut]
    public bool Update(Guid id, string name, string value)
    {
       return _databaseFunctionality.Update(new MonitoredEntity(id, name, value));
    }
    [HttpPost]
    public bool Add(Guid id, string name, string value)
    {
        return _databaseFunctionality.Add(new MonitoredEntity(id, name, value));
    }
}