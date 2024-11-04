using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using UUIDNext;
using WinFormsApp2.Classes;

namespace WinFormsApp2;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void selectCustomerButton_Click(object sender, EventArgs e)
    {
        using var f = new CustomerSelectForm();
        CustomerSelectForm.CustomerSelected += CustomerSelected;
        f.ShowDialog();
        CustomerSelectForm.CustomerSelected -= CustomerSelected;
    }

    private void CustomerSelected(Models.Customer sender)
    {
        // populate the textboxes
    }



    private void revealPasswordButton_MouseDown(object sender, MouseEventArgs e)
    {
        passwordTextBox.ToggleShow();
    }

    private void revealPasswordButton_MouseUp(object sender, MouseEventArgs e)
    {
        passwordTextBox.ToggleShow(false);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        passwordTextBox.ToggleShow(false);
    }

    private void revealPasswordButton_Click(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
        using var form = new Form3();
        form.MenuEnable += OnMenuEnable;
        form.ShowDialog();
    }

    private void OnMenuEnable(bool sender)
    {
        M_Selecao.Enabled = sender;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        //string randomAlphanumericString = RandomNumberGenerator.GetString(
        //    choices: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789",
        //    length: 10
        //);
        //Debug.WriteLine(randomAlphanumericString);

        Debug.WriteLine(Helpers.RandomNumberString(20));
        string[] names = ["John", "Karen", "Adam", "Kevin", "Mary", "Ben", "Terry"];
        var result = names.RandomElements(3);
        Debug.WriteLine(string.Join(", ", result));

    }

    private void UUIDButton_Click(object sender, EventArgs e)
    {

        for (int index = 0; index < 5; index++)
        {
            Guid sequentialUuid = Uuid.NewDatabaseFriendly(Database.SqlServer);
            Debug.WriteLine($"{index,4} UUID : {sequentialUuid}");
        }
    }
}

public static class Helpers
{
    public static string RandomNumberString(int length) =>
        RandomNumberGenerator.GetString(
            choices: new string('a'.To('z').Concat('A'.To('Z')).Concat('0'.To('9')).ToArray()),
            length: length
        );
    public static T[] RandomElements<T>(this T[] source, int count) =>
        RandomNumberGenerator.GetItems<T>(source,count);

    public static IEnumerable<char> To(this char start, char end) => 
        Enumerable.Range(start, end - start + 1).Select(index => (char)index);
}

