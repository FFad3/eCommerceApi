﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain;

[Table("OrderItems")]
public class OrderItem : EntityBase
{
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public Guid UserId { get; set; }
}