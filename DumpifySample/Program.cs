using Dumpify;
using DumpifySample.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using DumpifySample.Classes;
using static DumpifySample.Classes.SpectreConsoleHelpers;
using Color = System.Drawing.Color;
using DumpifySample.Models;

namespace DumpifySample;

internal partial class Program
{
    static void Main(string[] args)
    {

        DumpConfig.Default.ColorConfig.TypeNameColor = new DumpColor(Color.Aqua);
        DumpConfig.Default.ColorConfig.NullValueColor = new DumpColor(Color.Red);

        using var context = new Context();
        var category = context.Categories
            .Include(x => x.Products)
            .ThenInclude(x => x.OrderDetails.Take(1))
            .ThenInclude(x => x.Order)
            .FirstOrDefault(c => c.CategoryID == 2);

        category.Dump(maxDepth: 10, members: new MembersConfig
        {
            MemberFilter = member
                => member.Info.CustomAttributes.All(a
                    => a.AttributeType != typeof(NoDumpDataAttribute))
        });

        var persons = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                SecretStuff = "Secrets",
                BirthDate = new DateOnly(1980, 1, 1)
            },
            new Person
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                SecretStuff = "Confidential",
                BirthDate = new DateOnly(1990, 5, 15)
            },
            new Person
            {
                Id = 3,
                FirstName = "Mike",
                LastName = "Johnson",
                SecretStuff = "Top Secret",
                BirthDate = new DateOnly(1975, 10, 20)
            }
        };

        persons.Dump(members: new MembersConfig
        {
            MemberFilter = member
                => member.Info.CustomAttributes.All(a
                    => a.AttributeType != typeof(NoDumpDataAttribute))
        });

        ExitPrompt();


    }
}