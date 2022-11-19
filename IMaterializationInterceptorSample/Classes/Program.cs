using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.CompilerServices;
using IMaterializationInterceptorSample.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

// ReSharper disable once CheckNamespace
namespace IMaterializationInterceptorSample;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: SetRetrievedInterceptor";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    public static async Task<bool> DatabaseExistsAsync()
    {
        await using var context = new ProductsContext();
        return await ((context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!).ExistsAsync();
    }
}