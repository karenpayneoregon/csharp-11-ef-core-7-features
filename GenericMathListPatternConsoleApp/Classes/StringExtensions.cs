using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMathListPatternConsoleApp.Classes;
public static class StringExtensions
{
    public static string ToYesNo(this bool value)
        => value ? "Yes" : "No";
}
