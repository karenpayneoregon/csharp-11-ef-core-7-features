// for connection string
using static ConsoleConfigurationLibrary.Classes.AppConnections;
using Microsoft.Data.SqlClient;
using SqlDataReaderDateOnlyTimeOnlySample.Extensions;
using SqlDataReaderDateOnlyTimeOnlySample.Models;

namespace SqlDataReaderDateOnlyTimeOnlySample.Classes;
internal class DataOperations
{
    public static async Task<List<Person>> ReadPeople()
    {
        const string statement =
            """
            SELECT PersonId,FirstName,LastName,BirthDate 
            FROM dbo.Person
            """;

        /*
         * Instance.MainConnection reads appsettings.json
         * ConnectionStrings:MainConnection 
         */
        await using SqlConnection cn = new(Instance.MainConnection);
        await using SqlCommand cmd = new() { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using SqlDataReader? reader = await cmd.ExecuteReaderAsync();

        List<Person> list = [];

        while (await reader.ReadAsync())
        {

            list.Add(new Person()
            {
                PersonId = await reader.GetIntAsync(0),
                FirstName = await reader.GetStringAsync(1),
                LastName = await reader.GetStringAsync(2),
                BirthDate = await reader.GetDateOnlyAsync(3)
            });
        }

        return list;

    }
}
