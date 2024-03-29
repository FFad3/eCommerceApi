﻿namespace eCommerceApp.Domain;

public abstract class EntityBase
{
    public int Id { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public bool IsRemoved { get; set; } = false;
}