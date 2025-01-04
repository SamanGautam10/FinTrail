using FinTrail.Services;
using FinTrail.Services.Interface;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace FinTrail
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddMudServices();
            builder.Services.AddScoped<IUserInterface, UserService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IDebtInterface, DebtService>();
#endif

            return builder.Build();
        }
    }
}
