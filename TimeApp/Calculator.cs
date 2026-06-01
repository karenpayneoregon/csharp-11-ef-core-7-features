namespace TimeApp;

    public class Calculator(TimeProvider timeProvider)
    {
        public decimal CalculateDiscount() 
            => timeProvider.GetUtcNow() is { Month: 12, Day: 7 } ? 0.5m : 0m;
    }