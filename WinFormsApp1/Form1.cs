using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
// ReSharper disable ReturnValueOfPureMethodIsNotUsed


#pragma warning disable SYSLIB0014

namespace WinFormsApp1;
/*
 * In multi-thread scenarios, be advised that read-only collections are still not thread-safe.
 *
 */
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        //listBox1.DataSource = FrozenVendors().OrderBy(x => x.CompanyName).ToList();
        listBox1.DataSource = ReadOnlyVendors();


        //var items = test.Append(new Vendor(1, "s", "s", 11)).ToList();
        //listBox1.DataSource = items;

        Vendor[] vendors =
            [
                .. NotImmutableVendors2().ToImmutableArray(),
                .. NotImmutableVendors3().ToImmutableArray()
            ];


    }

    public static IReadOnlyList<Vendor> ImmutableVendors() => new List<Vendor>()
    {
        new (1,"ANDERSON1","Anderson Custom Bikes",2),
        new (2,"BERGERON1","Bergeron Off-Roads",1),
        new (3,"BICYCLE1","Bicycle Specialists",1),
        new (4,"CAPITAL1","Capital Road Cycles",3),
        new (5,"CAPITAL2","Capital Finances",3),
        new (6,"ELECTRON0001","Electronic Bike Co.",1)
    }.ToImmutableList();

    public static IReadOnlyList<Vendor> ImmutableVendors1() => new List<Vendor>()
    {
        new (1,"ANDERSON1","Anderson Custom Bikes",2),
        new (2,"BERGERON1","Bergeron Off-Roads",1),
        new (3,"BICYCLE1","Bicycle Specialists",1),
        new (4,"CAPITAL1","Capital Road Cycles",3),
        new (5,"CAPITAL2","Capital Finances",3),
        new (6,"ELECTRON0001","Electronic Bike Co.",1)
    }.ToImmutableList();

    public static List<Vendor> NotImmutableVendors2() =>
    [
        new(1, "ANDERSON1", "Anderson Custom Bikes", 2),
        new(2, "BERGERON1", "Bergeron Off-Roads", 1),
        new(3, "BICYCLE1", "Bicycle Specialists", 1),
        new(4, "CAPITAL1", "Capital Road Cycles", 3),
        new(5, "CAPITAL2", "Capital Finances", 3),
        new(6, "ELECTRON0001", "Electronic Bike Co.", 1)
    ];

    public static List<Vendor> NotImmutableVendors3() =>
    [
        new(1, "ANDERSON1", "Anderson Custom Bikes", 2),
        new(2, "BERGERON1", "Bergeron Off-Roads", 1),
        new(3, "BICYCLE1", "Bicycle Specialists", 1),
        new(4, "CAPITAL1", "Capital Road Cycles", 3),
        new(5, "CAPITAL2", "Capital Finances", 3),
        new(6, "ELECTRON0001", "Electronic Bike Co.", 1)
    ];

    public static FrozenSet<Vendor> FrozenVendors() => new List<Vendor>()
    {
        new (1,"ANDERSON1","Anderson Custom Bikes",2),
        new (2,"BERGERON1","Bergeron Off-Roads",1),
        new (3,"BICYCLE1","Bicycle Specialists",1),
        new (4,"CAPITAL1","Capital Road Cycles",3),
        new (5,"CAPITAL2","Capital Finances",3),
        new (6,"ELECTRON0001","Electronic Bike Co.",1)
    }.ToFrozenSet();


    public static ReadOnlyCollection<Vendor> ReadOnlyVendors()
    {
        var list = new List<Vendor>()
        {
            new(1, "ANDERSON1", "Anderson Custom Bikes", 2),
            new(2, "BERGERON1", "Bergeron Off-Roads", 1),
            new(3, "BICYCLE1", "Bicycle Specialists", 1),
            new(4, "CAPITAL1", "Capital Road Cycles", 3),
            new(5, "CAPITAL2", "Capital Finances", 3),
            new(6, "ELECTRON0001", "Electronic Bike Co.", 1)
        };

        return new(list.ToImmutableList());
    }

    private async void GetZonesButton_Click(object sender, EventArgs e)
    {
        GetZonesButton.Enabled = false;
        try
        {
            var (list, success) = await DateTimeHelpers.TimeZones();
            if (success)
            {
                listBox2.DataSource = list;
                foreach (var item in list)
                {
                    Debug.WriteLine(item);
                }
            }
            else
            {
                MessageBox.Show("Failed to get zones");
            }
        }
        finally
        {
            GetZonesButton.Enabled = true;
        }

    }

    private void button1_Click(object sender, EventArgs e)
    {
        List<int> normalList = [1, 2, 3];
        ReadOnlyCollection<int> readonlyList = normalList.AsReadOnly();
        FrozenSet<int> frozenSet = normalList.ToFrozenSet();
        ImmutableList<int> immutableList = normalList.ToImmutableList();

        normalList.Add(4);
        Debug.WriteLine("");
        Debug.WriteLine($"List count: {normalList.Count}");
        Debug.WriteLine($"ReadOnlyList count: {readonlyList.Count}");
        Debug.WriteLine($"FrozenSet count: {frozenSet.Count}");
        Debug.WriteLine($"ImmutableList count: {immutableList.Count}");
        frozenSet.Items.Add(1);

    }

    private void button2_Click(object sender, EventArgs e)
    {
        // make a span
        ReadOnlySpan<char> valuesAsSpan = "ab,cd,ef".AsSpan();

        // set up a span to hold the ranges from the Split() call
        Span<Range> splitRanges = stackalloc Range[3];

        // split the span based on commas
        valuesAsSpan.Split(splitRanges, ',');

        // get the offset and length of the first range
        var (offset, length) = splitRanges[0].GetOffsetAndLength(valuesAsSpan.Length);
        Range test = splitRanges[0];
        ReadOnlySpan<char> firstSpan = valuesAsSpan[splitRanges[0]];
    }
    public static string GetDefaultBasePath()
    {
        return
            Path.GetDirectoryName(
                (System.Reflection.Assembly.GetEntryAssembly()?.Location ??
                 Process.GetCurrentProcess().MainModule?.FileName ??
                 "").AsSpan()
            ).ToString();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        //Pacific Daylight Time
        var data = DateTimeHelpers.AllTimeZones();

    }

    private async void button4_Click(object sender, EventArgs e)
    {
        var (list, success) = await DateTimeHelpers.TimeZones();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn() { ColumnName = "Id", DataType = typeof(int), AutoIncrement = true, AutoIncrementSeed = 1 });
        dt.Columns.Add(new DataColumn() { ColumnName = "FirstName", DataType = typeof(string) });
        dt.Columns.Add(new DataColumn() { ColumnName = "LastName", DataType = typeof(string) });
        dt.Columns.Add(new DataColumn() { ColumnName = "BirthDate", DataType = typeof(DateTime) });

        // Adding rows
        dt.Rows.Add(null, "John", "Doe", new DateTime(1990, 1, 1));
        dt.Rows.Add(null, "Jane", "Smith", new DateTime(1985, 5, 20));

        // Third row without setting BirthDate
        DataRow thirdRow = dt.NewRow();
        thirdRow["FirstName"] = "Alice";
        thirdRow["LastName"] = "Johnson";
        // BirthDate remains unset (DBNull by default)
        dt.Rows.Add(thirdRow);

        dt.Rows.Add(null, "Bob", "Brown", new DateTime(1978, 9, 15));
        dt.Rows.Add(null, "Eve", "Williams", new DateTime(2000, 12, 31));

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i].IsNull("BirthDate"))
            {
                Debug.WriteLine($"Row {i + 1}: BirthDate is DBNull.");
            }
            else
            {
                DateTime birthDate = (DateTime)dt.Rows[i]["BirthDate"];
                Debug.WriteLine($"Row {i + 1}: BirthDate is {birthDate:d}.");
            }
        }

    }
}


