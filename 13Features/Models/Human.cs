using System.ComponentModel;

namespace Net9Features.Models;

public class Human : INotifyPropertyChanged
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

    public DateOnly BirthDate
    {
        get;
        set => SetField(ref field, value, nameof(BirthDate));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetField<T>(ref T field, T value, string propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}