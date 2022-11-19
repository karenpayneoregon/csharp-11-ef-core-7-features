using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IMaterializationInterceptorSample.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public virtual ObservableCollectionListSource<Product> Products { get; } = new();
    public override string ToString() => Name;

}