public record Vendor(int Id, string AccountNumber, string CompanyName, int CreditRating)
{
    public sealed override string ToString() => CompanyName;
}

//public record Vendors(int Id, string AccountNumber, string CompanyName, int CreditRating) : Vendor(Id, AccountNumber, CompanyName, CreditRating)
//{
//    public override string ToString() => AccountNumber;
//}


public static class DateTimeHelpers
{
    public static async Task<(ImmutableList<string> list, bool success)> TimeZones()
    {
        DateTimeOffset? local = await InternetHelpers.LocalTime();
        return local is null ?
            (Enumerable.Empty<string>().ToImmutableList(), false) :
            (local.Value.PossibleTimeZones(), true);
    }

    public static ImmutableList<string> PossibleTimeZones(this DateTimeOffset offsetTime)
    {
        List<string> list = [];
        TimeSpan offset = offsetTime.Offset;

        ReadOnlyCollection<TimeZoneInfo> timeZones = AllTimeZones();

        list.AddRange(timeZones
            .Where(timeZone => timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
            .Select(timeZone => timeZone.DaylightName));

        return list.ToImmutableList();
    }

    public static ReadOnlyCollection<TimeZoneInfo> AllTimeZones()
    {
        ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        return timeZones;
    }
}

public class InternetHelpers
{
    public static async Task<DateTimeOffset?> LocalTime()
    {
        var dateTimeOffset = await CurrentTimeFromWeb();
        return dateTimeOffset?.ToLocalTime();
    }

    public static async Task<DateTimeOffset?> CurrentTimeFromWeb()
    {
        static async Task<DateTimeOffset?> TimeFromSite(string site)
        {
            using var client = new HttpClient();
            /*
             * Timeout may not be needed, comment out or change milliseconds
             */
            client.Timeout = TimeSpan.FromMilliseconds(1000);
            var response = await client.GetAsync(site);
            return response.Headers.Date.Value;
        }

        // optionally read from a config file
        var sites = new[] { "https://nist.time.gov", "http://www.microsoft.com", "http://www.google.com" };

        foreach (var site in sites)
        {
            try
            {
                var dateTimeOffset = TimeFromSite(site);
                if (dateTimeOffset is not null)
                {
                    return await dateTimeOffset;
                }
            }
            catch
            {
                continue;
            }
        }

        return null;

    }
}