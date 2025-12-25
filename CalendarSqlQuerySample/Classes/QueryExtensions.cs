using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace CalendarSqlQuerySample.Classes;

public static class QueryExtensions
{
    /// <summary>
    /// Adds debugging information as a tag to the query using EF Core's <see cref="EntityFrameworkQueryableExtensions.TagWith{TEntity}(IQueryable{TEntity}, string)"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the query.</typeparam>
    /// <param name="query">The query to which the tag will be added.</param>
    /// <param name="message">Optional custom message to include in the tag. Defaults to an empty string.</param>
    /// <param name="memberName">The name of the calling member. Automatically provided by the compiler.</param>
    /// <param name="filePath">The file path of the calling code. Automatically provided by the compiler.</param>
    /// <param name="lineNumber">The line number in the source file at which the method is called. Automatically provided by the compiler.</param>
    /// <returns>The query with the added debugging information tag.</returns>
    /// <remarks>
    /// This method is a wrapper around EF Core's <see cref="EntityFrameworkQueryableExtensions.TagWith{TEntity}(IQueryable{TEntity}, string)"/> 
    /// that appends debugging information such as the calling member name, file path, and line number.
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