using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Login
{
    public class LogInRequestValidator : AbstractValidator<LoginRequest>
    {
        public LogInRequestValidator()
        {
            RuleFor(x=>x.username).NotEmpty();
            RuleFor(x=>x.password).NotEmpty();
        }
    }
}
