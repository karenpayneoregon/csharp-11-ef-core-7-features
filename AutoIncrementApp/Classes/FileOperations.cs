using System.Text.Json;
using AutoIncrementApp.Models;

namespace AutoIncrementApp.Classes;

/// <summary>
/// Provides functionality for file operations related to managing customer data.
/// </summary>
/// <remarks>
/// This class includes methods for creating, reading, and writing customer data to a JSON file.
/// It also provides utility properties for file management, such as checking file existence.
/// </remarks>
public class FileOperations
{
    // will read/write to the application folder
    public static string FileName => "Customers.json";
    public static bool FileDoesNotExists => !File.Exists(FileName);
    
    /// <summary>
    /// Creates a predefined list of <see cref="Customer"/> objects.
    /// </summary>
    /// <returns>A list of <see cref="Customer"/> objects with sample data.</returns>
    public static List<Customer> CreateCustomers() =>
    [
        new() { Id = 100, Name = "Example", InvoiceValue = "EXA00001" },
        new() { Id = 200, Name = "Karen Payne", InvoiceValue = "KP00001" },
        new() { Id = 300, Name = "Sample", InvoiceValue = "SAM00012" }
    ];

    /// <summary>
    /// Writes the provided list of customers to a JSON file.
    /// </summary>
    /// <param name="customers">The list of <see cref="Customer"/> objects to be serialized and written to the file.</param>
    public static void WriteCustomers(List<Customer> customers)
    {
        File.WriteAllText(FileName, JsonSerializer.Serialize(customers, Indented));
    }

    /// <summary>
    /// Reads a list of <see cref="Customer"/> objects from a JSON file.
    /// </summary>
    /// <returns>A list of <see cref="Customer"/> objects deserialized from the JSON file.</returns>
    /// <exception cref="FileNotFoundException">
    /// Thrown if the file specified by <see cref="FileOperations.FileName"/> does not exist.
    /// </exception>
    /// <exception cref="JsonException">
    /// Thrown if the JSON content in the file is invalid or cannot be deserialized into a list of <see cref="Customer"/> objects.
    /// </exception>
    public static List<Customer> ReadCustomers()
        => JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText(FileName));

    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}