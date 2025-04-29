using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace KarenConsoleApplication.Classes;

internal class DbContextHelpers
{
    /// <summary>
    /// Checks if the database associated with the provided <see cref="DbContext"/> exists.
    /// </summary>
    /// <param name="context">The database context to check for the existence of the database.</param>
    /// <returns>
    /// <c>true</c> if the database exists; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the database creator service is not available in the provided context.
    /// </exception>
    public static bool DatabaseExists<TContext>(TContext context) where TContext : DbContext
    {
        if (context.GetService<IDatabaseCreator>() is not RelationalDatabaseCreator databaseCreator)
        {
            throw new InvalidOperationException("Database creator service is not available.");
        }

        return databaseCreator.Exists();
    }
    /// <summary>
    /// Determines whether the database associated with the provided <see cref="DbContext"/> contains any tables.
    /// </summary>
    /// <typeparam name="TContext">The type of the database context, which must derive from <see cref="DbContext"/>.</typeparam>
    /// <param name="context">The database context to check for the presence of tables.</param>
    /// <returns>
    /// <c>true</c> if the database contains one or more tables; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the relational database creator service is not available in the provided context.
    /// </exception>
    public static bool HasTables<TContext>(TContext context) where TContext : DbContext
    {

        if (context.GetService<IRelationalDatabaseCreator>() is not RelationalDatabaseCreator databaseCreator)
        {
            throw new InvalidOperationException("Database creator service is not available.");
        }
        
        return databaseCreator.HasTables();
    }

    public static string GenerateScripts<TContext>(TContext context) where TContext : DbContext
    {
        if (context.GetService<IRelationalDatabaseCreator>() is not RelationalDatabaseCreator databaseCreator)
        {
            throw new InvalidOperationException("Database creator service is not available.");
        }

        return databaseCreator.GenerateCreateScript();
    }

    /// <summary>
    /// Checks whether the specified tables exist in the database associated with the provided <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The database context to check for the presence of the specified tables.</param>
    /// <param name="tableNames">An array of table names to check for existence in the database.</param>
    /// <returns>
    /// <c>true</c> if all specified tables exist in the database; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="context"/> or <paramref name="tableNames"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the model metadata in the provided context is not properly configured.
    /// </exception>
    public static bool DoTablesExist(DbContext context, params string[] tableNames)
    {

        var existingTables = new HashSet<string>(
            context.Model.GetEntityTypes()
                .Select(t => t.GetTableName())
                .Where(t => !string.IsNullOrEmpty(t)) 
                .Cast<string>() 
        );

        return existingTables.IsSupersetOf(tableNames);
    }

    /// <summary>
    /// Performs a comprehensive check on the database associated with the provided <see cref="DbContext"/>.
    /// This includes verifying the existence of the database, the presence of existence of specific tables
    /// specified by their names.
    /// </summary>
    /// <typeparam name="TContext">The type of the database context, which must derive from <see cref="DbContext"/>.</typeparam>
    /// <param name="context">The database context to perform the checks on.</param>
    /// <param name="tableNames">An array of table names to verify their existence in the database.</param>
    /// <returns>
    /// <c>true</c> if the database exists, contains tables, and all specified table names are present; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the required database services are not available in the provided context.
    /// </exception>
    public static bool FullCheck<TContext>(TContext context, params string[] tableNames) where TContext : DbContext 
        => DatabaseExists(context) && HasTables(context) && DoTablesExist(context, tableNames);
}