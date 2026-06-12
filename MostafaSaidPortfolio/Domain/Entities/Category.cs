using MostafaSaidPortfolio.Domain.Common;

namespace MostafaSaidPortfolio.Domain.Entities;

/// <summary>
/// Category entity for organizing blog posts and projects
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// Category name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Category description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// URL-friendly slug
    /// </summary>
    public string Slug { get; set; } = string.Empty;

    /// <summary>
    /// Icon class (CSS/Font Awesome)
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// Display color
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Display background color
    /// </summary>
    public string BackgroundColor { get; set; } = string.Empty;

    /// <summary>
    /// Display order in UI
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Is category active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Parent category ID (for hierarchical categories)
    /// </summary>
    public Guid? ParentId { get; set; }

    // Navigation properties
    public Category? ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; } = new List<Category>();
    public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
