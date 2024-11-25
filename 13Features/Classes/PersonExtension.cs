using _13Features.Models;

namespace Classes;

public static class PersonExtension
{
    /// <summary>
    /// Determines whether the specified person is a lead of any team within their organization.
    /// </summary>
    /// <param name="person">The person to check.</param>
    /// <returns>
    /// <c>true</c> if the person is a lead of any team; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsLead(this Person person)
        => person.Organization
            .Teams
            .Any(team => team.Lead == person);
}