
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
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}
