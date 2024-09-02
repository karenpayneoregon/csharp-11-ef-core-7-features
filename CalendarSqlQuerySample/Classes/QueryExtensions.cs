using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace CalendarSqlQuerySample.Classes;

public static class QueryExtensions
{
    /// <summary>
    /// Wrapper for EF Core TagWith
    /// </summary>
    /// <param name="message">Optional text</param>
    /// <param name="memberName"></param>
    /// <param name="filePath"></param>
    /// <param name="lineNumber"></param>
    /// <returns>
    /// Formatted string for EF Core TagWith
    /// </returns>
    /// <remarks>
    /// Author Dave Callan
    /// Additions Karen Payne
    /// </remarks>
    public static IQueryable<T> TagWithDebugInfo<T>(this IQueryable<T> query,
        string message = "",
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        return query.TagWith(string.IsNullOrWhiteSpace(message) ? 
            $"Executing method {memberName} in {filePath} at line {lineNumber}" : 
            $"Executing method {memberName} in {filePath} at line {lineNumber} message {message}");
    }
}