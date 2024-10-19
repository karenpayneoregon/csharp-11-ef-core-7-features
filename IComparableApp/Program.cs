
using ComparableLibrary;
using IComparableApp.Classes;
using IComparableApp.Classes.Extensions;
using static IComparableApp.Classes.SpectreConsoleHelpers;

namespace IComparableApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Examples.BetweenChars();
        Examples.BetweenInt();
        Examples.BetweenDateOnly();
        Examples.BetweenDateTime();
        Examples.BetweenTimeOnly();
        Examples.BetweenDecimal();
        Examples.BetweenTimeOnlyNative();
        Examples.Deconstruction1();

        ExitPrompt();
    }




}