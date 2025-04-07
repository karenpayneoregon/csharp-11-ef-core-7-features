using System.Text;

namespace PrintMembersSamples.Models;

public abstract record Human(string FirstName, string LastName, string[] PhoneNumbers)
{
    protected virtual bool PrintMembers(StringBuilder sb)
    {
        sb.Append($"FirstName = {FirstName}, LastName = {LastName}, ");
        if (!(PhoneNumbers?.Length > 0)) return true;

        sb.Append("PhoneNumbers: ");
        sb.Append(string.Join(", ", PhoneNumbers));
        sb.Append("");
        return true;
    }
}

public record Teacher(string FirstName, string LastName, string[] PhoneNumbers, Grade Grade) 
    : Human(FirstName, LastName, PhoneNumbers)
{
    protected override bool PrintMembers(StringBuilder sb)
    {
        if (base.PrintMembers(sb))
        {
            sb.Append(' ');
        }

        sb.Append($"Teaches {Grade} grade");
        return true;
    }
};