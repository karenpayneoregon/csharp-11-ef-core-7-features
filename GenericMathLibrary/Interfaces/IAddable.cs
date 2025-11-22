
namespace GenericMathLibrary.Interfaces;

/// <summary>
/// Represents a type that supports addition operations and provides a zero value.
/// </summary>
/// <typeparam name="T">
/// The type that implements the <see cref="IAddable{T}"/> interface. 
/// This type must also satisfy the constraint of being an <see cref="IAddable{T}"/>.
/// </typeparam>
public interface IAddable<T> where T : IAddable<T>
{
    static abstract T Zero { get; }
    static abstract T operator +(T t1, T t2);
}
