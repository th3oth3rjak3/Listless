using Listless.Core;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

using MudBlazor.Services;
using static Listless.StartupExtensions;

namespace Listless;

/// <summary>
/// The entry point for the Maui app.
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// Create the new Maui app.
    /// </summary>
    /// <returns>A new MauiApp.</returns>
    public static MauiApp CreateMauiApp()
    {
        var appData = FileSystem.AppDataDirectory;
        var connectionString = $"Filename={appData}/Listless.db3";
        Migration.runMigrations(connectionString);

        using var dbConnection = new SqliteConnection(connectionString);
        
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
        builder.Services.RegisterPersistenceServices(dbConnection);
        
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();


        return app;
    }
}
