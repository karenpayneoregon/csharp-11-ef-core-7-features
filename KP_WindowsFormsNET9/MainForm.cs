using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using KP_WindowsFormsNET9.Classes;
using KP_WindowsFormsNET9.Models;

using static TaskDialogLibrary.Dialogs;

using KP_WindowsFormsNET9.EFCore.Sample1;
using KP_WindowsFormsNET9.Classes.Configuration;
using System.Text.Json.Schema;
using System;


// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable MoveLocalFunctionAfterJumpStatement

namespace KP_WindowsFormsNET9;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        Text = Configuration.Instance.ModeText;

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

        var list = BogusOperations.People();

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

    /// <summary>
    /// params collection
    /// Calculates the sum of a collection of integers and displays the result in an information dialog.
    /// </summary>
    private void ParamCollectionButton_Click(object sender, EventArgs e)
    {
        int Calculate(params IEnumerable<int> numbers) => numbers.Sum();
        List<int> numbers = [5, 10, 10];
        int results = Calculate(numbers.ToArray());

        Information(ParamCollectionButton, "Result", results.ToString(), "Cool");


    }

    /// <summary>
    /// Reads a list of banned words from a JSON file
    /// Reads test data from a text file
    /// Test each sentence for banned words from the text file
    /// </summary>
    private void SearchValuesButton_Click(object sender, EventArgs e)
    {


        // contains a list of banned words
        var json = File.ReadAllText("bannedwords.json");

        // deserialize the json to a list of banned words
        var words = JsonSerializer.Deserialize<List<BannedWord>>(json)!
            .Select(x => x.Name).ToArray();

        // contains a list of sentences to check for banned words
        var sentences = File.ReadAllLines("TestBanneded.txt");

        // check each sentence for banned words
        foreach (var (index, item) in sentences.Index())
        {
            Debug.WriteLine(item.HasBannedWords(words)
                ? $"{index,-5}contains banned words"
                : $"{index,-5}is clean");
        }

    }

    private void SearchValuesButton1_Click(object sender, EventArgs e)
    {
        string[] dates = ["11/8/2024", "11/9/2024"];

        var sentences = File.ReadAllLines("EF_Log.txt");

        foreach (var (index, line) in sentences.Index())
        {
            if (line.HasDates(dates))
            {
                Debug.WriteLine($"Line {index + 1}");
            }
        }
    }

    /// <summary>
    /// Attempt to read the activity log file which.
    /// - May not exist or if exists may be locked.
    /// - May not have the correct permissions to read the file.
    /// 
    /// </summary>
    private void SearchValuesActivityLogButton_Click(object sender, EventArgs e)
    {
        try
        {
            var (lines, success) = FileOperations.GetActivityLog();
            if (success)
            {
                /*
                 * Note in this case the first instance of error is in a comment.
                 */
                foreach (var (index, line) in lines.Index())
                {
                    if (line.LineHasWarningOrError())
                    {
                        Debug.WriteLine($"{index + 1,-10}{line}");
                    }
                }

                AutoCloseDialog(this, "Done", "", 1, "Bye");
            }
            else
            {
                MessageBox.Show("Dang, operation failed.");
            }
        }
        catch (Exception ex)
        {
            ErrorBox(ex);
        }
    }

    private async void ComplexTypeButton_Click(object sender, EventArgs e)
    {
        try
        {
            await ComplexTypesSample.GroupByComplexTypeInstances();
            Information(this, "", "Finish", "Okay");
        }
        catch (Exception localException)
        {
            Information(this, "Error", localException.Message, "Done");
        }
    }

    /// <summary>
    /// This method counts the number of users by their roles and writes the count to the debug output.
    /// </summary>
    private void CountByButton_Click(object sender, EventArgs e)
    {

        CountByWithCount();

        Debug.WriteLine("");

        GroupByWithCount();

    }

    private void CountByWithCount()
    {
        var users = MockedData.Users();

        foreach (var roleCount in users.CountBy(user => user.Role))
        {
            Debug.WriteLine($"There are {roleCount.Value} users with the role {roleCount.Key}");
        }

    }

    private void GroupByWithCount()
    {
        var users = MockedData.Users();

        var groupedUsers = users.GroupBy(user => user.Role)
            .Select(group => new { Role = group.Key, Count = group.Count() });

        foreach (var group in groupedUsers)
        {
            Debug.WriteLine($"Role: {group.Role}, Count: {group.Count}");
        }
    }

    /// <summary>
    /// Aggregates the remaining vacation days  for employees by their department
    /// </summary>
    private void AggregateByButton_Click(object sender, EventArgs e)
    {
        GroupByAggregateBySample();
        Debug.WriteLine("");
        AggregateBySample();
    }

    private static void GroupByAggregateBySample()
    {
        var kvp = MockedData.Employees
            .GroupBy(emp => emp.department)
            .Select(group => new KeyValuePair<string, int>(group.Key, group.Sum(emp
                => emp.vacationDaysLeft)));

        foreach (var (key, value) in kvp)
        {
            Debug.WriteLine($"Department {key,-15} has a total of {value} vacation days left.");
        }
    }
    private static void AggregateBySample()
    {
        var kvp = MockedData.Employees
            .AggregateBy(emp => emp.department, 0, (acc, emp)
                => acc + emp.vacationDaysLeft);

        foreach (var (key, value) in kvp)
        {
            Debug.WriteLine($"Department {key,-15} has a total of {value} vacation days left.");
        }
    }

    private void AppSettingsButton_Click(object sender, EventArgs e)
    {
        using var form = new SettingsForm();
        form.ShowDialog();
    }

    private void OverloadResolutionPriorityButton_Click(object sender, EventArgs e)
    {
        OverloadResolutionPriorityDemo.DisplayInvoice("ABC0");
    }

    private void GetJsonSchemaAsNodeButton_Click(object sender, EventArgs e)
    {

        Debug.WriteLine("");
        Debug.WriteLine(JsonSerializerOptions.Default.GetJsonSchemaAsNode(typeof(Customer)));

    }

    private void EnumerableIndexButton_Click(object sender, EventArgs e)
    {
        var list = BogusOperations.People();

        foreach (var (index, person) in list.Index())
        {
            Debug.WriteLine($"{index,-3}{person.Id,-3}{person.FirstName,-8}{person.LastName}");
        }
    }

    /// <summary>
    /// Handles the click event for the "Create Version 7 GUID" button.
    /// Generates two Version 7 GUIDs and writes them to the debug output.
    /// </summary>
    /// <remarks>
    /// https://learn.microsoft.com/en-us/dotnet/api/system.guid.createversion7?view=net-9.0
    /// </remarks>
    private void GuidCreateVersion7Button_Click(object sender, EventArgs e)
    {
        //Creates a new Guid according to RFC 9562, following the Version 7 format.
        var item1 = Guid.CreateVersion7();

        //Creates a new Guid according to RFC 9562, following the Version 7 format with DateTimeOffset
        var item2 = Guid.CreateVersion7(TimeProvider.System.GetUtcNow());

        Debug.WriteLine(item1);
        Debug.WriteLine(item2);
    }
}