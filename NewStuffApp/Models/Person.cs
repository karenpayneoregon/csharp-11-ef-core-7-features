#nullable disable
using System.ComponentModel;

namespace NewStuffApp.Models;

internal partial class Person : Base, INotifyPropertyChanged
{
    public string FirstName
    {
        get => field.TrimEnd();
        set => SetField(ref field, value, nameof(FirstName));
    }

    public string LastName
    {
        get => field.TrimEnd();
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

    public partial string Remarks { get; set; }

}