using System.Security.Cryptography.X509Certificates;
using QuestionOfTheDay.Classes;
using QuestionOfTheDay.Extensions;
using QuestionOfTheDay.Models;
using static QuestionOfTheDay.Classes.SpectreConsoleHelpers;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay;

internal partial class Program
{
    static void Main(string[] args)
    {

        var distinctByFirstLastNames = MemberOperations.MembersList()
            .DistinctBy(member => new
            {
                member.FirstName, 
                member.SurName
            }).ToList();

        foreach (var member in distinctByFirstLastNames)
        {
            Console.WriteLine($"{member.Id,-4}{member.FirstName,-10}{member.SurName}");
        }


        ExitPrompt();
    }


}