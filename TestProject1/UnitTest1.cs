using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Configuration;
using System.Text.Json;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace TestProject1;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        CommaDelimitedStringCollectionConverter cv = new();
        CommaDelimitedStringCollection col = ["Karen", "Payne"];
        Assert.AreEqual("Karen,Payne", cv.ConvertTo(null, null, col, typeof(string)));
    }
    [TestMethod]
    public void TestMethod2()
    {
        CommaDelimitedStringCollectionConverter cv = new();
        CommaDelimitedStringCollection col = ["Karen", "Payne"];
        Assert.AreNotEqual("Karen,payne", cv.ConvertTo(null, null, col, typeof(string)));
    }
    [TestMethod]
    public void TestMethod3()
    {
        CommaDelimitedStringCollectionConverter cv = new();
        CommaDelimitedStringCollection col = ["1", "12"];
        Assert.AreEqual("1,12", cv.ConvertTo(null, null, col, typeof(string)));
    }

    [TestMethod]
    public void TestMethod4()
    {
        
        CommaDelimitedStringCollectionConverter cv = new();
        CommaDelimitedStringCollection delimitedStringCollection = [];
        delimitedStringCollection.AddRange(Operations.ReadConfiguration()!.MeetingDays);
        Assert.AreEqual("Monday,Wednesday,Friday", 
            cv.ConvertTo(null, null, delimitedStringCollection, typeof(DayOfWeek)));

    }
}



    public class Items
    {
        public string[] MeetingDays { get; set; }
    }

    public class Operations
    {
        private static string _fileName => "Configuration.json";
        public static void Serialize()
        {
            Items items = new Items() { MeetingDays = ["Monday", "Wednesday", "Friday"] };
            File.WriteAllText(_fileName, JsonSerializer.Serialize(items, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }
        public static Items? ReadConfiguration() => JsonSerializer.Deserialize<Items> (File.ReadAllText(_fileName));
    }


