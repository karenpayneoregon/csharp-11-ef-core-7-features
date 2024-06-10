using System.ComponentModel;
using WinFormsApp2.Models;
using static WinFormsApp2.Classes.BogusOperations;

namespace WinFormsApp2;
public partial class CustomerSelectForm : Form
{
    private BindingList<Customer> _bindingList;
    private BindingSource _bindingSource = new BindingSource();

    public delegate void OnSelectCustomer(Customer sender);
    public static event OnSelectCustomer? CustomerSelected;

    public CustomerSelectForm()
    {

        InitializeComponent();

        _bindingList = new BindingList<Customer>(CustomersWithKeysList());
        _bindingSource.DataSource = _bindingList;
        dataGridView1.DataSource = _bindingSource;

        dataGridView1.KeyDown += DataGridView1_KeyDown;

    }

    private void DataGridView1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyData != Keys.Enter) return;

        var current = (Customer)_bindingSource.Current;
        CustomerSelected?.Invoke(current);

        Close();
    }
}
