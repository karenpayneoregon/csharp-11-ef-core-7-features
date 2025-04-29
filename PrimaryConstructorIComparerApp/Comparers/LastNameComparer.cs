#nullable enable
using PrimaryConstructorIComparerApp.Interfaces;

namespace PrimaryConstructorIComparerApp.Comparers;

#pragma warning disable CS8602
/// <summary>
/// Provides a comparer for comparing instances of <see cref="IStudent"/> based on their last names.
/// </summary>
/// <remarks>
/// This comparer is used to sort or order students by their last names in a case-insensitive manner.
/// </remarks>
public class LastNameComparer : IComparer<IStudent>
{
    public int Compare(IStudent? x, IStudent? y)
        => string.Compare(x.LastName, y.LastName, StringComparison.OrdinalIgnoreCase);
}