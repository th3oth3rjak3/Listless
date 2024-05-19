namespace Listless.Core

open System

module Models =

    /// <summary>
    /// Represents a list item.
    /// </summary>
    type ListItem = {
        /// The unique ID of the item.
        Id: int
        /// The name of the item.
        Name: string
        /// True when the item is completed, otherwise false.
        IsComplete: bool
    }

    /// <summary>
    /// A user created list which may contain items.
    /// </summary>
    type UserList = {
        /// The unique ID for this list.
        Id: int
        /// The name of the list.
        Name: string
        /// The items that belong to this list.
        Items: ListItem seq
    }