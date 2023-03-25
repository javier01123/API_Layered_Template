using App.Application.Context;
using App.Application.Services.Users;
using App.Application.Services.Users.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddTransient<IUsersService, UsersService>();  
        }

        public static IdentityBuilder AddEFStores(this IdentityBuilder builder)
        {
            return builder.AddEntityFrameworkStores<AppDbContext>();
        }

    }
}
