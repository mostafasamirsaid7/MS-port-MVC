using MostafaSaidPortfolio.Domain.Common;

namespace MostafaSaidPortfolio.Domain.Entities;

/// <summary>
/// Tag entity for categorizing blog posts and projects
/// </summary>
public class Tag : BaseEntity
{
    /// <summary>
    /// Tag name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// URL-friendly slug
    /// </summary>
    public string Slug { get; set; } = string.Empty;

    /// <summary>
    /// Tag color (for UI display)
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Usage count
    /// </summary>
    public int UsageCount { get; set; }

    // Navigation properties
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
