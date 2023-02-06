using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain;

[Table("BasketItems")]
public class BasketItem : EntityBase
{
    public int BastekId { get; set; }
    public Basket? Basket { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}