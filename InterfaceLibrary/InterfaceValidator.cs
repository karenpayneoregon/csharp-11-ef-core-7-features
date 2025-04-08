using InterfaceLibrary.Interfaces;

namespace InterfaceLibrary;

/// <summary>
/// Provides functionality to validate whether a class type implements specific interfaces.
/// </summary>
public class InterfaceValidator : IInterfaceValidator
{
    public bool ImplementsAllInterfaces(Type classType, params Type[] interfaces)
    {
        ValidateInput(classType, interfaces);

        return interfaces.All(iface => iface.IsAssignableFrom(classType));
    }

    public bool ImplementsAnyInterface(Type classType, params Type[] interfaces)
    {
        ValidateInput(classType, interfaces);

        return interfaces.Any(iface => iface.IsAssignableFrom(classType));
    }

    public IEnumerable<Type> GetUnimplementedInterfaces(Type classType, params Type[] interfaces)
    {
        ValidateInput(classType, interfaces);

        return interfaces.Where(iface => !iface.IsAssignableFrom(classType)).ToList();
    }

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