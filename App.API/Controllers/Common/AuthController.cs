
using App.Application.Services.Auth;
using App.Application.Services.Auth.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers.Common
{
    [Route("api/auth")]
    public class AuthController:APIBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthenticationRequestDTO dto)
        {
            var res = await _authService.Authenticate(dto);
            return ServiceResultToResponse(res);
        }



    }
}
