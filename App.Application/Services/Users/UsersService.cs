using App.Application.Extensions;
using App.Application.Services._Base;
using App.Application.Services.Users.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Users
{
    internal class UsersService : IUsersService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        //TODO: create a default for service result, like the TASK class, it can take a type or not.
        public async Task<ServiceResult> Register(CreateUserDTO dto)
        {
            IdentityResult identityResult = await _userManager.CreateAsync(
                new IdentityUser()
                {
                    UserName = dto.UserName,
                    Email = dto.Email
                }, dto.Password);

            if (identityResult.Succeeded)
                return ServiceResult.Success();

            return ServiceResult.Failure(identityResult.MapResultToServiceErrors());
        }

    }
}
