namespace _13Features.Models
{
    public class Person
    {
        public required string GivenName { get; init; }
        public required string SurName { get; init; }
        public required Organization Organization { get; init; }
    }

    public class Organization
    {
        public required string Name { get; init; }
        public required List<Team> Teams { get; init; }
    }

    public class Team
    {
        public required string TeamName { get; init; }
        public required Person Lead { get; init; }
        public required IEnumerable<Person> Members { get; init; }
    }
}
