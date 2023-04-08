using Microsoft.AspNetCore.Identity;

namespace App.Application.Modules.Jwt
{
    public interface IJwtProvider
    {
        string CreateToken(IdentityUser user);
    }
}