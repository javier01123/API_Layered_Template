using App.Application.SharedResources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace App.Application.Services.Users.DTO
{
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        public CreateUserDTOValidator(IStringLocalizer<DTOProperties> localizer)
        {
            RuleFor(x => x.UserName).NotEmpty()
                                     .WithName(localizer["Username"]);
            RuleFor(x => x.Password).NotEmpty()
                                    .WithName(localizer["Password"]);
            RuleFor(x => x.Email).NotEmpty()
                                 .EmailAddress()
                                 .WithName(localizer["Email"]);
        }
    }
}
