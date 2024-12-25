namespace NewStuffApp.Models;

internal partial class Person
{
    public int Id
    {
        get;
        set => SetField(ref field, value, nameof(Id));
    }
}