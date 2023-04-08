using App.Application.Services._Base;
using App.Application.Services.Auth.DTO;

namespace App.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResult<AuthenticationResponseDTO>> Authenticate(AuthenticationRequestDTO request);
    }
}