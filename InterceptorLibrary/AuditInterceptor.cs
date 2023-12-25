using InterceptorLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

// ReSharper disable AssignNullToNotNullAttribute

namespace InterceptorLibrary;

/// <summary>
/// Overrides SavingChangesAsync and SavingChanges to inject a method for writing changes to a SeriLog file. 
/// </summary>
public class AuditInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
    {
        Inspect(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        Inspect(eventData);
        return base.SavingChanges(eventData, result);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        Inspect(eventData);
        return base.SavedChanges(eventData, result);
    }

    private static void Inspect(DbContextEventData eventData)
    {
        var changesList = new List<CompareModel>();

        foreach (EntityEntry entry in eventData.Context!.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    changesList.Add(new()
                    {
                        OriginalValue = null,
                        NewValue = entry.CurrentValues.ToObject(),
                        EntityState = EntityState.Added.ToString()
                    });
                    break;
                case EntityState.Deleted:
                    changesList.Add(new()
                    {
                        OriginalValue = entry.OriginalValues.ToObject(),
                        NewValue = null,
                        EntityState = EntityState.Deleted.ToString()
                    });
                    break;
                case EntityState.Modified:
                    changesList.Add(new()
                    {
                        OriginalValue = entry.OriginalValues.ToObject(),
                        NewValue = entry.CurrentValues.ToObject(),
                        EntityState = EntityState.Modified.ToString()
                    });
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Log.Information($"\nchange list:{changesList.ToJson()}");

        }
    }
}