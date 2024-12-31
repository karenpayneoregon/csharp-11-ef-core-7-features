using BindingListLibrary;
using NewStuffApp.Classes;
using NewStuffApp.Models;

namespace NewStuffApp;

public partial class MainForm : Form
{
    private SortableBindingList<Person> _bindingList;
    private BindingSource _bindingSource = new();

    public MainForm()
    {
        InitializeComponent();

        dataGridView1.AutoGenerateColumns = false;

        _bindingList = new SortableBindingList<Person>(BogusOperations.PersonsList(12));
        _bindingSource.DataSource = _bindingList;
        dataGridView1.DataSource = _bindingSource;
        dataGridView1.ExpandColumns();

        RemarksLabel.DataBindings.Add("Text", _bindingSource, nameof(Person.Remarks));

        dataGridView1.DataError += (sender, e) => e.Cancel = true;



    }

    private void CurrentButton_Click(object sender, EventArgs e)
    {
        Person person = _bindingList[_bindingSource.Position];
    }

    private void ParamsButton_Click(object sender, EventArgs e)
    {
        Params.Examples();
    }
}
