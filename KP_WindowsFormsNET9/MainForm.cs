
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using KP_WindowsFormsNET9.Models;

namespace KP_WindowsFormsNET9;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    [Experimental("WFO5002")]
    private async void ShowFormButton_Click(object sender, EventArgs e)
    {
        ChildForm childForm = new();
        await childForm.ShowDialogAsync();
    }

    private void PersonPartialButton_Click(object sender, EventArgs e)
    {
        List<Person> list =
        [
            new() { FirstName = "John", LastName = "Doe" },
            new() { FirstName = "Jane", LastName = "Doe" }
        ];

        foreach (var (index, person) in list.Index())
        {
            Debug.WriteLine($"{index,-3}{person.FirstName,-8}{person.LastName}");
        }

        Debug.WriteLine("");

        var firstPerson = list[0];
        Debug.WriteLine($"{firstPerson[0],-8}{firstPerson[1]}");
    }
}


