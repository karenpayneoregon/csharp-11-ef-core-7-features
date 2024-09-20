using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.Extensions.Configuration;

namespace UsingIncludeInValidation;

internal partial class Program
{
    static void Main(string[] args)
    {
        
        List<IPerson> people =
        [
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(1790, 12, 1),
                Address = new Address
                {
                    Line1 = "123 Main St",
                    Line2 = "Apt 101",
                    Town = "Any town",
                    Country = "USA",
                    Postcode = "12345"
                }
            },

            new Citizen
            {
                Id = 1,
                FirstName = "Anne",
                LastName = "Doe",
                BirthDate = new DateOnly(1969, 1, 11),
                Since = new DateOnly(2020, 1, 1),
                Address = new Address
                {
                    Line2 = "Apt 101",
                    Town = "Any town",
                    Country = "USA"
                }
            }
        ];

        PersonValidator validator = new();

        foreach (var person in people)
        {
            AnsiConsole.MarkupLine($"{person} [cyan]{person.GetType().Name}[/]");

            var result = validator.Validate(person);
            if (result.IsValid)
            {
                Console.WriteLine(true);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    AnsiConsole.MarkupLine($"[red]   {error.ErrorMessage}[/]");
                }
            }
        }
        
        Console.ReadLine();

    }
}

public class PersonValidator : AbstractValidator<IPerson>
{
    public PersonValidator()
    {
        Include(new FirstNameValidator());
        Include(new LastNameValidator());
        Include(new BirthDateValidator());
        Include(new AddressValidator());
    }
}

public class FirstNameValidator : AbstractValidator<IPerson>
{
    public FirstNameValidator()
    {
        RuleFor(person => person.FirstName)
            .NotEmpty()
            .MinimumLength(3);
    }
}

public class LastNameValidator : AbstractValidator<IPerson>
{
    public LastNameValidator()
    {
        RuleFor(person => person.LastName)
            .NotEmpty()
            .MinimumLength(3);
    }
}

public class BirthDateValidator : AbstractValidator<IPerson>
{

    public BirthDateValidator()
    {

        var value = JsonRoot().GetSection(nameof(ValidationSettings)).Get<ValidationSettings>().MinYear;
        var minYear = DateTime.Now.AddYears(value).Year;

        RuleFor(x => x.BirthDate)
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage($"Birth date must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }
}

public class AddressValidator : AbstractValidator<IPerson>
{
    public AddressValidator()
    {
        RuleFor(item => item.Address.Line1).NotNull()
            .WithName("Street")
            .WithMessage("Please ensure you have entered your {PropertyName}");
        RuleFor(item => item.Address.Town).NotNull();
        RuleFor(item => item.Address.Country).NotNull();
        RuleFor(item => item.Address.Postcode).NotNull();
    }
}

public interface IPerson  : IFormattable
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly BirthDate { get; set; }
    Address Address { get; set; }
}

public class Person : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Address Address { get; set; }
    string IFormattable.ToString(string format, IFormatProvider formatProvider) 
        => $"{FirstName} {LastName}";
}

public class Citizen : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly Since { get; set; }
    public Address Address { get; set; }
    string IFormattable.ToString(string format, IFormatProvider formatProvider)
        => $"{FirstName} {LastName}";
}

public class Address
{
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string Town { get; set; }
    public string Country { get; set; }
    public string Postcode { get; set; }
}

public class ValidationSettings
{
    public int MinYear { get; set; }
}