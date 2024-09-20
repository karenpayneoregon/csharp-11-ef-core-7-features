#nullable disable
using AspectsDumpApp;
using vm.Aspects.Diagnostics;

namespace AspectsDumpApp.Models;

public class Address
{
    [Dump(1)]
    public int Id { get; set; }
    [Dump(2)]
    public string Street { get; set; }
    [Dump(3)]
    public string City { get; set; }
    [Dump(4)]
    public string State { get; set; }
}