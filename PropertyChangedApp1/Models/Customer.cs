using System.ComponentModel;


namespace PropertyChangedApp1.Models;

public partial class Customer : INotifyPropertyChanged
{
    public string FirstName
    {
        get => _firstName;
        set => SetField(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }

    public DateOnly BirthDate
    {
        get => _birthDate;
        set => SetField(ref _birthDate, value);
    }
}

