using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplicationKazim;

public class DatabaseOperator
{
    private IDbConnection _databaseConnection { get; set; }
    
    private void OpenConnection()
    {
        string connectionString = "Data Source=DEV-LT-KAZIMR; Initial Catalog=MonitoredEntityTable; Integrated Security=true; TrustServerCertificate=True";
        _databaseConnection = new SqlConnection(connectionString);
        _databaseConnection.Open();
    }

    public MonitoredEntity Get(string id)
    {
        MonitoredEntity returnValue = new MonitoredEntity();
        try
        {
            OpenConnection();
            using var command = _databaseConnection.CreateCommand();
        
            command.CommandText = $"""
                                   SELECT * 
                                   FROM MonitoredEntityTable
                                   WHERE id='{id.ToUpperInvariant()}' 
                                   """;
            var reader = command.ExecuteReader();
            reader.Read();
            returnValue.Id = reader.GetGuid(0);
            returnValue.Name = reader.GetString(1);
            returnValue.Value = reader.GetString(2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        _databaseConnection.Close();
        return returnValue;
    }

    public bool Delete(Guid id)
    {
        try
        {
            OpenConnection();
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
        OpenConnection();
        try
        {
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
            OpenConnection();
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