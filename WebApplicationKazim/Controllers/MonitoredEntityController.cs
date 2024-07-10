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
    public MonitoredEntityDTO Get(string id)
    {
        return MonitoredEntityDomainDTOTransfer.DomainToDTOConverter(_MonitoredEntityRepository.Get(id));
    }

    [HttpDelete]
    public bool Delete(string id)
    {
        return _MonitoredEntityRepository.Delete(id);
    }
    [HttpPut]
    public bool Update(MonitoredEntityDTO monitoredEntityDto)
    {
       return _MonitoredEntityRepository.Update(MonitoredEntityDomainDTOTransfer.DTOToDomainConverter(monitoredEntityDto));
    }
    [HttpPost]
    public bool Add(MonitoredEntityDTO monitoredEntityDto)
    {
        return _MonitoredEntityRepository.Add(MonitoredEntityDomainDTOTransfer.DTOToDomainConverter(monitoredEntityDto));
    }
}