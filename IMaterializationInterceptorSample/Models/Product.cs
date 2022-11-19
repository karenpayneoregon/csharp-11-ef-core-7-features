using System.ComponentModel.DataAnnotations.Schema;
using IMaterializationInterceptorSample.Interfaces;

namespace IMaterializationInterceptorSample.Models;

public class Product : IHasRetrieved
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public override string ToString() => Name;
    [NotMapped]
    public DateTime Retrieved { get; set; }

}
