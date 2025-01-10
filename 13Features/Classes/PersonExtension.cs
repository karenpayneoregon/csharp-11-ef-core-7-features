using Net9Features.Models;

namespace Net9Features.Classes;

public static class PersonExtension
{
    /// <summary>
    /// Determines whether the specified person is a lead of any team within their organization.
    /// </summary>
    /// <param name="person">The person to check.</param>
    /// <returns>
    /// <c>true</c> if the person is a lead of any team; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Tried to do an extension but seems like it's not working hence a regular extension.
    /// </remarks>
    public static bool IsLead(this Person person)
        => person.Organization
            .Teams
            .Any(team => team.Lead == person);


}

