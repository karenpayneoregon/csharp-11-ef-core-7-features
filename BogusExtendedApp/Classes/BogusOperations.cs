using Bogus;
using BogusExtendedApp.Models;
using BogusExtendedApp.LanguageExtensions;

namespace BogusExtendedApp.Classes;


    public static class BogusOperations
    {
        /// <summary>
        /// Generate a list of <see cref="Contacts"/> with a custom dataset <see cref="DataSets.NorthWind.ContactTypes"/>
        /// </summary>
        /// <param name="count">How many to create, default is three</param>
        public static List<Contact> Contacts(int count = 3)
        {
            int identifier = 1;
            var data = new Faker<Contact>()
                .CustomInstantiator(f => new Contact(identifier++))
                .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                .RuleFor(c => c.LastName, f => f.Person.LastName)
                .RuleFor(c => c.ContactType, f => f.NorthWind().ContactTypes());

            var list = data.Generate(count);
            list.ForEach(c => c.ContactTypeIdentifier = c.ContactType.ContactTypeIdentifier);
            return list;
        }
    }
