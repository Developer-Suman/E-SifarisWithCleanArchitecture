using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Command.Inatilize
{
    public class InitializeRequestValidator : AbstractValidator<InitializeRequest>
    {
        public InitializeRequestValidator()
        {
            RuleFor(x=>x.BranchNameInEnglish).NotEmpty();
            RuleFor(x=>x.BranchNameInNepali).NotEmpty();
            
        }
    }
}
