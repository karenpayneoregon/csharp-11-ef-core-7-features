namespace FormattableStringSamples.Models;

public static class DatabaseHelper
{
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
            DatabaseType.Sqlite => "@",
            DatabaseType.SqlServer => "@",
            DatabaseType.MySql => "?",
            DatabaseType.Oracle => ":",
            DatabaseType.PostgreSql => ":",
            _ => "",
        };
}