using UsingAliasExample.Models;

namespace UsingAliasExample.Classes;
internal class MockedData
{
    public static Dictionary<int, Person> FromDataSource()
    {
        return new Dictionary<int, Person>()
        {
            [1] = new() { Id = 23, FirstName = "Karen", LastName = "Payne" },
            [2] = new() { Id = 24, FirstName = "Anne", LastName = "Jenkins" },
            [3] = new() { Id = 25, FirstName = "Mike", LastName = "Burton" }
        };
    }
}
