using System.Text.Json;
using AutoIncrementApp.Models;

namespace AutoIncrementApp.Classes;

public class FileOperations
{
    // will read/write to the application folder
    public static string FileName => "Customers.json";
    public static bool FileDoesNotExists => !File.Exists(FileName);
    // for creating initial file
    public static List<Customer> CreateCustomers() =>
    [
        new() { Id = 100, Name = "Example", InvoiceValue = "EXA00001" },
        new() { Id = 200, Name = "Karen Payne", InvoiceValue = "KP00001" },
        new() { Id = 300, Name = "Sample", InvoiceValue = "SAM00012" }
    ];

    // write customers to file
    public static void WriteCustomers(List<Customer> customers)
    {
        File.WriteAllText(FileName, JsonSerializer.Serialize(customers, 
            new JsonSerializerOptions { WriteIndented = true }));
    }

    // read customers from file
    public static List<Customer> ReadCustomers()
        => JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText(FileName));
}