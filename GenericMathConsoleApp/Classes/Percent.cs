/*
 * Original source
 * https://github.com/Entomy/Numbersome/blob/main/Numbersome/Numerics/Percent.cs
 *
 * Modifications by Karen Payne
 */

// ReSharper disable once CheckNamespace
namespace System.Numerics;

using Diagnostics.CodeAnalysis;
using Runtime.InteropServices;

/// <summary>
/// Represents a percentage.
/// </summary>
/// <typeparam name="T">The backing type of the percentage.</typeparam>
[StructLayout(LayoutKind.Auto)]
public readonly struct Percent<T> :
    IAdditionOperators<Percent<T>, Percent<T>, Percent<T>>,
    IAdditiveIdentity<Percent<T>, Percent<T>>,
    IDivisionOperators<Percent<T>, Percent<T>, Percent<T>>,
    IEqualityOperators<Percent<T>, Percent<T>, Boolean>, IEquatable<Percent<T>>,
    IMultiplicativeIdentity<Percent<T>, Percent<T>>,
    IMultiplyOperators<Percent<T>, Percent<T>, Percent<T>>,
    ISubtractionOperators<Percent<T>, Percent<T>, Percent<T>>,
    IUnaryNegationOperators<Percent<T>, Percent<T>>,
    IUnaryPlusOperators<Percent<T>, Percent<T>>
    where T : notnull, INumberBase<T>
{
    /// <summary>
    /// The backing value of the percentage.
    /// </summary>
    private readonly T Value;

    /// <summary>
    /// The value <c>100</c> as represented by the backing type.
    /// </summary>
    /// <remarks>
    /// This is an obtuse value and its initialization is necessary to work around a caveat in the design of .NET's Generic Math implementation.
    /// </remarks>
    private static readonly T OneHundred = 
        (T.One + T.One + T.One + T.One + T.One + T.One + T.One + T.One + T.One + T.One) * 
        (T.One + T.One + T.One + T.One + T.One + T.One + T.One + T.One + T.One + T.One);

    /// <summary>
    /// Initializes a new <see cref="Percent{T}"/>.
    /// </summary>
    public Percent() => Value = T.Zero;

    /// <summary>
    /// Initializes a new <see cref="Percent{T}"/>.
    /// </summary>
    /// <param name="value">The value of the <see cref="Percent{T}"/>.</param>
    public Percent(T value) => Value = value;

    /// <inheritdoc/>
    public static Percent<T> AdditiveIdentity => new(T.AdditiveIdentity);

    /// <inheritdoc/>
    public static Percent<T> MultiplicativeIdentity => new(T.MultiplicativeIdentity);

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? sender) =>
        sender switch
        {
            Percent<T> percent => Equals(percent),
            _ => false
        };

    /// <inheritdoc/>
    public Boolean Equals(Percent<T> other) => Value.Equals(other.Value);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode();

    /// <inheritdoc/>
    [return: NotNull]
    public override string ToString() => $"{Value}%";

    /// <inheritdoc/>
    public static Percent<T> operator +(Percent<T> value) => new(+value.Value);

    /// <inheritdoc/>
    public static Percent<T> operator +(Percent<T> left, Percent<T> right) => new(left.Value + right.Value);

    public static T operator +(T left, Percent<T> right) => left + right.Of(left);

    /// <inheritdoc/>
    public static Percent<T> operator -(Percent<T> value) => new(-value.Value);

    /// <inheritdoc/>
    public static Percent<T> operator -(Percent<T> left, Percent<T> right) => new(left.Value - right.Value);
    
    public static T operator -(T left, Percent<T> right) => left - right.Of(left);

    /// <inheritdoc/>
    public static Percent<T> operator *(Percent<T> left, Percent<T> right) => new(left.Value * right.Value);

    /// <inheritdoc/>
    public static Percent<T> operator /(Percent<T> left, Percent<T> right) => new(left.Value / right.Value);

    /// <inheritdoc/>
    public static bool operator ==(Percent<T> left, Percent<T> right) => left.Equals(right);

    /// <inheritdoc/>
    public static bool operator !=(Percent<T> left, Percent<T> right) => !left.Equals(right);

    /// <summary>
    /// Takes this <see cref="Percent{T}"/> of the <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to get the percentage of.</param>
    /// <returns>This percentage of <paramref name="value"/>.</returns>
    public T Of(T value) => value * (Value / OneHundred);
}