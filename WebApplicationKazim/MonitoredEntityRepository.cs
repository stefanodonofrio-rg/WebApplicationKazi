using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplicationKazim;

public class MonitoredEntityRepository : IMonitoredEntityRepository
{
    private IDbConnection _databaseConnection { get; set; }


    public MonitoredEntityRepository(string connectionString)
    {
        _databaseConnection = new SqlConnection(connectionString);
    }

    public MonitoredEntity Get(string id)
    {
        MonitoredEntity retrievedEntity = new MonitoredEntity();
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
            retrievedEntity.Id = reader.GetGuid(0);
            retrievedEntity.Name = reader.GetString(1);
            retrievedEntity.Value = reader.GetString(2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        _databaseConnection.Close();
        return retrievedEntity;
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
            _databaseConnection.Open();
            using var command = _databaseConnection.CreateCommand();

            command.CommandText = $"""
                                    UPDATE MonitoredEntityTable
                                    SET Name = '{updatedEntity.Name}', Value = '{updatedEntity.Value}'
                                    WHERE ID = '{updatedEntity.Id}'
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
            _databaseConnection.Open();
            using var command = _databaseConnection.CreateCommand();
        
            command.CommandText = $"""
                                    INSERT INTO MonitoredEntityTable
                                    VALUES ('{addedEntity.Id.ToString().ToUpperInvariant()}', '{addedEntity.Name}', '{addedEntity.Value}')
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