using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AuditInterceptorSampleApp.Classes;

public static class EntityExtensions
{
    /// <summary>
    /// Test connection with exception handling
    /// </summary>
    /// <param name="context">active DbContext</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static async Task<(bool success, Exception exception)> CanConnectAsync(this DbContext context)
    {
        try
        {
            var result = await Task.Run(async () => await context.Database.CanConnectAsync());
            return (result, null);
        }
        catch (Exception e)
        {
            return (false, e);
        }
    }


}