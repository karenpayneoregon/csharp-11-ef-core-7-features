using System;
using System.Collections.Generic;
using Spectre.Console;

namespace SwitchExpressions.Classes
{
    public class LikesExample
    {
        private static string Likes(string[] name) =>
            name.Length switch
            {
                > 3 => $"{string.Join(", ", name[..2])} and {name.Length - 2} others like this",
                > 1 => $"{string.Join(", ", name[..^1])} and {name[^1]} others like this",
                  1 => $"{name[0]} likes this",
                _   => "no one likes this"
            };

        public static void Run()
        {
            var table = new Table()
                .RoundedBorder()
                .AddColumn("[b]Array[/]")
                .AddColumn("[b]Results[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[yellow]Likes[/]");

            
            List<string[]> nameList =
            [
                ["Karen", "Mary", "Tom", "Adam", "Sue"],
                ["Karen", "Mary", "Tom"],
                ["Karen"]
            ];

            foreach (var names in nameList)
            {
                table.AddRow($"{string.Join(",", names)}", $"{LikesExample.Likes(names)}");
            }

            AnsiConsole.Write(table);

            AnyKey();
        }
        public static string AnyKey()
        {
            var name = AnsiConsole.Ask<string>("[yellow]Press X to exit[/]");
            return name;
        }

    }
}
