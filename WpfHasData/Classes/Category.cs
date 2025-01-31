using System.Collections.ObjectModel;
#nullable disable
namespace WpfHasData.Classes;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; private set; } 
        = new ObservableCollection<Product>();
}