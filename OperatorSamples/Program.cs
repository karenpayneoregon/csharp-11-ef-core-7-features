namespace OperatorSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<M1.Product> products1 =
        [
            new M1.Product { ProductId = 1, ProductName = "Apples", UnitPrice = 12.99m, UnitsInStock = 123 },
            new M1.Product { ProductId = 2, ProductName = "Pears", UnitPrice = 3.99m, UnitsInStock = 3 }
        ];

        List<M2.Product> products2 =
        [
            new M2.Product { ProductId = 1, ProductName = "Apples", UnitPrice = 12.99m, UnitsInStock = 123 },
            new M2.Product { ProductId = 2, ProductName = "Pears", UnitPrice = 3.99m, UnitsInStock = 3 }
        ];

        
        AnsiConsole.MarkupLine("[yellow]Explicit[/]");
        List<M1.ProductItem> explicitList = products1.Select(pc => (M1.ProductItem)pc).ToList();
        explicitList.ForEach(x => Console.WriteLine($"{x.ProductId,-3}{x.ProductName,-10}{x.UnitPrice:C}"));
        Console.WriteLine();

        AnsiConsole.MarkupLine("[yellow]Implicit[/]");
        List<M2.ProductItem> implicitList = products2.Select<M2.Product, M2.ProductItem>(p => p).ToList();
        implicitList.ForEach(x => Console.WriteLine($"{x.ProductId,-3}{x.ProductName,-10}{x.UnitPrice:C}"));

        AnsiConsole.MarkupLine("[cyan]Done[/]");
        Console.ReadLine();
    }
}