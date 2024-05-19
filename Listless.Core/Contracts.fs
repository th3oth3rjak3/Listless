namespace Listless.Core

open System
open System.Threading.Tasks
open Listless.Core.Models

module Contracts =
    
    /// A repository which provides access to User Generated Lists.
    type IListRepository =
        /// Try to get a single list by its ID.
        abstract member TryGetList : int -> Task<UserList option>
        /// Get all user lists.
        abstract member GetAllLists : unit -> Task<UserList seq>

