using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnumHasConversion.Models;
#nullable disable
[Table("WineType")]
public class WineTypes
{
    [Key]
    public int Id { get; set; }
    public string TypeName { get; set; }
    public string  Description { get; set; }
}
