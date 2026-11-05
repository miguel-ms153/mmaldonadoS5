using Microsoft.Extensions.Logging;
using mmaldonadoS5.Repositories;
using mmaldonadoS5.Utils;

namespace mmaldonadoS5
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = FileAccesHelper.GetLocalFilePath("uisrael.db");
            builder.Services.AddSingleton<PersonRepository>
                (s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
