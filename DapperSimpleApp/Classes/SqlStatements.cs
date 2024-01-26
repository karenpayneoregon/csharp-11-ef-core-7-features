namespace DapperSimpleApp.Classes
{
    /// <summary>
    /// Collection of SQL statements, feel free to move to stored procedures.
    /// </summary>
    internal class SqlStatements
    {
        /// <summary>
        /// Read all people from database
        /// </summary>
        public static string GetAllPeople = "SELECT Id,FirstName,LastName,BirthDate FROM dbo.Person;";
        /// <summary>
        /// Read a person by primary key
        /// </summary>
        public static string GetPerson    = "SELECT Id,FirstName,LastName,BirthDate FROM dbo.Person WHERE Id = @Id";

        /// <summary>
        /// Update a person by primary key
        /// </summary>
        public static string UpdatePerson = 
            "UPDATE [dbo].[Person] SET [FirstName] = @FirstName,[LastName] = @LastName,[BirthDate] = @BirthDate WHERE Id = @Id";

        /// <summary>
        /// Remove a person by primary key
        /// </summary>
        public static string RemovePerson = "DELETE FROM dbo.Person WHERE Id = @Id;";

        /// <summary>
        /// Insert a new person, return the new primary key
        /// </summary>
        public static string InsertPerson = 
            "INSERT INTO dbo.Person (FirstName,LastName,BirthDate) " +
            "VALUES (@FirstName, @LastName, @BirthDate);" +
            "SELECT CAST(scope_identity() AS int);";
    }
}
