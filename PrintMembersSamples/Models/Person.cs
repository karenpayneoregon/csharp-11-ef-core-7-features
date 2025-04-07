using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMembersSamples.Models;


public record Person(string FirstName, string LastName, DateOnly BirthDate, string[] PhoneNumbers)
{

    public override string ToString()
    {
        var builder = new StringBuilder();

        var person = (FirstName == "Karen" && LastName == "Payne")
            ? this with { BirthDate = default }
            : this;

        person.PrintMembers(builder);

        return builder.ToString();
    }

    protected virtual bool PrintMembers(StringBuilder sb)
    {
        sb.Append($"FirstName = {FirstName}, LastName = {LastName}, Birth = {BirthDate:MM/dd/yyyy}");

        if (!(PhoneNumbers?.Length > 0)) return true;

        sb.Append(", PhoneNumbers: ");
        sb.Append(string.Join(", ", PhoneNumbers));
        sb.Append("");

        return true;
    }

}