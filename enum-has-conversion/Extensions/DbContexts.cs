using Microsoft.EntityFrameworkCore;

namespace EnumHasConversion.Extensions;
public static class DbContexts
{
    /// <summary>
    /// Test connection with exception handling
    /// </summary>
    /// <param name="context"><see cref="DbContext"/></param>
    /// <param name="cancellationToken">Provides a shorter time out from 30 seconds to in this case one second</param>
    /// <returns>true if database is accessible</returns>
    /// <remarks>
    /// Running asynchronous as synchronous.
    /// </remarks>
    public static bool CanConnectAsync(this DbContext context, CancellationToken cancellationToken)
    {
        try
        {
            return context.Database.CanConnectAsync(cancellationToken).Result;

        }
        catch
        {
            return false;
        }
    }

}
