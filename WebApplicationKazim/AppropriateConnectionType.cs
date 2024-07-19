using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplicationKazim;

public static class AppropriateConnectionType
{
    public static IDbConnection ConnectionType(int databaseType, string connectionString)
    {
        
        return databaseType switch
        {
            (int) DatabaseType.SqlConnection => new SqlConnection(connectionString),
            _ => throw new ArgumentOutOfRangeException(nameof(databaseType), databaseType, null)
        };
    }
}

public enum DatabaseType
{
    SqlConnection = 1
};