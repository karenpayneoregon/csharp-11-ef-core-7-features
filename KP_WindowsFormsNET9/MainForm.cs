
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using KP_WindowsFormsNET9.Classes;
using KP_WindowsFormsNET9.Models;
// ReSharper disable MoveLocalFunctionAfterJumpStatement

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
        try
        {
            ChildForm childForm = new();
            await childForm.ShowDialogAsync();
        }
        catch (Exception localException)
        {
            Debug.WriteLine(localException.Message);
        }
    }

    private void PersonPartialButton_Click(object sender, EventArgs e)
    {

        var list = BogusOperations.Persons();

        foreach (var (index, person) in list.Index())
        {
            Debug.WriteLine($"{index,-3}{person.Id,-3}{person.FirstName,-8}{person.LastName}");
        }

        Debug.WriteLine("");

        var firstPerson = list[0];
        Debug.WriteLine($"{firstPerson[0],-8}{firstPerson[1]}");
        Debug.WriteLine(new string('-', 50));
    }

    private void FieldKeywordButton_Click(object sender, EventArgs e)
    {
        Customer customer = new()
        {
            FirstName = "john  ",
            LastName = "doe  "
        };


        Debug.WriteLine($"First name '{customer.FirstName}'");
        Debug.WriteLine($"Last name  '{customer.LastName}'");

    }


    /// <summary>
    /// Handles the click event of the FuncMethodGroupButton.
    /// Demonstrates the usage of a method group with a <see cref="Func{TResult}"/> delegate.
    ///
    /// Method group natural type improvements
    /// https://devblogs.microsoft.com/dotnet/csharp-13-explore-preview-features/#method-group-natural-type-improvements
    /// 
    /// </summary>
    private void FuncMethodGroupButton_Click(object sender, EventArgs e)
    {

        void Demo(Func<DemoItem> item)
        {
            var demoItem = item();
            Debug.WriteLine($"Item Id: {demoItem.Id}, Name: {demoItem.Name}");
        }

        DemoItem GetItem() => new(Id: 10, Name: "Karen Payne");
        Func<DemoItem> f = GetItem;

        Demo(f);

    }
}