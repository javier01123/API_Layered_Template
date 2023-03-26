using App.Application.Modules.Jwt;
using App.Application.Services.Auth.DTO;

namespace App.Application.Services.Auth
{
    internal class AuthenticationService
    {
        //todo: abstract token provider
        public AuthenticationService(JwtTokenProvider jwtTokenProvider)
        {

        }

        public AuthenticationResponseDTO Authenticate()
        {
            throw new NotImplementedException();
        }
    }
}
