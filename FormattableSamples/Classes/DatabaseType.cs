using System.ComponentModel;

namespace FormattableSamples.Classes;
public enum DatabaseType
{
    [Description("SqlServer")] SqlServer = 0,
    [Description("MySql")] MySql = 1,
    [Description("Oracle")] Oracle = 2,
    [Description("Sqlite")] Sqlite = 3,
    [Description("PostgreSql")] PostgreSql = 4
}