
using System.Text.Json;

namespace WinFormsApp1;
public partial class StackoverflowForm : Form
{
    public StackoverflowForm()
    {
        InitializeComponent();

        List<Item> list =
        [
            new Item() { Id = 1, Name = "One" },
            new Item() { Id = 2, Name = "Two" },
            new Item() { Id = 3, Name = "Three"}
        ];

        comboBox1.DataSource = list;

        var xx = list.Select((item, indexer) =>
            new { Item = item, Index = indexer }).ToList();
        var selected = xx.FirstOrDefault(x => x.Item.Id == 2);
        if (selected is not null)
        {
            comboBox1.SelectedIndex = selected.Index;
        }

    }

    private void SelectedItemButton_Click(object sender, EventArgs e)
    {


        Item item = comboBox1.SelectedItem as Item;
        MessageBox.Show($"Id: {item!.Id} - {item.Name}");
    }

    private void YearsOldButton_Click(object sender, EventArgs e)
    {
        {
            int now = 2024_10_15;
            int dob = 1956_09_24;
            var age = (now - dob) / 10000;
        }

        {
            DateOnly dateOfBirth = new(1956, 9, 24);
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));

            int age = (now - dob) / 10000;
        }

        {
            DateOnly dateOfBirth = new(1956, 9, 24);
            int age = dateOfBirth.GetAge();

        }

    }

    private void button1_Click(object sender, EventArgs e)
    {

    }
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}

public static class DateOnlyExtensions
{
    public static int GetAge(this DateOnly dateOfBirth)
    {
        var (nYear, nMonth, nDay) = DateTime.Today;

        var a = (nYear * 100 + nMonth) * 100 + nDay;
        var (bYear, bMonth, bDay) = dateOfBirth;
        var b = (bYear * 100 + bMonth) * 100 + bDay;

        return (a - b) / 10000;
    }
}
