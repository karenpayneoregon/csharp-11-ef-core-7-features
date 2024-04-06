using System.Data.SQLite;
using Dapper;
using PeriodicTimerApp.Models;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace PeriodicTimerApp.Classes;
internal class DapperOperations
{
    public static Contacts Contact()
    {
        var cn = new SQLiteConnection(ConnectionString());
        const string sql =
            """
            SELECT [ContactId]
                ,[FirstName]
                ,[LastName]
                ,[ContactTypeIdentifier]
            FROM Contacts
            ORDER BY RANDOM() LIMIT 1
            """;
        return cn.QueryFirst<Contacts>(sql);
    }
}
