
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnumHasConversion.Models
{
    /// <summary>
    /// WineType auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public enum WineType
    {
        [Description("Classic red")] 
        [Display(Name = "Classic red")] 
        Red = 1,
        [Description("Dinner white")] 
        [Display(Name = "Dinner white")] 
        White = 2,
        [Description("Imported rose")] 
        [Display(Name = "Imported rose")] 
        Rose = 3
    }
}
