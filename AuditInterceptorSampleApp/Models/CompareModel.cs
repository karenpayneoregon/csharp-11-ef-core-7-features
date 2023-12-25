namespace AuditInterceptorSampleApp.Models;

public class CompareModel
{
    public object OriginalValue { get; set; }

    public object NewValue { get; set; }
    public string EntityState { get; set; }
}