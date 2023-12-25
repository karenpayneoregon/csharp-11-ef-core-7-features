namespace AuditInterceptorSampleApp.Classes;

/// <summary>
/// Custom setting for presenting runtime exceptions using AnsiConsole.WriteException.
///
/// The idea here is to present different types of exceptions with different colors while
/// one would be for all exceptions and the other(s) for specific exception types.
/// </summary>
public class ExceptionHelpers
{

    /// <summary>
    /// Provides a colorful exception message
    /// </summary>
    /// <param name="exception"><see cref="Exception"/></param>
    public static void ColorStandard(Exception exception)
    {
        AnsiConsole.WriteException(exception, new ExceptionSettings
        {
            Format = ExceptionFormats.ShortenEverything | ExceptionFormats.ShowLinks,
            Style = new ExceptionStyle
            {
                Exception = new Style().Foreground(Color.Grey),
                Message = new Style().Foreground(Color.White),
                NonEmphasized = new Style().Foreground(Color.Cornsilk1),
                Parenthesis = new Style().Foreground(Color.GreenYellow),
                Method = new Style().Foreground(Color.DarkOrange),
                ParameterName = new Style().Foreground(Color.Cornsilk1),
                ParameterType = new Style().Foreground(Color.Aqua),
                Path = new Style().Foreground(Color.White),
                LineNumber = new Style().Foreground(Color.Cornsilk1),
            }
        });

    }
}