namespace KP_WindowsFormsNET9.EFCore.Sample1.Models;

public record struct CustomerInfo(string? Tag)
{
    public required Address HomeAddress { get; init; }
    public required Address WorkAddress { get; init; }
}