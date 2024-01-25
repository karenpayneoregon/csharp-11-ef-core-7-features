namespace DapperSimpleApp.Classes
{
    internal class SqlStatements
    {
        public static string GetAllPeople = "SELECT Id,FirstName,LastName,BirthDate FROM dbo.Person;";
        public static string UpdatePerson = "UPDATE [dbo].[Person] SET [FirstName] = @FirstName,[LastName] = @LastName,[BirthDate] = @BirthDate WHERE Id = @Id";
        public static string GetPerson    = "SELECT Id,FirstName,LastName,BirthDate FROM dbo.Person WHERE Id = @Id";
        public static string RemovePerson = "DELETE FROM dbo.Person WHERE Id = @Id;";
        public static string InsertPerson = "INSERT INTO dbo.Person (FirstName,LastName,BirthDate) VALUES (@FirstName, @LastName, @BirthDate);SELECT CAST(scope_identity() AS int);";
    }
}
