using System.Text.RegularExpressions;

namespace InterfaceLibrary;

public static partial class Helpers
{

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
            .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
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