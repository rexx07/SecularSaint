namespace SS.Domain.Contracts;

public class AuditableEntity : BaseEntity
{
    protected AuditableEntity()
    {
        CreatedOn = DateTime.UtcNow;
        LastUpdatedOn = DateTime.UtcNow;
    }

    public DateTime CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    public Guid LastUpdatedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public string? DeletedBy { get; set; }
    public string? Note { get; set; }
}