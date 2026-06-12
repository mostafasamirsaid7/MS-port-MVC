namespace MostafaSaidPortfolio.Domain.Common;

/// <summary>
/// Base entity for all domain entities with GUID primary key and soft delete support
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Unique identifier (GUID)
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Last update timestamp
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// User ID who created the entity
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// User ID who last updated the entity
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Soft delete flag
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Soft delete timestamp
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// User ID who deleted the entity
    /// </summary>
    public string? DeletedBy { get; set; }

    /// <summary>
    /// Mark entity as deleted (soft delete)
    /// </summary>
    public void SoftDelete(string? deletedBy = null)
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = deletedBy;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Restore deleted entity (soft delete recovery)
    /// </summary>
    public void Restore()
    {
        IsDeleted = false;
        DeletedAt = null;
        DeletedBy = null;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Mark entity as updated
    /// </summary>
    public void MarkAsUpdated(string? updatedBy = null)
    {
        UpdatedAt = DateTime.UtcNow;
        if (!string.IsNullOrWhiteSpace(updatedBy))
            UpdatedBy = updatedBy;
    }
}
