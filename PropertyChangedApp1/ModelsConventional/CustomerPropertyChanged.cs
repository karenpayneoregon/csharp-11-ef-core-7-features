using System.ComponentModel;

namespace PropertyChangedApp1.ModelsConventional;

public partial class Customer
{
    private string _firstName;
    private string _lastName;
    private DateOnly _birthDate;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
