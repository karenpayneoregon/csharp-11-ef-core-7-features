using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Spectre.Console;

namespace SwitchExpressions.Classes
{

    /// <summary>
    /// Consider wisely which pattern to choice dependent on others in a team
    /// and even for sole developers, many like the expression version but
    /// if not used enough come back in say a week, does the expression syntax
    /// still make sense, can you read it?
    /// </summary>
    public static class Examples
    {
        public static void MonthsIndexed()
        {
            var table = new Table()
                .RoundedBorder().BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Name[/]").AddColumn("[b]Index[/]").Alignment(Justify.Center)
                .Title("[yellow]Months index reverse[/]");

            var months = DateTimeFormatInfo.CurrentInfo.MonthNames[..^1].ToList();


            for (int index = months.Count; index != 0; index--)
            {
                var currentIndex = new Index(index, true);
                table.AddRow(months[currentIndex].ToString(), currentIndex.ToString());
            }

            AnsiConsole.Write(table);

        }
        public static double GetRating(this Person sender) =>
            sender switch
            {
                Employee => 2,
                Manager  => 3,
                { }      => 1, 
                null     => throw new ArgumentNullException(nameof(sender))
            };

        public static double GetRatingConventional(this Person sender)
        {
            switch (sender)
            {
                case Employee:
                    return 2;
                case Manager:
                    return 3;
                case not null:
                    return 1;
                case null:
                    throw new ArgumentNullException(nameof(sender));
            }
        }

        /// <summary>
        /// Provides multiple conditions vs <see cref="GetRating"/>, see also <see cref="GetRatingGuardedConventional"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static double GetRatingGuarded(this Person sender)
        {
            return sender switch
            {
                Employee => 2,
                Manager { Years: >= 4 } manager when manager.Employees.Count > 1 => 7,
                Manager => 4,
                Developer { Experience: Experience.Guru } => 10,
                Developer { Experience: Experience.Novice } => 1,
                Developer { Experience: Experience.Professional } => 8,
                not null => 0,
                null => throw new ArgumentNullException(nameof(sender))
            };
        }

        /// <summary>
        /// Traditional switch vs <see cref="GetRatingGuarded"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static double GetRatingGuardedConventional(this Person sender)
        {

            Console.WriteLine(nameof(GetRatingGuardedConventional));

            switch (sender)
            {
                case Employee:
                    return 2;
                case Manager { Years: >= 4 } manager when manager.Employees.Count > 1:
                    return 7;
                case Manager:
                    return 4;
                case Developer { Experience: Experience.Guru }:
                    return 10;
                case Developer { Experience: Experience.Professional }:
                    return 8;
                case Developer { Experience: Experience.Novice }:
                    return 1;
                case { }:
                    return 0;
                case null:
                    throw new ArgumentNullException(nameof(sender));
            }
        }

        public static void GuardedUnGuarded()
        {

            Console.WriteLine(nameof(GuardedUnGuarded));

            List<Person> peopleList =
            [
                new Employee() { FirstName = "Mike" },
                new Developer() { FirstName = "Anne", Experience = Experience.Professional },
                new Manager() { FirstName = "Mary", Years = 1, Employees = [] },
                new Manager() { FirstName = "Jake", Years = 5, Employees = [new(), new()] },
                new Manager() { FirstName = "Tina", Years = 5, Employees = [new(), new()] },
                new Developer() { FirstName = "Karen", Experience = Experience.Guru },
                new Person() { FirstName = "Sam" }
            ];

            foreach (var person in peopleList)
            {
                Console.WriteLine($"{person.FirstName,-8}{person.GetRating()}");
            }

            Console.WriteLine();

            foreach (var person in peopleList)
            {
                Console.WriteLine($"{person.FirstName,-8}{person.GetRatingGuarded(),-5}{person.GetType().Name}");
            }

            Console.ReadLine();
        }


        /// <summary>
        /// Demonstrates the use of recursive pattern matching with a <see cref="Customer"/> object.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <see cref="Customer"/> object is null.
        /// </exception>
        public static void RecursivePatternMatching()
        {
            const string state = "WA";

            Console.WriteLine(nameof(RecursivePatternMatching));

            Customer customer = new ()
            {
                FirstName = "Karen",
                LastName = "Payne",
                ShipmentStatus = Shipment.State.Delivered,
                Address = new() { Street = "123 Apple street", State = "OR", Zip = "1111" }
            };
            
            var message = customer switch
            {
                { ShipmentStatus: Shipment.State.Ordered } => "Congrats on your order",
                { Address: { State: state } } => "I live there too!",
                { Address: { Zip: null } } => "You forgot to enter a zip code!",
                {
                    ShipmentStatus: Shipment.State.Delivered,
                    FirstName: (var firstName),
                    LastName: (var lastName)
                } => $"Enjoy your package {firstName} {lastName}!",
                null => throw new ArgumentNullException(),
                _ => "I'm not sure what I'm looking at here."
            };

            Console.WriteLine(message);
        }


    }
}