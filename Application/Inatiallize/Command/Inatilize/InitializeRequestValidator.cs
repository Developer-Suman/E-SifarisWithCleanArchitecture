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
            RuleFor(x=>x.localGovernment).NotEmpty();
            RuleFor(x => x.addressInEnglish).NotEmpty();
            RuleFor(x => x.addressInNepali).NotEmpty();
            RuleFor(x => x.branchContactInEnglish).NotEmpty();
            RuleFor(x => x.branchContactInNepali).NotEmpty();
            RuleFor(x => x.officeHead).NotEmpty();
            RuleFor(x => x.basicInformation).NotEmpty();
            RuleFor(x => x.logoURL).NotEmpty();
            RuleFor(x => x.headerInEnglish).NotEmpty();
            RuleFor(x => x.headerInNepali).NotEmpty();
            RuleFor(x => x.footerInEnglish).NotEmpty();
            RuleFor(x => x.footerInNepali).NotEmpty();
            RuleFor(x => x.watermarkURL).NotEmpty();
            RuleFor(x=>x.isActive).NotEmpty();
               

            
        }
    }
}
