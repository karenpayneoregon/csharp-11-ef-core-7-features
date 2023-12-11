#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ComplexTypesSampleApp.Models;
/// <summary>
/// For application connection strings
/// </summary>
public class ConnectionStrings
{
    public string MainConnection { get; set; }
    public string SecondaryConnection { get; set; }
}
