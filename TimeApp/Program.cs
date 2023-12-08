
    
    using Microsoft.Extensions.Time.Testing;

    namespace TimeApp;

    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            FakeTimeProvider fakeTimeProvider = new ();
            
            fakeTimeProvider.SetUtcNow(
                new DateTimeOffset(new DateTime(2023, 12, 7)));

            Calculator calculator = new(fakeTimeProvider);
            decimal discount = calculator.CalculateDiscount();
            Console.WriteLine(discount > 0 ? "woo hoo" : "sad face");

            Console.WriteLine("================");
            await StreamingDeserializationExample();
            Console.ReadLine();
        }
    }

