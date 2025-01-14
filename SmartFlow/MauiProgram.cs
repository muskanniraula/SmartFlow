using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using SmartFlow.Interface;
using SmartFlow.Models;
using SmartFlow.Services;
using SmartFlow.Services.Interface;


namespace SmartFlow
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add Blazor WebView
            builder.Services.AddMauiBlazorWebView();

            // Add MudBlazor services
            builder.Services.AddMudServices();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IDebtService, DebtService>();
            builder.Services.AddScoped<GlobalState>();


#if DEBUG

            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}