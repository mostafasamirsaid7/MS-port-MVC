using MostafaSaidPortfolio.Domain.Common;

namespace MostafaSaidPortfolio.Domain.Entities;

/// <summary>
/// Newsletter subscriber entity
/// </summary>
public class NewsletterSubscriber : BaseEntity
{
    /// <summary>
    /// Subscriber email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Subscriber name (optional)
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Is subscription active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Email confirmed
    /// </summary>
    public bool IsConfirmed { get; set; }

    /// <summary>
    /// Confirmation token
    /// </summary>
    public string? ConfirmationToken { get; set; }

    /// <summary>
    /// Confirmed date
    /// </summary>
    public DateTime? ConfirmedAt { get; set; }

    /// <summary>
    /// Unsubscribe date
    /// </summary>
    public DateTime? UnsubscribedAt { get; set; }

    /// <summary>
    /// Unsubscribe token
    /// </summary>
    public string? UnsubscribeToken { get; set; }

    /// <summary>
    /// Confirm subscription
    /// </summary>
    public void Confirm()
    {
        IsConfirmed = true;
        ConfirmedAt = DateTime.UtcNow;
        IsActive = true;
        ConfirmationToken = null;
        MarkAsUpdated();
    }

    /// <summary>
    /// Unsubscribe from newsletter
    /// </summary>
    public void Unsubscribe()
    {
        IsActive = false;
        UnsubscribedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }

    /// <summary>
    /// Resubscribe
    /// </summary>
    public void Resubscribe()
    {
        IsActive = true;
        UnsubscribedAt = null;
        MarkAsUpdated();
    }
}
