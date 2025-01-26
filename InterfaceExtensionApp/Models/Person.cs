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
    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class with the specified details.
    /// </summary>
    /// <param name="id">The unique identifier for the person.</param>
    /// <param name="firstName">The first name of the person.</param>
    /// <param name="lastName">The last name of the person.</param>
    /// <param name="dateOfBirth">The date of birth of the person.</param>
    /// <param name="gender">The gender of the person.</param>
    /// <param name="language">The preferred language of the person.</param>
    private Person(int id, string firstName, string lastName, DateOnly dateOfBirth, Gender gender, Language language)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Language = language;
    }
    /// <summary>
    /// Parses a string representation of a <see cref="Person"/> and returns an instance of the <see cref="Person"/> class.
    /// </summary>
    /// <param name="item">The string representation of a person in the format "Id,FirstName,LastName,DateOfBirth,Gender,Language".</param>
    /// <param name="provider">An optional <see cref="IFormatProvider"/> to provide culture-specific formatting information.</param>
    /// <returns>A new instance of the <see cref="Person"/> class populated with the parsed data.</returns>
    /// <exception cref="FormatException">
    /// Thrown when the input string does not match the expected format or contains invalid data.
    /// </exception>
    public static Person Parse(string item, IFormatProvider? provider)
    {
        string[] personPortions = item.Split('|');
        if (personPortions.Length != 6)
        {
            throw new FormatException("Expected format: Id|FirstName|LastName|DateOfBirth|Gender|Language");
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
    /// <summary>
    /// Attempts to parse the specified string representation of a <see cref="Person"/> into an instance of the <see cref="Person"/> class.
    /// </summary>
    /// <param name="value">The string representation of a person in the format "Id,FirstName,LastName,DateOfBirth,Gender,Language".</param>
    /// <param name="provider">An optional <see cref="IFormatProvider"/> to provide culture-specific formatting information.</param>
    /// <param name="result">
    /// When this method returns, contains the parsed <see cref="Person"/> instance if the parsing succeeded, 
    /// or <c>null</c> if the parsing failed. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    /// <c>true</c> if the parsing succeeded and a valid <see cref="Person"/> instance was created; otherwise, <c>false</c>.
    /// </returns>
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