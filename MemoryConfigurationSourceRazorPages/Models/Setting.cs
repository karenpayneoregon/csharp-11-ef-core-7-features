
#nullable disable
namespace MemoryConfigurationSourceRazorPages.Models;

public partial class Setting
{
    public int Id { get; set; }

    public string Section { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }
}