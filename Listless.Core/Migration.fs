namespace Listless.Core

open System
open DbUp
open Listless.Core.Models

module Migration =
    
    let runMigrations (connectionString: string) : unit =
        let migrator =
            DeployChanges
                .To
                .SQLiteDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(typeof<UserList>.Assembly)
                .LogToConsole()
                .Build()
                
        let migrationResult = migrator.PerformUpgrade()
        if migrationResult.Successful then
            Console.ForegroundColor <- ConsoleColor.Green
            Console.WriteLine("Migration successful")
            Console.ResetColor()
        else
            Console.ForegroundColor <- ConsoleColor.Red
            Console.WriteLine(migrationResult.Error)
            Console.ResetColor()
#if DEBUG
        // Keep the console open
        Console.ReadLine() |> ignore
#endif
           

