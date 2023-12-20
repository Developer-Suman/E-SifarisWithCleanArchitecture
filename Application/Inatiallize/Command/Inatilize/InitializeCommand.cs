
using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Command.Inatilize
{
    public record InitializeCommand(
        
        string branchNameInNepali,
        string branchNameInEnglish,
        string provinceId,
        string districtId,
        string localGovernment,
        string addressInEnglish,
        string addressInNepali,
        string branchContactInEnglish,
        string branchContactInNepali,
        string officeHead,
        string basicInformation,
        string logoURL,
        string headerInEnglish,
        string headerInNepali,
        string footerInEnglish,
        string footerInNepali,
        string watermarkURL,
        string branchTypeId,
        string wardId,
        string departmentId,
        string municipalityId,
        string vDCId,
        string isActive) : IRequest<Result<InitializeResponse>>;
    
}
