﻿namespace FormattableSamples.Classes;

public static class DatabaseHelper
{
    /// <summary>
    /// Converts a <see cref="FormattableString"/> to a SQL format string and a dictionary of parameters.
    /// </summary>
    /// <param name="sql">The <see cref="FormattableString"/> to convert.</param>
    /// <param name="databaseType">The type of database being used. Default is <see cref="DatabaseType.SqlServer"/>.</param>
    /// <returns>A tuple containing the SQL format string and a dictionary of parameters.</returns>
    public static (string sqlFormat, Dictionary<string, object> parameter) ToParameters(
        this FormattableString sql, 
        DatabaseType databaseType = DatabaseType.SqlServer)
    {
        ArgumentNullException.ThrowIfNull(sql);

        var sqlFormat = sql.Format;
        var parameter = new Dictionary<string, object>();
        var arguments = sql.GetArguments();

        if (sql.ArgumentCount < 3)
            return (sqlFormat, parameter);

        var prefix = GetPrefix(databaseType);

        for (var index = 0; index < sql.ArgumentCount; index++)
        {
            var name = $"{prefix}p__{index + 1}";
            sqlFormat = sqlFormat.Replace($"{{{index}}}", name);
            parameter[name] = arguments[index];
        }

        return (sqlFormat, parameter);
    }

    /// <summary>
    /// Set parameter prefix dependent of which database is being used.
    /// </summary>
    /// <param name="databaseType"></param>
    /// <returns></returns>
    private static string GetPrefix(DatabaseType databaseType)
        => databaseType switch
        {
            DatabaseType.Sqlite or DatabaseType.SqlServer => "@",
            DatabaseType.MySql => "?",
            DatabaseType.Oracle or DatabaseType.PostgreSql => ":",
            _ => "@",
        };
}