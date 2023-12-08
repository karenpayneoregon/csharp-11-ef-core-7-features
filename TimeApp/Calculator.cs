namespace TimeApp;

    public class Calculator(TimeProvider timeProvider)
    {
        public decimal CalculateDiscount()
        {
            DateTimeOffset now = timeProvider.GetUtcNow();
            if (now is { Month: 12, Day: 7 })
            {
                return 0.5m;
            }
            return 0m;
        }
    }