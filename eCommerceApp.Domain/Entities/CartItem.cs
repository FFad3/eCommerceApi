using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain;

[Table("CartItems")]
public class CartItem : EntityBase
{
    public int CartId { get; set; }
    public Cart? Cart { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}