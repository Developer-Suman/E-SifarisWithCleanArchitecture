using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Command.Inatilize
{
    public class InitiallizeCommandHandler : IRequestHandler<InitializeCommand, Result<InitializeResponse>>
    {
        private readonly IinitializeRepository _initializeRepository;

        public InitiallizeCommandHandler(IinitializeRepository iinitializeRepository)
        {
            _initializeRepository = iinitializeRepository;
            
        }
        public async Task<Result<InitializeResponse>> Handle(InitializeCommand request, CancellationToken cancellationToken)
        {
            var branch = new Branch
           (
               Guid.NewGuid(),
               request.branchNameInNepali,
               request.branchNameInEnglish,
               request.provinceId,
               request.districtId,
               request.localGovernment,
               request.addressInEnglish,
               request.addressInNepali,
               request.branchContactInEnglish,
               request.branchContactInNepali,
               request.officeHead,
               request.basicInformation,
               request.logoURL,
               request.headerInEnglish,
               request.headerInNepali,
               request.footerInEnglish,
               request.footerInNepali,
               request.watermarkURL,
               request.branchTypeId,
               request.wardId,
               request.departmentId,
               request.municipalityId,
               request.vDCId,
               request.isActive
               );

            await _initializeRepository.Initialize(branch);

            var dto = new InitializeResponse(
                BranchNameInNepali: branch.BranchContactInNepali
                );

        
            return Result<InitializeResponse>.Success(dto);
        }
    }
}
