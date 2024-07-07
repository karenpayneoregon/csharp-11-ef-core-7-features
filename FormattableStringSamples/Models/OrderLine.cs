namespace FormattableStringSamples.Models;

public class OrderLine
{
    public OrderLine(string product, double price)
    {
        Product = product;
        Price = price;
    }
    public string Product { get; }
    public double Price { get; }
}