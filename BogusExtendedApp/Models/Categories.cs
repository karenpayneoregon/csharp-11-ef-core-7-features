using System.Drawing;

namespace BogusExtendedApp.Models;

public class Categories
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public byte[] Photo { get; set; }
    public Bitmap Picture { get; set; }
}