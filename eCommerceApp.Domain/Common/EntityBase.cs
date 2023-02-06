namespace eCommerceApp.Domain.Common;

public class EntityBase
{
    public int Id { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public bool IsRemoved { get; set; } = false;
}