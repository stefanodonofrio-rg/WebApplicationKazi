using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplicationKazim;

public class MonitoredEntityRepository : IMonitoredEntityRepository
{
    private IDbConnection _databaseConnection { get; }


    public MonitoredEntityRepository(IDbConnection connection)
    {
        _databaseConnection = connection;
    }

    public MonitoredEntity Get(string id)
    {
        try
        {
            _databaseConnection.Open();
            using var command = _databaseConnection.CreateCommand();

            command.CommandText = $"""
                                   SELECT * 
                                   FROM MonitoredEntityTable
                                   WHERE id='{id.ToUpperInvariant()}' 
                                   """;
            var reader = command.ExecuteReader();
            reader.Read();
            var retrievedEntity = new MonitoredEntityData()
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Value = reader.GetString(2)
            };
            _databaseConnection.Close();
            // Finished Data Layer
            return new MonitoredEntity()
            {
                Id = retrievedEntity.Id,
                Name = retrievedEntity.Name,
                Value = retrievedEntity.Value
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        


        _databaseConnection.Close();
        return null;
    }

    public bool Delete(string id)
    {
        try
        {
            _databaseConnection.Open();
            using var command = _databaseConnection.CreateCommand();
        
            command.CommandText = $"""
                                    DELETE
                                    FROM MonitoredEntityTable
                                    WHERE ID = '{id}'
                                   """;
            if (command.ExecuteNonQuery() == 0)
            {
                throw new Exception("No change");
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        _databaseConnection.Close();
        return false;
    }

    public bool Update(MonitoredEntity updatedEntity)
    {
        try
        {
            var updatedMonitoredEntityData = new MonitoredEntityData()
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name,
                Value = updatedEntity.Value
            };
            
            _databaseConnection.Open();
            using var command = _databaseConnection.CreateCommand();

            command.CommandText = $"""
                                    UPDATE MonitoredEntityTable
                                    SET Name = '{updatedMonitoredEntityData.Name}', Value = '{updatedMonitoredEntityData.Value}'
                                    WHERE ID = '{updatedMonitoredEntityData.Id}'
                                   """;
            if (command.ExecuteNonQuery() == 0)
            {
                throw new Exception("No change");
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        _databaseConnection.Close();
        return false;
    }

    public bool Add(MonitoredEntity addedEntity)
    {
        try
        {
            var addedMonitoredEntityData = new MonitoredEntityData()
            {
                Id = addedEntity.Id,
                Name = addedEntity.Name,
                Value = addedEntity.Value
            };
            _databaseConnection.Open();
            using var command = _databaseConnection.CreateCommand();
        
            command.CommandText = $"""
                                    INSERT INTO MonitoredEntityTable
                                    VALUES ('{addedMonitoredEntityData.Id.ToString().ToUpperInvariant()}', '{addedMonitoredEntityData.Name}', '{addedMonitoredEntityData.Value}')
                                   """;
            if (command.ExecuteNonQuery() == 0)
            {
                throw new Exception("No change");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        _databaseConnection.Close();
        return true;
    }
}