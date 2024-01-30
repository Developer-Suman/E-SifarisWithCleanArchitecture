
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
        int? provinceId,
        int? districtId,
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
        int? branchTypeId,
        int? wardId,
        int? departmentId,
        int? municipalityId,
        int? vDCId,
        bool? isActive) : IRequest<Result<InitializeResponse>>;
    
}
