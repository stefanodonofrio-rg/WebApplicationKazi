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
    private IMonitoredEntityRepository _MonitoredEntityRepository;

    public MonitoredEntityController(ILogger<MonitoredEntityController> logger, IMonitoredEntityRepository monitoredEntityRepository)
    {
        _logger = logger;
        _MonitoredEntityRepository = monitoredEntityRepository;
    }

    [HttpGet]
    public MonitoredEntity Get(string id)
    {
        return _MonitoredEntityRepository.Get(id);
    }

    [HttpDelete]
    public bool Delete(string id)
    {
        return _MonitoredEntityRepository.Delete(id);
    }
    [HttpPut]
    public bool Update(MonitoredEntity monitoredEntity)
    {
       return _MonitoredEntityRepository.Update(monitoredEntity);
    }
    [HttpPost]
    public bool Add(MonitoredEntity monitoredEntity)
    {
        return _MonitoredEntityRepository.Add(monitoredEntity);
    }
}