using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Auth.DTO
{
    public class AuthenticationRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationRequestDTOValidator : AbstractValidator<AuthenticationRequestDTO>
    {
        public AuthenticationRequestDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
