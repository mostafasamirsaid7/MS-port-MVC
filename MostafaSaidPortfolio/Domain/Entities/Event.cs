using MostafaSaidPortfolio.Domain.Common;
using MostafaSaidPortfolio.Domain.Enums;

namespace MostafaSaidPortfolio.Domain.Entities;

/// <summary>
/// Event entity
/// </summary>
public class Event : BaseEntity
{
    /// <summary>
    /// Event title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Event description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Event date/time
    /// </summary>
    public DateTime EventDate { get; set; }

    /// <summary>
    /// Event end date/time
    /// </summary>
    public DateTime? EventEndDate { get; set; }

    /// <summary>
    /// Event location
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Event status
    /// </summary>
    public EventStatus Status { get; set; } = EventStatus.Upcoming;

    /// <summary>
    /// Event URL/link
    /// </summary>
    public string? EventUrl { get; set; }

    /// <summary>
    /// Maximum attendees (null for unlimited)
    /// </summary>
    public int? MaxAttendees { get; set; }

    /// <summary>
    /// Current registered count
    /// </summary>
    public int RegisteredCount { get; set; }

    /// <summary>
    /// Is event featured
    /// </summary>
    public bool IsFeatured { get; set; }

    /// <summary>
    /// Display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Check if event is upcoming
    /// </summary>
    public bool IsUpcoming => EventDate > DateTime.UtcNow;

    /// <summary>
    /// Check if event is ongoing
    /// </summary>
    public bool IsOngoing => EventDate <= DateTime.UtcNow && (!EventEndDate.HasValue || EventEndDate >= DateTime.UtcNow);

    /// <summary>
    /// Check if event has available spots
    /// </summary>
    public bool HasAvailableSpots => !MaxAttendees.HasValue || RegisteredCount < MaxAttendees;
}
