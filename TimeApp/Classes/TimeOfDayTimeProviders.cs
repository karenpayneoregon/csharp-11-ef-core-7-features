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
            return new DateTimeOffset(2023, 12, 1, 8, 0, 0, TimeSpan.Zero);
        }
    }

    public class AfternoonTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2023, 12, 1, 16, 0, 0, TimeSpan.Zero);
        }
    }

    public class EveningTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2023, 12, 1, 20, 0, 0, TimeSpan.Zero);
        }
    }
}
