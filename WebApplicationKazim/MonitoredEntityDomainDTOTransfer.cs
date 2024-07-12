namespace WebApplicationKazim;

public static class MonitoredEntityDomainDTOTransfer
{
    public static MonitoredEntityDTO DomainToDTOConverter(MonitoredEntity monitoredEntity)
    {
        if (monitoredEntity is null)
        {
            return null;
        }
        return new MonitoredEntityDTO()
        {
            Id = monitoredEntity.Id,
            Name = monitoredEntity.Name,
            Value = monitoredEntity.Value
        };
    }

    public static MonitoredEntity DTOToDomainConverter(MonitoredEntityDTO monitoredEntityDTO)
    {
        return new MonitoredEntity()
        {
            Id = monitoredEntityDTO.Id,
            Name = monitoredEntityDTO.Name,
            Value = monitoredEntityDTO.Value
        };
    }
}