using _13Features.Models;

namespace _13Features.Classes
{
    internal class MockedData
    {
        public static Person InitializePersonWithOrganization()
        {
            Person person = new()
            {
                GivenName = "John",
                SurName = "Doe",
                Organization = new Organization
                {
                    Name = "Acme",
                    Teams = []
                }
            };
            person.Organization.Teams.Add(new Team
            {
                TeamName = "DevOps",
                Lead = person,
                Members = new List<Person>
                {
                    new Person 
                    { 
                        GivenName = "Jane", SurName = "Smith", 
                        Organization = new Organization
                        {
                            Name = "Acme",
                            Teams = []
                        }
                    },
                    new Person 
                    { 
                        GivenName = "Jack", 
                        SurName = "Jones", 
                        Organization = new Organization
                        {
                            Name = "Acme",
                            Teams = []
                        }
                    }
                }
            });

            return person;

        }
    }
}
