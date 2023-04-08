using App.Application.Services._Base;
using App.Application.Services.Users;
using App.Application.Services.Users.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers.Common
{

    [Route("api/sign-up")]
    public class UsersController : APIBaseController
    {
        private readonly IUsersService _usersService;


        public UsersController(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        [AllowAnonymous()]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO dto)
        {
            ServiceResult res = await _usersService.Register(dto);
            return ServiceResultToResponse(res);
        }

    }
}
