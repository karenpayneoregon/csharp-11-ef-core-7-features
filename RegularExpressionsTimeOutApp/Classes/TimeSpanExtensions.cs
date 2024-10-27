namespace RegularExpressionsTimeOutApp.Classes;
internal static class TimeSpanExtensions
{
    public static string Format(this TimeSpan timeSpan, bool debug = true)
    {
        return debug ? 
            $"Minutes: {(int)timeSpan.TotalMinutes} Seconds:{timeSpan.Seconds:00} Milliseconds:{timeSpan.Milliseconds:00}" : 
            $"{(int)timeSpan.TotalMinutes}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:00}";
    }


}
