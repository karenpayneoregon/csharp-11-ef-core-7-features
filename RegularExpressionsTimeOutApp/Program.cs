using System;
using System.Text.RegularExpressions;
using RegularExpressionsTimeOutApp.Classes;

namespace RegularExpressionsTimeOutApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var timespan = Regex.InfiniteMatchTimeout;
        //Console.WriteLine(timespan.Format(false));
        //var xxx = Samples.IsDefaultTimeout();
        //Samples.HandleRegexTimeout();
        //Samples.MicrosoftExample(true,1);
        //Samples.BadSampleRaw();
        Samples.NormalUse();

        SpectreConsoleHelpers.ExitPrompt();
    }

}