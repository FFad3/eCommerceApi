using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain;

[Table("Carts")]
public class Cart : EntityBase
{
    public Cart()
    {
        Items = new List<CartItem>();
    }

    public Guid UserId { get; set; }

    public ICollection<CartItem> Items { get; set; }
}