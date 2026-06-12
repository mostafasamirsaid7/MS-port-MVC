using MostafaSaidPortfolio.Domain.Common;

namespace MostafaSaidPortfolio.Domain.Entities;

/// <summary>
/// Contact message/inquiry entity
/// </summary>
public class ContactMessage : BaseEntity
{
    /// <summary>
    /// Sender name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Sender email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Message subject
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// Message content
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Has message been read
    /// </summary>
    public bool IsRead { get; set; }

    /// <summary>
    /// Has message been replied to
    /// </summary>
    public bool IsReplied { get; set; }

    /// <summary>
    /// Reply message
    /// </summary>
    public string? ReplyMessage { get; set; }

    /// <summary>
    /// Reply date
    /// </summary>
    public DateTime? RepliedAt { get; set; }

    /// <summary>
    /// User ID (if sender is logged in)
    /// </summary>
    public string? UserId { get; set; }

    // Navigation properties
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Mark message as read
    /// </summary>
    public void MarkAsRead()
    {
        IsRead = true;
        MarkAsUpdated();
    }

    /// <summary>
    /// Add reply to message
    /// </summary>
    public void AddReply(string reply, string? repliedBy = null)
    {
        ReplyMessage = reply;
        IsReplied = true;
        RepliedAt = DateTime.UtcNow;
        UpdatedBy = repliedBy;
        MarkAsUpdated(repliedBy);
    }
}
