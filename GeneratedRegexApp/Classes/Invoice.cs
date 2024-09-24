#nullable disable

namespace GeneratedRegexApp.Classes;


public class Invoice
{

    public int Id { get; set; }

    public string Number { get; set; }
    public override string ToString() => $"{Id,-4}{Number}";

    
}