#nullable disable
using vm.Aspects.Diagnostics;

namespace AspectsDumpApp.Models;

public class Human
{
    [Dump(1)]
    public int Id { get; set; }
    [Dump(2)]
    public string FirstName { get; set; }
    [Dump(3)]
    public string LastName { get; set; }
}