using Domain.Common;

namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Product> Products {get; set;} = new List<Product>();
}