using System.Text.RegularExpressions;

namespace InterfaceLibrary;

public static partial class Helpers
{

    /// <summary>
    /// Determines whether a specified class type implements a specified interface type.
    /// </summary>
    /// <typeparam name="TClass">
    /// The class type to check for implementation of the interface.
    /// </typeparam>
    /// <typeparam name="TInterface">
    /// The interface type to check for implementation by the class.
    /// </typeparam>
    /// <returns>
    /// <c>true</c> if <typeparamref name="TClass"/> implements <typeparamref name="TInterface"/>; otherwise, <c>false</c>.
    /// </returns>
    public static bool ImplementsInterface<TClass, TInterface>() 
        => typeof(TInterface).IsInterface && typeof(TInterface).IsAssignableFrom(typeof(TClass));

    /// <summary>
    /// Determines whether a specified class type implements all the specified interface types.
    /// </summary>
    /// <typeparam name="TClass">
    /// The class type to check for implementation of the interfaces.
    /// </typeparam>
    /// <param name="interfaces">
    /// An array of interface types to check for implementation by the class.
    /// </param>
    /// <returns>
    /// <c>true</c> if <typeparamref name="TClass"/> implements all the specified interfaces; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when no interface types are provided or when a provided type is not an interface.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown when one of the provided interface types is <c>null</c>.
    /// </exception>
    public static bool ImplementsInterfaces<TClass>(params Type[] interfaces)
    {
        var classType = typeof(TClass);

        if (interfaces == null || interfaces.Length == 0)
            throw new ArgumentException("At least one interface type must be provided.", nameof(interfaces));

        foreach (var iface in interfaces)
        {
            if (iface == null)
                throw new ArgumentNullException(nameof(interfaces), "One of the provided interface types is null.");

            if (!iface.IsInterface)
                throw new ArgumentException($"Type {iface.Name} is not an interface.", nameof(interfaces));

            if (!iface.IsAssignableFrom(classType))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Identifies the interfaces from the provided list that are not implemented by the specified class type.
    /// </summary>
    /// <typeparam name="TClass">
    /// The class type to check for unimplemented interfaces.
    /// </typeparam>
    /// <param name="interfaces">
    /// An array of interface types to check against the specified class type.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the interface types that are not implemented by <typeparamref name="TClass"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when no interface types are provided or when a provided type is not an interface.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown when one of the provided interface types is <c>null</c>.
    /// </exception>
    public static IEnumerable<Type> GetUnimplementedInterfaces<TClass>(params Type[] interfaces)
    {
        var classType = typeof(TClass);

        if (interfaces == null || interfaces.Length == 0)
            throw new ArgumentException("At least one interface type must be provided.", nameof(interfaces));

        foreach (var iface in interfaces)
        {
            if (iface == null)
                throw new ArgumentNullException(nameof(interfaces), "One of the provided interface types is null.");
            if (!iface.IsInterface)
                throw new ArgumentException($"Type {iface.Name} is not an interface.", nameof(interfaces));

            if (!iface.IsAssignableFrom(classType))
                yield return iface;
        }
    }



    /// <summary>
    /// Retrieves the names of all entities that implement a specified interface type.
    /// </summary>
    /// <typeparam name="T">
    /// The interface type to search for. Must be a class type and an interface.
    /// </typeparam>
    /// <returns>
    /// A list of strings representing the names of all entities that implement the specified interface.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the specified type <typeparamref name="T"/> is not an interface.
    /// </exception>
    public static List<string> GetAllEntityNames<T>() where T : class
    {
        if (!typeof(T).IsInterface)
            throw new ArgumentException("T must be an interface.");

        return GetAllEntities<T>()
            .Select(x => x.Name)
            .ToList();
    }

    /// <summary>
    /// Retrieves all types that implement a specified interface type.
    /// </summary>
    /// <typeparam name="T">
    /// The interface type to search for. Must be a class type and an interface.
    /// </typeparam>
    /// <returns>
    /// A list of <see cref="Type"/> objects representing all types that implement the specified interface.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the specified type <typeparamref name="T"/> is not an interface.
    /// </exception>
    public static List<Type> GetAllEntities<T>() where T : class
    {
        if (!typeof(T).IsInterface)
            throw new ArgumentException("T must be an interface.");

        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(T).IsAssignableFrom(x) && 
                        x is { IsInterface: false, IsAbstract: false })
            .ToList();
    }

    /// <summary>
    /// Retrieves the generic type arguments of all <see cref="IEnumerable{T}"/> interfaces
    /// implemented by the specified object.
    /// </summary>
    /// <param name="sender">
    /// The object whose implemented <see cref="IEnumerable{T}"/> interfaces are to be inspected.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="Type"/> objects representing the generic type
    /// arguments of all <see cref="IEnumerable{T}"/> interfaces implemented by the specified object.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="sender"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<Type> GetGenericIEnumerable(object sender) =>
        sender
            .GetType()
            .GetInterfaces()
            .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .Select(t => t.GetGenericArguments()[0]);


}