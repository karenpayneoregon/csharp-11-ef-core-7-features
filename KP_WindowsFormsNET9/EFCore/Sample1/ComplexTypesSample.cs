using System.Diagnostics;
using System.Runtime.CompilerServices;
using KP_WindowsFormsNET9.EFCore.Sample1.Classes;
using KP_WindowsFormsNET9.EFCore.Sample1.Data;
using Microsoft.EntityFrameworkCore;

namespace KP_WindowsFormsNET9.EFCore.Sample1;

/// <summary>
/// Provides methods for executing queries that group data by complex types using Entity Framework Core.
/// </summary>
public static class ComplexTypesSample
{
    public static Task GroupByComplexTypeInstances()
        => ExecuteQueries(sqlite: false);

    public static Task GroupByComplexTypeInstancesOn_SQLite()
        => ExecuteQueries(sqlite: true);

    public static async Task ExecuteQueries(bool sqlite)
    {
        PrintSampleName();

        await using var context = new CustomerContext(useSqlite: sqlite);

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        context.AddRange(MockedData.GetSampleData());

        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        Debug.WriteLine("");
        Debug.WriteLine("GroupBy complex type:");
        Debug.WriteLine("");

        #region GroupByComplexType
        var groupedAddresses = await context.Stores
            .GroupBy(b => b.StoreAddress)
            .Select(g => new { g.Key, Count = g.Count() })
            .ToListAsync();
        #endregion

        foreach (var groupedAddress in groupedAddresses)
        {
            Debug.WriteLine($"{groupedAddress.Key.PostCode}: {groupedAddress.Count}");
        }
    }

    private static void PrintSampleName([CallerMemberName] string? methodName = null)
    {
        Debug.WriteLine($">>>> Sample: {methodName}");
        Debug.WriteLine(new string('-',50));
    }
}
