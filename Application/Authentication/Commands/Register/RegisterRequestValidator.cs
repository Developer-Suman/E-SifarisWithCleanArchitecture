using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Register
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x=>x.username).NotEmpty();
            RuleFor(x=>x.password).NotEmpty();
            RuleFor(x => x.email).NotEmpty();
            
        }
    }
}
