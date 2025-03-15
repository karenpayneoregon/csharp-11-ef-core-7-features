using CustomIConfigurationSourceSample.Data;
using MemoryConfigurationSourceRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryConfigurationSourceRazorPages.Classes;

public class DataOperations
{
    /// <summary>
    /// Retrieves a dictionary containing help desk contact information, such as phone and email,
    /// from the database. The keys in the dictionary are formatted as "Helpdesk:phone" and "Helpdesk:email".
    /// </summary>
    /// <returns>
    /// A <see cref="Dictionary{TKey, TValue}"/> where the keys are strings representing the contact types
    /// ("Helpdesk:phone" and "Helpdesk:email") and the values are the corresponding contact details.
    /// If no data is found, the values will be <c>null</c>.
    /// </returns>
    /// <remarks>
    /// This should be fully tested in a staging environment and verified before deployment to production regarding the database table
    /// is set up correctly and the data is available in the database.
    /// </remarks>
    public static Dictionary<string, string?> GetHelpDeskValues()
    {
        using var context = new Context();
        var settings = context.Settings
            .AsNoTracking()
            .Where(x => x.Section == nameof(HelpDesk) && (x.Key == nameof(HelpDesk.Phone) || x.Key == nameof(HelpDesk.Email)))
            .ToList();

        return new Dictionary<string, string?>
        {
            {"Helpdesk:phone", settings.FirstOrDefault(x => x.Key == nameof(HelpDesk.Phone))?.Value},
            {"Helpdesk:email", settings.FirstOrDefault(x => x.Key == nameof(HelpDesk.Email))?.Value}
        };


    }

}
