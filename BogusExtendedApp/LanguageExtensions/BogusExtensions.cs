using Bogus;
using Bogus.Premium;
using BogusExtendedApp.DataSets;

namespace BogusExtendedApp.LanguageExtensions;
public static class BogusExtensions
{
    /// <summary>
    /// Entry point for faker RuleFor
    /// </summary>
    public static NorthWind NorthWind(this Faker faker) 
        => ContextHelper.GetOrSet(faker, () => new NorthWind());
}