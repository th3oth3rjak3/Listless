namespace Listless.Core

open System.Runtime.CompilerServices

type OptionExtensions =
    [<Extension>]
    static member inline IsSome(optional: Option<'a>) =
        match optional with
        | Some _ -> true
        | None -> false
        
    [<Extension>]
    static member inline IsNone(optional: Option<'a>) =
        match optional with
        | None -> true
        | Some _ -> false