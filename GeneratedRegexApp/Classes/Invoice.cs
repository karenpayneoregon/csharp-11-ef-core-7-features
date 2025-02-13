#nullable disable

namespace GeneratedRegexApp.Classes;


/// <summary>
/// Represents an invoice with an identifier and a number.
/// </summary>
public class Invoice
{
    public int Id { get; set; }
    public string Number { get; set; }
    public override string ToString() => $"{Id,-4}{Number}";
}