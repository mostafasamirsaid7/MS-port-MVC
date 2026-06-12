using MostafaSaidPortfolio.Domain.Common;

namespace MostafaSaidPortfolio.Domain.Entities;

/// <summary>
/// Blog post comment entity
/// </summary>
public class Comment : BaseEntity
{
    /// <summary>
    /// Comment content
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Commenter name (if not logged in)
    /// </summary>
    public string? AuthorName { get; set; }

    /// <summary>
    /// Commenter email (if not logged in)
    /// </summary>
    public string? AuthorEmail { get; set; }

    /// <summary>
    /// Commenter website (optional)
    /// </summary>
    public string? AuthorWebsite { get; set; }

    /// <summary>
    /// Approval status
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// Blog post ID
    /// </summary>
    public Guid BlogPostId { get; set; }

    /// <summary>
    /// User ID (if logged in)
    /// </summary>
    public string? UserId { get; set; }

    // Navigation properties
    public BlogPost? BlogPost { get; set; }
    public ApplicationUser? User { get; set; }
}
