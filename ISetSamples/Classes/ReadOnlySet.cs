using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISetSamples.Classes;
public class ReadOnlySet<T> : IReadOnlyCollection<T>, ISet<T>
{
    private readonly ISet<T> _set;
    public ReadOnlySet(ISet<T> set)
    {
        _set = set;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _set.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_set).GetEnumerator();
    }

    void ICollection<T>.Add(T item)
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public void UnionWith(IEnumerable<T> other)
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        return _set.IsSubsetOf(other);
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        return _set.IsSupersetOf(other);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return _set.IsProperSupersetOf(other);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return _set.IsProperSubsetOf(other);
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        return _set.Overlaps(other);
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        return _set.SetEquals(other);
    }

    public bool Add(T item)
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public void Clear()
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public bool Contains(T item)
    {
        return _set.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _set.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        throw new NotSupportedException("Set is a read only set.");
    }

    public int Count => _set.Count;

    public bool IsReadOnly => true;
}
public static class SetExtensionMethods
{
    public static ReadOnlySet<T> AsReadOnly<T>(this ISet<T> set) => new(set);
}

