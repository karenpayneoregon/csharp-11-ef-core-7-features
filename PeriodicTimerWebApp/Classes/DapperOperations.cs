using Microsoft.Data.SqlClient;
using PeriodicTimerWebApp.Models;
using System.Data;
using Dapper;

namespace PeriodicTimerWebApp.Classes;
internal class DapperOperations
{
    private IDbConnection _cn;
    public DapperOperations(string connectionString)
    {
        _cn = new SqlConnection(connectionString);
    }
    public Contacts Contact()
    {

        return _cn.QueryFirst<Contacts>("SELECT TOP 1 * FROM dbo.Contacts ORDER BY NEWID()");
    }
}
