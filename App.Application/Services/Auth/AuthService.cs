using App.Application.Modules.Jwt;
using App.Application.Services._Base;
using App.Application.Services.Auth.DTO;
using Microsoft.AspNetCore.Identity;

namespace App.Application.Services.Auth
{
    internal class AuthService : BaseService, IAuthService
    {
        //todo: abstract token provider
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<IdentityUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
        }

        public async Task<ServiceResult<AuthenticationResponseDTO>> Authenticate(AuthenticationRequestDTO request)
        {
            IdentityUser user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                return ServiceResult<AuthenticationResponseDTO>.Failure("Invalid Credentials");

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                return ServiceResult<AuthenticationResponseDTO>.Failure("Invalid Credentials");

            var response = new AuthenticationResponseDTO()
            {
                Token = _jwtProvider.CreateToken(user)
            };

            return ServiceResult<AuthenticationResponseDTO>.Success(response);
        }
    }
}
