using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Users.DTO
{
    public class RegisterUserDTO
    {
        public string UserName { get; set;}
        public string Password { get; set;}
        public string Email { get; set;}
    }

    public class CreateUserDTOValidator:AbstractValidator<RegisterUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty()
                                 .EmailAddress();
        }
    }
}
