using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain;

[Table("Orders")]
public class Order : EntityBase
{
    public Order()
    {
        Items = new List<OrderItem>();
    }

    public ICollection<OrderItem> Items { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
}