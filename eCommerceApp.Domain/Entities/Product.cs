using eCommerceApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain.Entities;

[Table("Products")]
public class Product : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }
    public string? ImgUrl { get; set; }
}