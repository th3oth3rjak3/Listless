namespace Listless.Domain.Models;

/// <summary>
/// A list of items that a user has created.
/// </summary>
/// <param name="Id">The unique id of the list from the database.</param>
/// <param name="Name">The name of the list.</param>
/// <param name="Items">A collection of list items.</param>
public record UserList(int Id, string Name, IEnumerable<ListItem> Items);
