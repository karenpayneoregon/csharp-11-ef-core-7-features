#nullable disable
using System.ComponentModel;

namespace NewStuffApp.Models;

internal partial class Person : INotifyPropertyChanged
{
    public string FirstName
    {
        get;
        set => SetField(ref field, value);
    }

    public string LastName
    {
        get;
        set => SetField(ref field, value);
    }

    public DateTime BirthDate
    {
        get;
        set => SetField(ref field, value);
    }

    public Gender Gender
    {
        get;
        set => SetField(ref field, value);
    }
}