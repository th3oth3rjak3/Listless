namespace Listless.Core

open System.Data
open Donald
open System.Threading.Tasks
open Listless.Core.Models

module Persistence =
    open Contracts

    let mapUserListFromReader (reader: Common.DbDataReader) : UserList =
        { Id = reader.ReadInt32 "ID"
          Name = reader.ReadString "NAME"
          Items = [] }
        
    let mapListItemFromReader (reader: Common.DbDataReader) : ListItem =
        { Id = reader.ReadInt32 "ID"
          Name = reader.ReadString "NAME"
          IsComplete = reader.ReadBoolean "IS_COMPLETE" }
    
    let getListItemsByListId (connection: IDbConnection) (id: int) : Task<ListItem seq> =
        connection
        |> Db.newCommand "
            SELECT ID, NAME, IS_COMPLETE
            FROM LIST_ITEMS
            WHERE LIST_ID = @list_id"
        |> Db.setParams [
            "list_id", SqlType.Int32 id ]
        |> Db.Async.query mapListItemFromReader
        |> fun task -> async {
            let! items = task |> Async.AwaitTask
            return items |> Seq.ofList
        } |> Async.StartAsTask
    
    let tryGetUserListById (connection: IDbConnection) (id: int) : Task<UserList option> =
        let items = getListItemsByListId connection id
        
        connection
        |> Db.newCommand "
            SELECT ID, NAME
            FROM USER_LISTS
            WHERE ID = @list_id"
        |> Db.setParams ["list_id", SqlType.Int32 id]
        |> Db.Async.querySingle mapUserListFromReader
        |> fun task -> async {
            let! userList = task |> Async.AwaitTask
            let! items = items |> Async.AwaitTask
            let result =
                match userList with
                | Some(userList) -> { userList with Items = items } |> Some
                | None -> None
            return result
        } |> Async.StartAsTask
    
    let getAllUserLists connection () =
        async {
            let! userLists =
                connection
                |> Db.newCommand "
                    SELECT ID, NAME
                    FROM USER_LISTS"
                |> Db.Async.query mapUserListFromReader
                |> Async.AwaitTask
            
            let! results =
                userLists
                |> List.map(fun userList ->
                    async {
                        let! items = getListItemsByListId connection userList.Id |> Async.AwaitTask
                        return { userList with Items = items }
                    })
                |> Async.Parallel
            
            return results |> Seq.ofArray
        }
        |> Async.StartAsTask

    
    type ListRepository(connection: IDbConnection) =
        member private this.dbConnection: IDbConnection = connection
        
        interface IListRepository with
            member this.TryGetList id = tryGetUserListById this.dbConnection id
            member this.GetAllLists() = getAllUserLists this.dbConnection ()
            
            