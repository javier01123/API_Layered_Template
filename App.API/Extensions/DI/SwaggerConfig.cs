using App.Application.Loggers;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace App.API.Extensions.DI
{
    public static class SwaggerConfig
    {

        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title="API_NAME", Version="v1"});

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert jwt token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"

                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                var apiProject = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";  
                var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiProject);
                c.IncludeXmlComments(apiXmlPath);


                var applicationProject = $"{typeof(TextLogger).Assembly.GetName().Name}.xml";
                var applicationXmlPath = Path.Combine(AppContext.BaseDirectory, applicationProject);
                c.IncludeXmlComments(applicationXmlPath);

            });
        }
    }
}
