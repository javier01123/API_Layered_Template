
using App.API.Extensions.DI;
using App.API.Middleware;
using App.Application;
using App.Application.Loggers.Text;
using App.Application.SharedResources;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;
var logging = builder.Logging;

// Add services to the container.

services.AddLogging();
services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
services.ConfigureLocalization();
//using our text logger
services.AddTextFileLogging();

services.AddProblemDetails(options =>
    options.CustomizeProblemDetails = (context) =>
    {
        context.ProblemDetails.Extensions["traceId"] = Activity.Current?.Id;
    }
).AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});


//services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//make http context accesso injectable in the Service Layer
services.AddHttpContextAccessor();

services.AddHealthChecks();

//register identity user and entity framework as a store
services.AddDefaultIdentity<IdentityUser>(options =>
                                          options.SignIn.RequireConfirmedAccount = true)
        .AddEFStores()
        .AddDefaultTokenProviders();

services.AddAplicationLayerServices(config);
//services.AddJwtAuthentication(config);

//fluent validation
services.AddFluentValidationAutoValidation(opts =>
{
    //prevent mixing fluent validation and data annotations
    opts.DisableDataAnnotationsValidation = true;
}).AddFluentValidationClientsideAdapters();

services.AddValidatorsFromAssemblyContaining<Program>();
services.AddValidatorsFromAssemblyContaining<DTOProperties>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();

    //WARNING: dont use any origin in production
    app.UseCors(options => options.AllowAnyMethod()
                                  .AllowAnyHeader()
                                  .AllowCredentials()
                                  .WithOrigins("http://localhost:3000")
                );
}

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseStatusCodePages();
app.UseMiddleware<AppExceptionsMiddleware>();




app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/healthz");
app.Run();
