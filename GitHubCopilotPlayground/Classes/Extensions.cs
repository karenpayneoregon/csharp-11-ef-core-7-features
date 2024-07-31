namespace GitHubCopilotPlayground.Classes;
public static class Extensions
{
    public static int Left(this decimal sender)
        => (int)sender;

    public static int RemainderAsInt(this decimal sender)
        => (int)((sender - Math.Truncate(sender)) * 
                 (int)Math.Pow(10d, (decimal.GetBits(sender)[3] & ~int.MinValue) >> 16));

    public static decimal RemainderAsDecimal(this decimal sender)
        => sender - Math.Floor(sender);

    public static int GetScale(this decimal sender)
        => BitConverter.GetBytes(decimal.GetBits(sender)[3])[2];

    public static int GetScaleAsInt(this decimal value)
    {
        Span<int> data = stackalloc int[4];
        decimal.GetBits(value, data);
        return (data[3] >> 16) & (1 << 8) - 1;
    }
}


