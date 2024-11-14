

#pragma warning disable CS8618
namespace TaskDialogLibrary.Classes;

public class ResourceItem
{
    /// <summary>
    /// Resource name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Image which is either an icon or bitmap
    /// </summary>
    public Bitmap Image { get; set; }

    public Icon Icon { get; set; }
    /// <summary>
    /// Indicates if dealing with an icon so when displaying the
    /// control used to display can adjust it's size or Size mode
    /// </summary>
    public bool IsIcon { get; set; }

    public override string ToString() => Name;
}