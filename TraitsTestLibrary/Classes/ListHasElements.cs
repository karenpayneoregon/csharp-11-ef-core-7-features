using System.Collections;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace TraitsTestLibrary.Classes;

public class ListHasElements : ValidationAttribute
{
    public override bool IsValid(object sender)
    {
        if (sender == null)
        {
            return false;
        }

        if (sender.IsList())
        {
            var result = ((IEnumerable)sender).Cast<object>().ToList();
            return result.Any();
        }
        else
        {
            return false;
        }
    }

}