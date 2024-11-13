#nullable disable
using System.Collections.Specialized;
using KP_WindowsFormsNET9.Interfaces;

namespace KP_WindowsFormsNET9.Models;

public partial class Person : IPerson
{
    public partial int Id { get; set; }
    public partial string this[int index] { get; set; }
    public partial string FirstName { get; set; } 
    public partial string LastName { get; set; }
    public override string ToString() => $"{FirstName,-10}{LastName}";
}