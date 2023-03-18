using App.Application.Services._Base;
using App.Application.Services.Users.DTO;

namespace App.Application.Services.Users
{
    public interface IUsersService
    {
        Task<ServiceResult> Register(CreateUserDTO dto);
    }
}