using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InterceptorLibrary;
/// <summary>
/// Interceptor ready for your logic
/// </summary>
public class ProductionAuditInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
    {
        // TODO
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        // TODO
        return base.SavingChanges(eventData, result);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        // TODO
        return base.SavedChanges(eventData, result);
    }
}
