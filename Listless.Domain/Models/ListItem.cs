namespace Listless.Domain.Models;

/// <summary>
/// A single item in a list.
/// </summary>
/// <param name="Id">The unique id of the item.</param>
/// <param name="ListId">The id of the parent list.</param>
/// <param name="Description">The description of the list item.</param>
/// <param name="IsStarted">A flag to indicate that this item has been started.</param>
/// <param name="IsComplete">A flag to indicate that this item has been completed.</param>
/// <param name="StartBy">A date that indicates when the item should be started.</param>
/// <param name="DueBy">A date that indicates when the item should be finished.</param>
public record ListItem(
    int Id,
    int ListId,
    string Description,
    bool IsStarted,
    bool IsComplete,
    DateTime StartBy,
    DateTime DueBy);
