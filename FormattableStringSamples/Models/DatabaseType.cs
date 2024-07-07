using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattableStringSamples.Models;
public enum DatabaseType
{
    [Description("SqlServer")] SqlServer = 0,
    [Description("MySql")] MySql = 1,
    [Description("Oracle")] Oracle = 2,
    [Description("Sqlite")] Sqlite = 3,
    [Description("PostgreSql")] PostgreSql = 4
}