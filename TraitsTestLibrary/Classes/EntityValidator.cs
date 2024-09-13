using System.ComponentModel.DataAnnotations;

namespace TraitsTestLibrary.Classes;

public class EntityValidator<T> where T : class
{
    public EntityValidationResult Validate(T entity)
    {
        var validationResults = new List<ValidationResult>();
        var vc = new ValidationContext(entity, null, null);
        var isValid = Validator.TryValidateObject(entity, vc, validationResults, true);

        return new EntityValidationResult(validationResults);

    }
}