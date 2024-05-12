using Listless.Domain;
using Listless.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using MudBlazor.Services;

using static Listless.Persistence.PersistenceRegistration;

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
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
        builder.Services.RegisterDomainServices();
        var appData = FileSystem.AppDataDirectory;
        builder.Services.RegisterPersistenceServices(FileSystem.AppDataDirectory);

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        var ctx = app.Services.GetRequiredService<ListlessContext>();
        ctx.Database.Migrate();
        ctx.Dispose();

        return app;
    }
}
