using Bogus;
using BogusExtendedApp.Models;
using BogusExtendedApp.DataSets;
using BogusExtendedApp.LanguageExtensions;

namespace BogusExtendedApp.Classes;


public static class BogusOperations
{
    /// <summary>
    /// Generates a list of <see cref="Contact"/> objects with randomly populated data.
    /// </summary>
    /// <param name="count">The number of <see cref="Contact"/> objects to generate. Defaults to 3.</param>
    /// <returns>A list of <see cref="Contact"/> objects with populated properties, including a custom dataset for <see cref="ContactType"/>.</returns>
    /// <remarks>
    /// Each <see cref="Contact"/> object is assigned a unique identifier and populated with random first and last names.
    /// The <see cref="ContactType"/> property is generated using a custom dataset from <see cref="NorthWind.ContactTypes"/>.
    /// </remarks>
    public static List<Contact> Contacts(int count = 3)
    {
        var identifier = 1;
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
