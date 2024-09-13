using System.ComponentModel.DataAnnotations;
#nullable disable
namespace TraitsTestProject.Models;

public class MobileDeviceCodes
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} Required")]
    [RegularExpression(@"[A-Z]$", 
        ErrorMessage = "Only uppercase Characters are allowed for {0}.")]
    public char Code { get; set; }

    [Required(ErrorMessage = "{0} Required")]
    public string Description { get; set; }

    public bool ValidFlag { get; set; }
}