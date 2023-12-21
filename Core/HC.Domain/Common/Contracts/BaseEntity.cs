using System.ComponentModel.DataAnnotations;

namespace HC.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; init; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; private set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }
}

