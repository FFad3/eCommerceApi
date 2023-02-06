using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain;

[Table("Baskets")]
public class Basket : EntityBase
{
    public Basket()
    {
        Items = new List<BasketItem>();
    }

    public Guid UserId { get; set; }

    public ICollection<BasketItem> Items { get; set; }
}