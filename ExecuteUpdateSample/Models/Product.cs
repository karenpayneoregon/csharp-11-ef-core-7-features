namespace ExecuteUpdateSample.Models;

public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }
    public double Price { get; set; }
    public virtual Category Category { get; set; } = null!;
    public override string ToString() => Name;

}
