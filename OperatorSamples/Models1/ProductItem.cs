namespace OperatorSamples.Models1;

#pragma warning disable CS8618

public class ProductItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public override string ToString() => ProductName;

    public static explicit operator ProductItem(Product product) =>
        new()
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            UnitPrice = product.UnitPrice,
            UnitsInStock = product.UnitsInStock,
        };
}


