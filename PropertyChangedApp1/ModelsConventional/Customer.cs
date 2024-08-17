using System.ComponentModel;

namespace PropertyChangedApp1.ModelsConventional;
public partial class Customer : INotifyPropertyChanged
{
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName) return;
            _firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName) return;
            _lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    public DateOnly BirthDate
    {
        get => _birthDate;
        set
        {
            if (value.Equals(_birthDate)) return;
            _birthDate = value;
            OnPropertyChanged(nameof(BirthDate));
        }
    }
}
