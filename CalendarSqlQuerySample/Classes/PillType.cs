using Spectre.Console.Rendering;

namespace CalendarSqlQuerySample.Classes;
/// <summary>
/// Represents the type of pill-shaped UI element, determining its visual style and color scheme.
/// </summary>
/// <remarks>
/// This enum is used in conjunction with the <see cref="Pill"/> class to define the appearance
/// of the pill when rendered in the console using Spectre.Console.
/// </remarks>
/// <summary>
/// Represents a success pill with a green background.
/// </summary>
/// <summary>
/// Represents a warning pill with a yellow background.
/// </summary>
/// <summary>
/// Represents an error pill with a red background.
/// </summary>
/// <summary>
/// Represents an informational pill with a blue background.
/// </summary>
public enum PillType
{
    Success,
    Warning,
    Error,
    Info,
}
/// <summary>
/// Represents a styled pill-shaped UI element that can be rendered in the console.
/// </summary>
/// <remarks>
/// The <see cref="Pill"/> class is used to display a text label with a specific style and color scheme
/// based on the provided <see cref="PillType"/>. It implements the <see cref="IRenderable"/> interface,
/// allowing it to be rendered using Spectre.Console.
///
/// https://spectreconsole.net/console/tutorials/creating-custom-renderables-tutorial
/// </remarks>
public sealed class Pill : IRenderable
{
    private readonly string _text;
    private readonly Style _style;

    /// <summary>
    /// Creates a new pill with the specified text and type.
    /// </summary>
    /// <param name="text">The text to display inside the pill.</param>
    /// <param name="type">The pill type which determines its color scheme.</param>
    public Pill(string text, PillType type)
    {
        _text = text;
        _style = GetStyleForType(type);
    }

    /// <summary>
    /// Determines the visual style for a given <see cref="PillType"/>.
    /// </summary>
    /// <param name="type">The type of the pill for which the style is to be determined.</param>
    /// <returns>
    /// A <see cref="Style"/> object that defines the foreground and background colors
    /// for the specified <see cref="PillType"/>.
    /// </returns>
    /// <remarks>
    /// This method maps each <see cref="PillType"/> to a specific color scheme:
    /// <list type="bullet">
    /// <item><description><see cref="PillType.Success"/>: White text on a green background.</description></item>
    /// <item><description><see cref="PillType.Warning"/>: Black text on a yellow background.</description></item>
    /// <item><description><see cref="PillType.Error"/>: White text on a red background.</description></item>
    /// <item><description><see cref="PillType.Info"/>: White text on a blue background.</description></item>
    /// <item><description>Default: White text on a grey background.</description></item>
    /// </list>
    /// </remarks>
    private static Style GetStyleForType(PillType type) => type switch
    {
        PillType.Success => new Style(Color.White, Color.Green),
        PillType.Warning => new Style(Color.Black, Color.Yellow),
        PillType.Error => new Style(Color.White, Color.Red),
        PillType.Info => new Style(Color.White, Color.Blue),
        _ => new Style(Color.White, Color.Grey),
    };

    /// <summary>
    /// Measures the pill's width in console cells.
    /// </summary>
    public Measurement Measure(RenderOptions options, int maxWidth)
    {
        // Width = text + 2 padding spaces + 2 cap characters
        var width = _text.Length + 4;
        return new Measurement(width, width);
    }

    /// <summary>
    /// Renders the pill as a sequence of styled segments.
    /// </summary>
    public IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        // Use rounded half-circles if Unicode is supported, otherwise spaces
        const string LeftCap = "\uE0B6";
        const string RightCap = "\uE0B4";

        var inverseStyle = new Style(_style.Background);

        if (options.Capabilities.Unicode)
        {
            yield return new Segment(LeftCap, inverseStyle);
            yield return new Segment($" {_text} ", _style);
            yield return new Segment(RightCap, inverseStyle);
        }
        else
        {
            yield return new Segment($"  {_text}  ", _style);
        }

    }
}
