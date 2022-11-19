using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExecuteDeleteSample.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public virtual ObservableCollectionListSource<Product> Products { get; } = new();
    public override string ToString() => Name;

}
