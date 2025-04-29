#nullable enable
#pragma warning disable CS8602 // Dereference of a possibly null reference.
using PrimaryConstructorIComparerApp.Interfaces;


namespace PrimaryConstructorIComparerApp.Comparers;

/// <summary>
/// Provides a comparer for comparing instances of <see cref="IStudent"/> based on their grades.
/// </summary>
/// <remarks>
/// This comparer is used to sort or order students by their grades in ascending order.
/// </remarks>
public class GradeComparer : IComparer<IStudent>
{
    public int Compare(IStudent? x, IStudent? y)
    {
        if (x.Grade > y.Grade)
        {
            return 1;
        }
        else if (x.Grade < y.Grade)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}