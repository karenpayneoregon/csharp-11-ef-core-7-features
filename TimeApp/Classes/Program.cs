using Microsoft.Extensions.Time.Testing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Point = (int x, int y);
namespace TimeApp;
internal partial class Program
{
    private static void CheckDay()
    {
        var dates = Enumerable.Range(4, 7)
            .Select(x => new DateTime(2023, 12, x))
            .ToList();

        var fakeTimeProvider = new FakeTimeProvider();

        foreach (var date in dates)
        {
            fakeTimeProvider.SetUtcNow(date);
            fakeTimeProvider.SetLocalTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Greenwich Standard Time"));

            var result = new Calendar(fakeTimeProvider);
            var test = result.IsMonday();
            Console.WriteLine($"{date:MM/dd/yy} is Monday {result.IsMonday()}");
        }

        Console.WriteLine();


    }

    private static async Task StreamingDeserializationExample()
    {
        const string RequestUri = "https://jsonplaceholder.typicode.com/posts";
        using var client = new HttpClient();
        IAsyncEnumerable<Post?> posts = client.GetFromJsonAsAsyncEnumerable<Post>(RequestUri);

        await foreach (Post? post in posts)
        {
            Console.WriteLine($"{post!.id,-5}{post.title}");
        }

    }
    public record Post(int id, string title, string body);

}

