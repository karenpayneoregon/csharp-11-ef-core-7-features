#nullable disable
using AspectsDumpApp;
using vm.Aspects.Diagnostics;

namespace AspectsDumpApp.Models;

[Dump(DumpNullValues = ShouldDump.Skip, Enumerate = ShouldDump.Dump)]
public class Person
{
    [Dump(1)]
    public int Id { get; set; }
    [Dump(3)]
    public string FirstName { get; set; }
    [Dump(4)]
    public string LastName { get; set; }

    [Dump(5, DumpNullValues = ShouldDump.Skip)]
    public DateOnly BirthDate { get; set; }

    [Dump(2,Mask = true)]
    public string SSN { get; set; }

    [Dump(6)]
    public Address Address { get; set; }
}

public class Human
{
    [Dump(1)]
    public int Id { get; set; }
    [Dump(2)]
    public string FirstName { get; set; }
    [Dump(3)]
    public string LastName { get; set; }
}