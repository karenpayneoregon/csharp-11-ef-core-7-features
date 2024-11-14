#nullable disable
namespace TaskDialogLibrary.Models;

public class ShowAgainOptions
{
    public string Heading { get; set; }
    public string Text { get; set; }
    public string Caption { get; set; }
    public string VerificationText { get; set; }
    public Control Owner { get; set; }
    public IntPtr IntPtr { get; set; }
    public Icon Icon { get; set; }
}