using Bogus;
using Bogus.Premium;

namespace BogusApp.DataSets;

public static class BogusExtensions
{
    /// <summary>
    /// Entry point for faker RuleFor
    /// </summary>
    public static Folders ItemHelper(this Faker faker)
        => ContextHelper.GetOrSet(faker, () => new Folders());
}