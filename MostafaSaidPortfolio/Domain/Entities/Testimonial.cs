using MostafaSaidPortfolio.Domain.Common;

namespace MostafaSaidPortfolio.Domain.Entities;

/// <summary>
/// Testimonial/Review entity
/// </summary>
public class Testimonial : BaseEntity
{
    /// <summary>
    /// Testimonial author name
    /// </summary>
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>
    /// Author's position/title
    /// </summary>
    public string Position { get; set; } = string.Empty;

    /// <summary>
    /// Author's company
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// Testimonial content
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Rating (1-5 stars)
    /// </summary>
    public int Rating { get; set; } = 5;

    /// <summary>
    /// Author image URL
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Is featured testimonial
    /// </summary>
    public bool IsFeatured { get; set; }

    /// <summary>
    /// Display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Is approved for display
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// Validate rating is between 1-5
    /// </summary>
    public bool IsValidRating => Rating >= 1 && Rating <= 5;
}
