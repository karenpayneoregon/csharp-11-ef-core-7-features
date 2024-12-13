namespace KP_WindowsFormsNET9.Classes;
internal static class IntExtensions
{
    public static (string grade, string remarks) GetGradeWithRemarks(this int score) => score switch
    {
        >= 90 => ("A", "Great job"),
        >= 80 => ("B", "Good"),
        >= 70 => ("C", "Okay"),
        >= 60 => ("D", "Better study"),
        >= 50 => ("F", "You failed"),
        _ => throw new ArgumentOutOfRangeException(nameof(score), score, @"Unexpected value")
    };
    public static (string grade, string remarks) GetGradeWithRemarks1(this int score) => score switch
    {
        >= 90 => ("A", "Great job"),
        >= 80 and < 90 => ("B", "Good"),
        >= 70 and < 80 => ("C", "Okay"),
        >= 60 and < 70 => ("D", "Better study"),
        >= 50 and < 60 => ("F", "You failed"),
        _ => throw new ArgumentOutOfRangeException(nameof(score), score, @"Unexpected value")
    };


}
