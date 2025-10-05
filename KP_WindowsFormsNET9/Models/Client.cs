#nullable disable
using System.ComponentModel;

namespace KP_WindowsFormsNET9.Models;

public partial class Client : INotifyPropertyChanged
{
    public int Id { get; set; }

    public partial string FirstName { get; set; }
    public partial string LastName { get; set; }
    

}

