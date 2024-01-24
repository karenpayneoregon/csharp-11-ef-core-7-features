
    
    using Microsoft.Extensions.Time.Testing;
    using TimeApp.Classes;

    namespace TimeApp;

    internal partial class Program
    {
        static void Main(string[] args)
        {
            GreetingsService service = new(new EveningTimeProvider());

            Console.WriteLine(service.TimeOfDay());
            Console.ReadLine();
        }

        private static async Task Examples()
        {
            FakeTimeProvider fakeTimeProvider = new ();
            
            fakeTimeProvider.SetUtcNow(new DateTimeOffset(new DateTime(2023, 12, 7)));

            Calculator calculator = new(fakeTimeProvider);
            decimal discount = calculator.CalculateDiscount();
            Console.WriteLine(discount > 0 ? "woo hoo" : "sad face");

            Console.WriteLine("================");
            await StreamingDeserializationExample();
        }
    }

