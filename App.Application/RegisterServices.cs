using App.Application.Context;
using App.Application.Modules.Jwt;
using App.Application.Services.Auth;
using App.Application.Services.Users;
using App.Application.Services.Users.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace App.Application
{
    public static class RegisterServices
    {

        public static void AddAplicationLayerServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("Default"), b => b.MigrationsAssembly("App.Application"));
            });

            services.AddValidatorsFromAssemblyContaining<CreateUserDTOValidator>();
            services.AddTransient<IJwtProvider, JwtProvider>();

            //todo: automate the service registration?
            //register services
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IAuthService, AuthService>(); 
        }

        public static IdentityBuilder AddEFStores(this IdentityBuilder builder)
        {
            return builder.AddEntityFrameworkStores<AppDbContext>();
        }

    }
}
