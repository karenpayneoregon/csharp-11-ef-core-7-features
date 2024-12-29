#nullable enable
using InterfaceExtensionApp.Interfaces;
using System.Diagnostics.CodeAnalysis;
#pragma warning disable CS8618, CS9264

namespace InterfaceExtensionApp.Models;

public class Person : IHuman, IIdentity, IParsable<Person>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public Language Language { get; set; }

    public Person() { }
    private Person(int id, string firstName, string lastName, DateOnly dateOfBirth, Gender gender, Language language)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Language = language;
    }
    public static Person Parse(string item, IFormatProvider? provider)
    {
        string[] personPortions = item.Split(',');
        if (personPortions.Length != 6)
        {
            throw new FormatException("Expected format: Id,FirstName,LastName,DateOfBirth,Gender,Language");
        }
        return new Person(
            int.Parse(personPortions[0]),
            personPortions[1],
            personPortions[2],
            DateOnly.Parse(personPortions[3]),
            Enum.Parse<Gender>(personPortions[4]),
            Enum.Parse<Language>(personPortions[5])
        );
    }
    public static bool TryParse([NotNullWhen(true)] string? value, IFormatProvider? provider, [MaybeNullWhen(false)] out Person result)
    {
        result = null;
        if (value == null)
        {
            return false;
        }
        try
        {
            result = Parse(value, provider);
            return true;
        }
        catch
        {
            return false;
        }
    }
}