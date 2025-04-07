using System.Text;
using PrintMembersSamples.Classes;

namespace PrintMembersSamples.Models;

public record Taxpayer(string FirstName, string LastName, string SSN)
{
    public override string ToString()
    {
        var builder = new StringBuilder();

        var person = this with { SSN = SSN.MaskSsn() };

        person.PrintMembers(builder);

        return builder.ToString();
    }
}

