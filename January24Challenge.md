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

## @MobiusSlit (6)

```csharp
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    public static float[] ToFloatArray(this string input)
    {
        // Define the regular expression pattern for extracting floating-point numbers
        string pattern = @"-?\d+(\.\d+)?";

        // Use Regex.Matches to find all matches in the input string
        var matches = Regex.Matches(input, pattern);

        // Allocate the float array directly with the correct size
        var output = new float[matches.Count];

        // Iterate through the matches and convert each match to a float
        for(int i = 0;i<matches.Count;i++)
        {
            output[i] = float.Parse(matches[i].Value); // we've been told all values are floats
        }

        return output;
    }
}

class Program
{
    static void Main()
    {
        string bracketedData = "[10,20.5,30.88]";

        // Use the extension method to extract float numbers from the input string
        var floatArray = bracketedData.ToFloatArray();

        // Display the extracted numbers
        foreach (float number in floatArray)
        {
            Console.WriteLine(number);
        }
    }
}
```

## @MrPeterMorris (7)

```csharp
static readonly char[] ExtractFloatsTrimChars = new char[] { '[', ']', ' ' };
static float[] ExtractFloats(string input) =>
    input
        .Trim()
        .Trim(ExtractFloatsTrimChars)
        .Split(',')
        .Select(float.Parse)
        .ToArray();
```

## @marcgravell (10)

```csharp
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Buffers;
using System.Text.Json;

// prove impl
var obj = new MyBench { Count = 5 };
obj.Init();
Console.WriteLine(obj.Payload);
Console.WriteLine(string.Join(',', obj.Linq()));
Console.WriteLine(string.Join(',', obj.Json()));
Console.WriteLine(string.Join(',', obj.Manual()));

// bench
BenchmarkRunner.Run(typeof(MyBench).Assembly);

[MemoryDiagnoser]
public class MyBench
{
    [Params(1, 3, 20, 200)]
    public int Count { get; set; }

    [GlobalSetup]
    public void Init()
    {
        Random rand = new Random(1234151);
        Payload = "[" + string.Join(',', Enumerable.Range(0, Count).Select(x => rand.Next(0,1000) / rand.Next(0,3) switch
        {
            0 => 1f,
            1 => 10f,
            _ => 100f
        })) + "]";
    }

    public string Payload { get; private set; } = "[10,20.5,30.88]";

    [Benchmark]
    public float[] Linq() => Payload.Substring(1, Payload.Length-2).Split(',').Select(s => float.Parse(s)).ToArray();

    [Benchmark]
    public float[] Json() => JsonSerializer.Deserialize<float[]>(Payload)!;

    [Benchmark]
    public float[] Manual()
    {
        SequenceReader<char> r = new(new(Payload.AsMemory().Slice(1, Payload.Length - 2)));
        var copy = r;
        int count = 1; // count first
        while (r.TryAdvanceTo(',')) count++;

        // now repeat
        float[] arr = new float[count];
        r = copy;
        int i = 0;
        while (r.TryReadTo(out ReadOnlySpan<char> tok, ','))
        {
            arr[i++] = float.Parse(tok);
        }
        arr[i++] = float.Parse(r.UnreadSpan);
        return arr;
    }

}
```