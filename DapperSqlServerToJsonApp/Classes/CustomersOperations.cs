using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;
using Dapper;
using DapperSqlServerToJsonApp.Models;

namespace DapperSqlServerToJsonApp.Classes;

/// <summary>
/// For DapperAOT to indicate we are using SQL-Server
/// </summary>
[SqlSyntax(SqlSyntax.SqlServer)]
internal class CustomersOperations
{
    private IDbConnection _cn = new SqlConnection(ConnectionString());
    private JsonSerializerOptions JsonSerializerOptions = new() { WriteIndented = true };

    [DapperAot] // active DapperAOT - to disable [DapperAot(false)]
    public void ToJson()
    {
        /*
         * Broken on purpose INER rather than INNER
         */
        const string statement =
            """
            SELECT Cust.CustomerIdentifier,
                   Cust.CompanyName,
                   Cust.ContactId,
                   Cust.ContactTypeIdentifier,
                   CT.ContactTitle,
                   C.FirstName,
                   C.LastName,
                   Cust.CountryIdentifier,
                   CO.Name,
                   Cust.Phone
             FROM dbo.Customers AS Cust --- comment
                INNER JOIN dbo.Contacts AS C
                    ON Cust.ContactId = C.ContactId
                INNER JOIN dbo.ContactType AS CT
                    ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier
                       AND C.ContactTypeIdentifier = CT.ContactTypeIdentifier
                INNER JOIN dbo.Countries AS CO
                    ON Cust.CountryIdentifier = CO.CountryIdentifier
            """;
        
        IEnumerable<Customers> customers = _cn.Query<Customers>(statement);
        
        File.WriteAllText("Customers.json",
            JsonSerializer.Serialize(customers,
                JsonSerializerOptions));

    }
}

