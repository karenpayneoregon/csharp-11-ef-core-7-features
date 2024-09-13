namespace TraitsTestLibrary.Classes;
public partial class Model
{
    /// <summary>
    /// Validate entity against validation rules
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static EntityValidationResult Validate<T>(T entity) where T : class
        => (new EntityValidator<T>()).Validate(entity);

}