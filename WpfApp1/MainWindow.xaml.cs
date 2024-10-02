using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}

public static class Extensions
{
    public static IEnumerable<T> Descendants<T>(DependencyObject dependencyItem) where T : DependencyObject
    {
        if (dependencyItem == null) yield break;
        for (var index = 0; index < VisualTreeHelper.GetChildrenCount(dependencyItem); index++)
        {
            var child = VisualTreeHelper.GetChild(dependencyItem, index);
            if (child is T dependencyObject)
            {
                yield return dependencyObject;
            }

            foreach (var childOfChild in Descendants<T>(child))
            {
                yield return childOfChild;
            }
        }
    }
}