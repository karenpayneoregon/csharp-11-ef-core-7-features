#nullable disable
using System.ComponentModel;

namespace NewStuffApp.Models;

internal partial class Person : INotifyPropertyChanged
{
    public int Id
    {
        get;
        set => SetField(ref field, value, nameof(Id));
    }

    public string FirstName
    {
        get;
        set => SetField(ref field, value, nameof(FirstName));
    }

    public string LastName
    {
        get;
        set => SetField(ref field, value, nameof(LastName));
    }

    public DateTime BirthDate
    {
        get;
        set => SetField(ref field, value, nameof(BirthDate));
    }

    public Gender Gender
    {
        get;
        set => SetField(ref field, value, nameof(Gender));
    }
}