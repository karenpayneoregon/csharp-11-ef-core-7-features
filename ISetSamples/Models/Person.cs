
// ReSharper disable NonReadonlyMemberInGetHashCode
#nullable disable
using System.ComponentModel;
#pragma warning disable CA1067

namespace ISetSamples.Models;

public class Person : INotifyPropertyChanged, IEquatable<Person>
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private DateOnly _birthDate;

    public int Id
    {
        get => _id;
        set
        {
            if (value == _id) return;
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

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

    public bool Equals(Person compareTo) 
        => (FirstName == compareTo.FirstName && 
            LastName == compareTo.LastName && 
            BirthDate == compareTo.BirthDate);

    public override int GetHashCode() 
        => HashCode.Combine(FirstName, LastName, BirthDate);

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public override string ToString() => $"{FirstName,-12}{LastName}";
}
