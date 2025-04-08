🧪 Example Usage

```csharp
var validator = new InterfaceValidator();

Type classType = typeof(Customer);
Type[] requiredInterfaces = { typeof(IFirst), typeof(ISecond) };

if (!validator.ImplementsAllInterfaces(classType, requiredInterfaces))
{
    var missing = validator.GetUnimplementedInterfaces(classType, requiredInterfaces);
    Console.WriteLine("Missing: " + string.Join(", ", missing.Select(i => i.Name)));
}

```