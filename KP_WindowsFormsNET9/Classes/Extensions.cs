// ReSharper disable LocalizableElement
namespace KP_WindowsFormsNET9.Classes;

internal static class Extensions
{
    public static (string grade, string remarks) GetGradeWithRemarks(this int score)
    {
        if (score is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(score), score, "Score must be between 0 and 100");

        return score switch
        {
            >= 90 => ("A", "Great job"),
            >= 80 => ("B", "Good"),
            >= 70 => ("C", "Okay"),
            >= 60 => ("D", "Better study"),
            _ => ("F", "You failed")
        };
    }
}



