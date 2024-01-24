# January 24th challenge

Given a string with numbers bracketed how would you extract to a float array?

No chance of nulls and all values will represent floats.

## @mdxkln (1)

```csharp
using System.Text.Json;

const string bracketedData = "[10,20.5,30.88]";

float[] numbers = JsonSerializer.Deserialize<float[]>(bracketedData);
foreach (float n in numbers) Console.WriteLine(n);
```

## @CodeDux (2)

```csharp
/// <summary>
/// Expects explicit structure like [10,20.5,30.88]
/// The only allocation is the resulting array of floats if <= 512 numbers inside input
/// </summary>
public static float[] Parse(ReadOnlySpan<char> input)
{
    var cleanedInput = input.Trim(['[', ']', ' ']);
    var numberOfValues = input.Count(',') + 1;
    var ranges = numberOfValues > 512 ? new Range[numberOfValues] : stackalloc Range[numberOfValues];
    var floatCount = cleanedInput.SplitAny(ranges, [',', ' '], StringSplitOptions.RemoveEmptyEntries);

    var result = new float[floatCount];
    for (var i = 0; i < floatCount; i++)
    {
        result[i] = float.Parse(cleanedInput[ranges[i]], CultureInfo.InvariantCulture);
    }

    return result;
}
```

## @SuperBadGPT (3)

```csharp
void Main()
{
	const string bracketedData = "   [10, 20.8, 30.88] ";
	bracketedData.ToFloatArray()
		.Dump();
}

// You can define other methods, fields, classes and namespaces here

public static class StringExtension
{
	public static float[] ToFloatArray(this string data) =>
		Regex.Replace(data, "\\[|\\]| ", "")	// clean - remove spaces and brackets
				.Split(',')						// split
				.Select(s => float.Parse(s))	// parse
				.ToArray();						// package
}
```

## @thefactorygrows (4)

**Program.cs**

```csharp
using float_parser;

var array = "[10,20.5,30.88]".ToFloatArray();

Console.WriteLine(string.Join(",", array));
```

**StringExtensions.cs**

```csharp
using System.Text.RegularExpressions;

namespace float_parser;

public static partial class StringExtensions
{
    [GeneratedRegex(@"(\d*\.?\d+)")]
    private static partial Regex FloatParser();

    public static float[] ToFloatArray(this string input)
    {
        if (string.IsNullOrEmpty(input)) return Array.Empty<float>();

        var matches = FloatParser().Matches(input);

        return matches.Select(m => float.Parse(m.Value)).ToArray();
    }
}
```

## @sam_ferree (5)

```csharp
using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		string floatString = "[10,20.5,30.88]";
		float[] floatArray = floatString.ToFloatArray();
		Console.WriteLine(string.Join(',', floatArray));
	}
}

public static class StringToFloatArray
{
  public static float[] ToFloatArray(this string str)
  => str
	  .Split(',')
	  .Select(RemoveBrackets)
	  .Select(float.Parse)
	  .ToArray();
  
  private static string RemoveBrackets(string str)
  => str.Replace("[", "").Replace("]", "");
}
```