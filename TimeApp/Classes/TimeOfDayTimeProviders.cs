namespace TimeApp.Classes
{
    public class NightTimeProvider: TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2023, 12, 1, 1, 0, 0, TimeSpan.Zero);
        }
    }

    public class MorningTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2025, 12, 1, 15, 0, 0, TimeSpan.Zero);
        }
    }

    public class AfternoonTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2023, 12, 1, 2, 0, 0, TimeSpan.Zero);
        }
    }

    public class EveningTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2023, 12, 1, 5, 0, 0, TimeSpan.Zero);
        }
    }
}
