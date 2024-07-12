using FluentAssertions;
using WebApplicationKazim;
using WebApplicationKazim.Controllers;

namespace WebApplicationUnitTests;

public class MonitoredEntityControllerTests
{
    private static readonly Guid _guidOne = Guid.NewGuid();
    private static readonly Guid _guidTwo = Guid.NewGuid();
    public class TestMonitoredEntityRepository : IMonitoredEntityRepository
    {
        private IList<MonitoredEntity> _repositoryInMemory = new List<MonitoredEntity>()
        {
            new()
            {
                Id = _guidOne,
                Name = "Kazim",
                Value = "55"
            },
            new()
            {
                Id = _guidTwo,
                Name = "KAZIM",
                Value = "20"
            }
        };
        public MonitoredEntity Get(string id)
        {
            MonitoredEntity valueToReturn = null;
            try
            {
                valueToReturn = _repositoryInMemory.Single(x => x.Id.ToString() == id);
            }
            catch (Exception e)
            {
                // Does not exist.
            }

            return valueToReturn;

        }

        public bool Delete(string id)
        {
            try
            {
                _repositoryInMemory.Remove(Get(id));
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Update(MonitoredEntity updatedEntity)
        {
            var oldEntity = Get(updatedEntity.Id.ToString());
            var newEntity = new MonitoredEntity()
            {
                Id = oldEntity.Id,
                Name = updatedEntity.Name,
                Value = updatedEntity.Value
            };
            Delete(oldEntity.Id.ToString());
            Add(newEntity);
            return true;
        }

        public bool Add(MonitoredEntity addedEntity)
        {
            if (addedEntity is not null)
            {
                if (Get(addedEntity.Id.ToString()) is null)
                {
                    _repositoryInMemory.Add(addedEntity);
                    return true;
                }
            }
            return false;
        }
    }

    [Test]
    public void GetReturnsTheExpectedResult()
    {
        var monitoredEntityRepository = new TestMonitoredEntityRepository();
        var monitoredEntityController = new MonitoredEntityController(monitoredEntityRepository);

        monitoredEntityController.Get(_guidOne.ToString()).Id.Should().Be(_guidOne, "the entity should be in the repository stored in memory.");
        
    }

    [Test]
    public void DeletePerformsTheExpectedOperation()
    {
        var monitoredEntityRepository = new TestMonitoredEntityRepository();
        var monitoredEntityController = new MonitoredEntityController(monitoredEntityRepository);
        MonitoredEntityDTO valueInMemory = monitoredEntityController.Get(_guidOne.ToString());
        
        if (valueInMemory is not null)
        {
            monitoredEntityController.Delete(_guidOne.ToString());
            monitoredEntityController.Get(_guidOne.ToString()).Should().BeNull("the value in memory should be deleted and thus return null.");
        }
    }
    
    [Test]
    public void UpdatedPerformsTheExpectedOperation()
    {
        var monitoredEntityRepository = new TestMonitoredEntityRepository();
        var monitoredEntityController = new MonitoredEntityController(monitoredEntityRepository);
        
        var monitoredEntityWithNewValues = new MonitoredEntityDTO()
        {
            Id = _guidOne,
            Name = "New Name",
            Value = "590"
        };
        var monitoredEntityWithOldValues = monitoredEntityController.Get(_guidOne.ToString());
        
        monitoredEntityController.Update(monitoredEntityWithNewValues);
        monitoredEntityController.Get(_guidOne.ToString()).Should().NotBe(monitoredEntityWithOldValues, "the values should have been updated to not be the same as the old values.");
    }
    
    [Test]
    public void AddPerformsTheExpectedOperation()
    {
        var monitoredEntityRepository = new TestMonitoredEntityRepository();
        var monitoredEntityController = new MonitoredEntityController(monitoredEntityRepository);
        
        var newMonitoredEntity = new MonitoredEntityDTO()
        {
            Id = Guid.NewGuid(),
            Name = "Additional Name",
            Value = "39990"
        };

        if (monitoredEntityController.Get(newMonitoredEntity.Id.ToString()) is null)
        {
            monitoredEntityController.Add(newMonitoredEntity);

            monitoredEntityController.Get(newMonitoredEntity.Id.ToString()).Should().NotBe(null, "the value should have just been added to the list, thus should show up through a Get request.");
        }
    }
}