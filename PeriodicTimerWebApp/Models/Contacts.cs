#nullable disable

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PeriodicTimerWebApp.Models;

public class Contacts : INotifyPropertyChanged
{
    private int _contactId;
    private string _firstName;
    private string _lastName;
    private int? _contactTypeIdentifier;

    public int ContactId
    {
        get => _contactId;
        set
        {
            if (value == _contactId) return;
            _contactId = value;
            OnPropertyChanged();
        }
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName) return;
            _firstName = value;
            OnPropertyChanged();
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName) return;
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public int? ContactTypeIdentifier
    {
        get => _contactTypeIdentifier;
        set
        {
            if (value == _contactTypeIdentifier) return;
            _contactTypeIdentifier = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}