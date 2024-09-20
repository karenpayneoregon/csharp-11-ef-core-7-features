using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Spectre.Console;
using SwitchExpressions.Classes;

namespace SwitchExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Examples.GuardedUnGuarded();
            //Console.WriteLine();
            //Examples.RecursivePatternMatching();

            //LikesExample.Run();
            //Examples.MonthsIndexed();
            //Console.ReadLine();
            //ProjectOperations.Demo();
        }

        
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = $"{Howdy.TimeOfDay()} Switch Expressions samples";
        }
    }


}
