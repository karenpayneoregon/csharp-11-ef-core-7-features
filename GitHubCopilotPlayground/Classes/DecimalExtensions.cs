namespace GitHubCopilotPlayground.Classes;
public static class DecimalExtensions
{
    private const int SIGN_MASK = ~int.MinValue;
    public static int DecimalRemainder(this decimal sender)
        => (int)((sender - Math.Truncate(sender)) * (int)Math.Pow(10d, (decimal.GetBits(sender)[3] & SIGN_MASK) >> 16));

    public static int GetScale(this decimal sender)
        => BitConverter.GetBytes(decimal.GetBits(sender)[3])[2];
}
