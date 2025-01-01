// ReSharper disable ConvertToAutoProperty
using Humanizer;

namespace ReadPeopleWithCopilotChatDemo.Models;

public class Person
{
    public string FirstName
    {
        get;
        set => field = value.Transform(To.LowerCase, To.TitleCase).Trim();
    }

    public string LastName
    {
        get;
        set => field = value.Transform(To.LowerCase, To.TitleCase).Trim();
    }

    public DateOnly BirthDate
    {
        get;
        set => field = value;
    }
}