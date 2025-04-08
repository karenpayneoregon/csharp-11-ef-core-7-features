using InterfaceLibrary.Interfaces;

namespace InterfaceLibrary;

/// <summary>
/// Provides functionality to validate whether a class type implements specific interfaces.
/// </summary>
public class InterfaceValidator : IInterfaceValidator
{
    /// <summary>
    /// Determines whether the specified class type implements all the provided interfaces.
    /// </summary>
    /// <param name="classType">The type of the class to validate.</param>
    /// <param name="interfaces">An array of interface types to check against the class type.</param>
    /// <returns>
    /// <c>true</c> if the specified class type implements all the provided interfaces; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="classType"/> is <c>null</c> or one of the provided interface types is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when no interfaces are provided, or one of the provided types is not an interface.
    /// </exception>
    public bool ImplementsAllInterfaces(Type classType, params Type[] interfaces)
    {
        ValidateInput(classType, interfaces);

        return interfaces.All(iface => iface.IsAssignableFrom(classType));
    }

    /// <summary>
    /// Determines whether the specified class type implements at least one of the provided interfaces.
    /// </summary>
    /// <param name="classType">The type of the class to validate.</param>
    /// <param name="interfaces">An array of interface types to check against the class type.</param>
    /// <returns>
    /// <c>true</c> if the specified class type implements at least one of the provided interfaces; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="classType"/> is <c>null</c> or one of the provided interface types is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when no interfaces are provided, or one of the provided types is not an interface.
    /// </exception>
    public bool ImplementsAnyInterface(Type classType, params Type[] interfaces)
    {
        ValidateInput(classType, interfaces);

        return interfaces.Any(iface => iface.IsAssignableFrom(classType));
    }

    /// <summary>
    /// Retrieves the interfaces from the provided list that are not implemented by the specified class type.
    /// </summary>
    /// <param name="classType">The type of the class to validate.</param>
    /// <param name="interfaces">An array of interface types to check against the class type.</param>
    /// <returns>
    /// A collection of interface types that are not implemented by the specified class type.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="classType"/> is <c>null</c> or one of the provided interface types is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when no interfaces are provided, or one of the provided types is not an interface.
    /// </exception>
    public IEnumerable<Type> GetUnimplementedInterfaces(Type classType, params Type[] interfaces)
    {
        ValidateInput(classType, interfaces);

        return interfaces.Where(iface => !iface.IsAssignableFrom(classType)).ToList();
    }

    /// <summary>
    /// Validates the input parameters for methods that check interface implementation.
    /// </summary>
    /// <param name="classType">The type of the class to validate.</param>
    /// <param name="interfaces">An array of interface types to validate against the class type.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="classType"/> is <c>null</c> or one of the provided interface types is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when no interfaces are provided, or one of the provided types is not an interface.
    /// </exception>
    private void ValidateInput(Type classType, Type[] interfaces)
    {
        if (classType == null)
            throw new ArgumentNullException(nameof(classType));

        if (interfaces == null || interfaces.Length == 0)
            throw new ArgumentException("At least one interface must be provided.", nameof(interfaces));

        foreach (var iface in interfaces)
        {
            if (iface == null)
                throw new ArgumentNullException(nameof(interfaces), "One of the provided interface types is null.");

            if (!iface.IsInterface)
                throw new ArgumentException($"Type {iface.Name} is not an interface.", nameof(interfaces));
        }
    }
}