#nullable disable

using TaskDialogLibrary.Classes;

namespace TaskDialogLibrary.Models;

public class ApplicationSettings
{
    public bool ShowAgain { get; set; }
    public string Heading { get; set; }
    public string Text { get; set; }
    public string Caption { get; set; }
    public string VerificationText { get; set; }
    public MainSettings MainSettings { get; set; }
}