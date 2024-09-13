using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

namespace TraitsTestLibrary.Classes;
public class RequiredEnumAttribute : RequiredAttribute
{
    public override bool IsValid(object sender)
    {
        if (sender == null)
        {
            return false;
        }

        var type = sender.GetType();
        return type.IsEnum && Enum.IsDefined(type, sender); ;
    }
}
