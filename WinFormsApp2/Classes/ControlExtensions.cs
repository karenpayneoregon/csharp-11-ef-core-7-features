namespace WinFormsApp2.Classes;
public static class ControlExtensions
{
    public static void ToggleShow(this TextBox sender, bool show = true)
    {
        sender.PasswordChar = show ? '\0' : '\u25CF';
    }
}
