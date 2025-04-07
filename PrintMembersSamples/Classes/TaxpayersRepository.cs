using PrintMembersSamples.Models;

namespace PrintMembersSamples.Classes;

public class TaxpayersRepository
{
    public static List<Taxpayer> SampleTaxpayers() =>
    [
        new Taxpayer("John", "Doe", "123-45-6789"),
        new Taxpayer("Jane", "Smith", "987-65-4321"),
        new Taxpayer("Robert", "Johnson", "456-78-9012"),
        new Taxpayer("Emily", "Davis", "321-54-9876"),
        new Taxpayer("Michael", "Brown", "741-85-2963"),
        new Taxpayer("Linda", "Wilson", "852-96-3147"),
        new Taxpayer("David", "Martinez", "963-74-1258"),
        new Taxpayer("Susan", "Clark", "159-26-3847"),
        new Taxpayer("James", "Lopez", "753-19-8462"),
        new Taxpayer("Karen", "Walker", "842-13-5796")
    ];
}