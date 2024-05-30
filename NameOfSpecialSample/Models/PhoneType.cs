#nullable disable
namespace NameOfSpecialSample.Models;

public partial class PhoneType
{
    public int PhoneTypeIdenitfier { get; set; }

    public string PhoneTypeDescription { get; set; }

    public virtual ICollection<ContactDevices> ContactDevices { get; set; } = new List<ContactDevices>();
}