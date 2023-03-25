using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace App.API.Extensions.DI
{
    internal static class LocalizationConfig
    {
       internal static void ConfigureLocalization(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("es")
                    };

                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;                
            });
        }

    }
}
