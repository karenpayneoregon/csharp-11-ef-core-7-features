using System.ComponentModel;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace BindingListLibrary;

/// <summary>
/// Provides a generic collection that supports data binding and additionally supports sorting.
/// See http://msdn.microsoft.com/en-us/library/ms993236.aspx
/// If the elements are IComparable it uses that; otherwise compares the ToString()
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class SortableBindingList<T> : BindingList<T> where T : class
{
    private bool _isSorted;
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;
    private PropertyDescriptor _sortProperty;

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
    /// </summary>
    public SortableBindingList()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
    /// </summary>
    /// <param name="list">A <see cref="T:System.Collections.Generic.IList`1" /> of items to be contained in the <see cref="T:System.ComponentModel.BindingList`1" />.</param>
    public SortableBindingList(IList<T> list)
        : base(list)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the list supports sorting.
    /// </summary>
    protected override bool SupportsSortingCore => true;

    /// <summary>
    /// Gets a value indicating whether the list is sorted.
    /// </summary>
    protected override bool IsSortedCore => _isSorted;

    /// <summary>
    /// Gets the direction the list is sorted.
    /// </summary>
    protected override ListSortDirection SortDirectionCore => _sortDirection;

    /// <summary>
    /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class; otherwise, returns null
    /// </summary>
    protected override PropertyDescriptor SortPropertyCore => _sortProperty;

    /// <summary>
    /// Removes any sort applied with ApplySortCore if sorting is implemented
    /// </summary>
    protected override void RemoveSortCore()
    {
        _sortDirection = ListSortDirection.Ascending;
        _sortProperty = null!;
        _isSorted = false;
    }

    /// <summary>
    /// Sorts the items if overridden in a derived class
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="direction"></param>
    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        _sortProperty = prop;
        _sortDirection = direction;

        List<T> list = Items as List<T>;
        if (list == null) return;

        list.Sort(Compare);

        _isSorted = true;
        //fire an event that the list has been changed.
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }


    private int Compare(T lhs, T rhs)
    {
        var result = OnComparison(lhs, rhs);
        //invert if descending
        if (_sortDirection == ListSortDirection.Descending)
            result = -result;
        return result;
    }

    private int OnComparison(T lhs, T rhs)
    {
        object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
        object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
        if (lhsValue == null)
        {
            return (rhsValue == null) ? 0 : -1; //nulls are equal
        }
        if (rhsValue == null)
        {
            return 1; //first has value, second doesn't
        }
        if (lhsValue is IComparable)
        {
            return ((IComparable)lhsValue).CompareTo(rhsValue);
        }
        if (lhsValue.Equals(rhsValue))
        {
            return 0; //both are the same
        }
        //not comparable, compare ToString
        return string.Compare(lhsValue.ToString(), rhsValue.ToString(), StringComparison.Ordinal);
    }
}