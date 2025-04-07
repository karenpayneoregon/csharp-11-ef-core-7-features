using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace AddingStringObjectDictionaryToConfiguration;

partial class Program
{
    static void Main(string[] args)
    {
        var sectionName = "OurConfigSection";
        var stringObjectPairs = TestDictionary;

        var initialData = GetInitialData(sectionName, stringObjectPairs);

        // Build a configuration using initialData
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(initialData)
            .Build();

        Console.WriteLine($"Configuration: {JsonConvert.SerializeObject(GetConfigurationAsDictionary(configuration), Formatting.Indented)}");

        var section = configuration.GetSection(sectionName);
        Console.WriteLine($"Configuration section {sectionName}: " +
                          $"{JsonConvert.SerializeObject(GetConfigurationAsDictionary(section), Formatting.Indented)}");

        // Use the DI extensions to map the configuration to the strongly typed options class
        var options = GenerateOptions<MyTestOptions>(section);

        // Look at the result
        Console.WriteLine($"Options: {JsonConvert.SerializeObject(options, Formatting.Indented)}");
        Console.ReadLine();
    }

    private static Dictionary<string, string> GetConfigurationAsDictionary(IConfiguration configuration)
    {
        return configuration.AsEnumerable(true).ToDictionary(kv => kv.Key, kv => kv.Value);
    }

    private static IEnumerable<KeyValuePair<string, string>> GetInitialData(string sectionName, Dictionary<string, object> stringObjectPairs)
    {
        // Convert <string, object> pairs to <string, string> pairs
        var stringStringPairs = ToStringStringPairs(stringObjectPairs);

        // Prefix the keys with the desired section name
        var sectionedPairs = stringStringPairs
            .Select(kv => new KeyValuePair<string, string>($"{sectionName}:{kv.Key}", kv.Value));

        return sectionedPairs;
    }

    private static Dictionary<string, object> TestDictionary => new Dictionary<string, object>()
    {
        ["int"] = (int)1234,
        ["intX"] = (int?)1234,
        ["intN"] = (int?)null,
        ["long"] = (long)123456789012345L,
        ["longX"] = (long?)123456789012345L,
        ["longN"] = (long?)null,
        ["guid"] = TestGuid,
        ["guidX"] = (Guid?)TestGuid,
        ["guidN"] = (Guid?)null,
        ["dt"] = TestDateTime,
        ["dtX"] = (DateTime?)TestDateTime,
        ["dtN"] = (DateTime?)null,
        ["string"] = "abcde",
        ["stringN"] = (string)null,
        ["object"] = new object(),
        ["objectN"] = (object)null,
    };

    private static Guid TestGuid => Guid.Parse("23bd8260-5c23-4d20-a09c-cad00b74c837");

    private static DateTime TestDateTime => new DateTime(1992, 8, 7, 6, 5, 4, DateTimeKind.Utc);

    private static T GenerateOptions<T>(IConfiguration config) where T : class, new()
    {
        var services = new ServiceCollection();
        services.Configure<T>(config);
        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<T>>().Value;
        return options;
    }

    public class MyTestOptions
    {
        public int Int { get; set; }
        public int? IntX { get; set; }
        public int? IntN { get; set; }
        public long Long { get; set; }
        public long? LongX { get; set; }
        public long? LongN { get; set; }
        public Guid Guid { get; set; }
        public Guid? GuidX { get; set; }
        public Guid? GuidN { get; set; }
        public DateTime Dt { get; set; }
        public DateTime? DtX { get; set; }
        public DateTime? DtN { get; set; }
        public string String { get; set; }
        public string StringN { get; set; }
        public object Object { get; set; }
        public object ObjectN { get; set; }
    }

    public static IEnumerable<KeyValuePair<string, string>> ToStringStringPairs(IEnumerable<KeyValuePair<string, object>> source)
    {
        return source
            .Select(kv => new KeyValuePair<string, string>(
                kv.Key,
                ConvertToStringOrDefault(kv.Value)
            ));
    }

    public static string ConvertToStringOrDefault(object value)
    {
        if (TryConvertToString(value, out string stringValue, out Exception _))
        {
            return stringValue;
        }
        return null;
    }

    // Stringification can't always be reversed in a meaningful way, thus this can't convert absolutely everything
    // into a string value that can be re-parsed. Our application has strings, numbers, datetimes, and GUIDs in the
    // string-object dictionary, and those all appear to work.
    //
    // This method uses ConvertToInvariantString(), which tries, where possible, to produce values for the invariant
    // culture instead of the current one. In the configuration binder code that converts strings back into typed
    // values, its counterpart method ConvertFromInvariantString() is used, so this seems like the correct approach. 
    //
    // This method produces exceptions on an out parameter in case you want your code to complain instead of
    // defaulting when a conversion fails.
    public static bool TryConvertToString(object value, out string stringValue, out Exception error)
    {
        stringValue = null;
        error = null;

        if (value == null)
        {
            return true;
        }

        // There might be a way to convince the TypeConverter to use .ToString("o") by itself, and if so there might
        // be a way to convince the binder to use DateTime.Parse(stringValue, null, DateTimeStyles.RoundtripKind) to
        // make the results useful.
        if (value is DateTime dateTimeValue)
        {
            stringValue = dateTimeValue.ToString("o");
            return true;
        }
        else if (value is DateTimeOffset dateTimeOffsetValue)
        {
            stringValue = dateTimeOffsetValue.ToString("o");
            return true;
        }

        var converter = TypeDescriptor.GetConverter(value);

        if (converter.CanConvertTo(typeof(string)))
        {
            try
            {
                stringValue = converter.ConvertToInvariantString(value);
                return true;
            }
            catch (Exception e)
            {
                error = new InvalidOperationException("Conversion to invariant string failed.", e);
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}