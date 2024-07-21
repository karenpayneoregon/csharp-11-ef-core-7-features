using PropertyChangedApp1.Models;

namespace PropertyChangedApp1;

internal partial class Program
{
    static void Main(string[] args)
    {
        Customer customer = new()
        {
            FirstName = "John", 
            LastName = "Doe", 
            BirthDate = new DateOnly(1999, 1, 1)
        };
        
        customer.FirstName = "John";
        customer.FirstName = "Jane";
    }
}