namespace CloneRecordApp.Models;

public record Product(int Id, string Name, int CategoryId)
{
    public int Id { get; set; } = Id;
    public string Name { get; set; } = Name;
    public int CategoryId { get; set; } = CategoryId;
    public sealed override string ToString() => 
        $"{Id,-3}{CategoryId,-3}{Name, -10}";
}

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}

public class MockedData
{
    public static List<Category> Categories
        =>
        [
            new() { CategoryId = 1, Name = "Vegetable" },
            new() { CategoryId = 2, Name = "Fruit" }
        ];

}