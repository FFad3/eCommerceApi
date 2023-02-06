using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain;

[Table("Categories")]
public class Category : EntityBase
{
    public Category()
    {
        Products = new List<Product>();
    }

    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; }
}