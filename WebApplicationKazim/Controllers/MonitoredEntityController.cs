using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public IEnumerable<MonitoredEntity> Get()
    {
        return new MonitoredEntity[]{};
    }
}