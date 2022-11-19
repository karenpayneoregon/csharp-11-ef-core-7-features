using Microsoft.EntityFrameworkCore.Diagnostics;
using IMaterializationInterceptorSample.Interfaces;

namespace IMaterializationInterceptorSample.Interceptors;

/// <summary>
/// See
/// https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/whatsnew#simple-actions-on-entity-creation
/// </summary>
public class SetRetrievedInterceptor : IMaterializationInterceptor
{
    public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
    {
        if (instance is IHasRetrieved hasRetrieved)
        {
            hasRetrieved.Retrieved = DateTime.UtcNow;
        }

        return instance;
    }
}