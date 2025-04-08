
namespace InterfaceLibrary.Interfaces;

public interface IInterfaceValidator
{
    bool ImplementsAllInterfaces(Type classType, params Type[] interfaces);
    bool ImplementsAnyInterface(Type classType, params Type[] interfaces);
    IEnumerable<Type> GetUnimplementedInterfaces(Type classType, params Type[] interfaces);
}