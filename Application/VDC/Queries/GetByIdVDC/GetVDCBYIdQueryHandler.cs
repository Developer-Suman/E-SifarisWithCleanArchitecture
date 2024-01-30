using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VDC.Queries.GetByIdVDC
{
    public sealed class GetVDCBYIdQueryHandler : IRequestHandler<GetVDCByIdQuery, Result<GetByIdVDCResponse>>
    {

        private readonly IVDCRepository _vdcRepository;

        public GetVDCBYIdQueryHandler(IVDCRepository vDCRepository)
        {
            _vdcRepository = vDCRepository;
            
        }
        public async Task<Result<GetByIdVDCResponse>> Handle(GetVDCByIdQuery request, CancellationToken cancellationToken)
        {
            var vdc = await _vdcRepository.GetById(request.VDCId);
            if(vdc is null)
            {
                return Result<GetByIdVDCResponse>.Failure("Not Found");
            }

            GetByIdVDCResponse getByIdVDCResponse = new(
                vdc.Id,
                vdc.VDCNameInNepali,
                vdc.VDCNameInEnglish,
                vdc.DistrictId
                );

            return Result<GetByIdVDCResponse>.Success( getByIdVDCResponse );

        }
    }
}
