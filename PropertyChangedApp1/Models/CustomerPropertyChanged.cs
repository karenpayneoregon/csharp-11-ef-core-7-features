using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PropertyChangedApp1.Models;
public partial class Customer
{
    private string _firstName;
    private string _lastName;
    private DateOnly _birthDate;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
