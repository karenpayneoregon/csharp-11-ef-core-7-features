#nullable disable
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;
using AspectsDumpApp.Classes;
using vm.Aspects;
using vm.Aspects.Diagnostics;

namespace AspectsDumpApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void MaskedSsnButton_Click(object sender, EventArgs e)
    {
        //Debug.WriteLine(MockedData.GetPersons().DumpString());
        AppLogger.Instance.Logger.Information("People {@P}",
            MockedData.GetPersons().DumpString());
    }

    private void DumpDictionaryButton_Click(object sender, EventArgs e)
    {
        AppLogger.Instance.Logger.Information("People {@D}",
            MockedData.GetDictionary().DumpString());
    }

    private void DumpExpressionButton_Click(object sender, EventArgs e)
    {
        
        Expression<Func<int>> expression = () => 1 + 2;
        Debug.WriteLine(expression.DumpCSharpText());

        ConstantExpression constant = Expression.Constant("Hello World", typeof(string));
        Debug.WriteLine(constant.DumpCSharpText());

    }
}