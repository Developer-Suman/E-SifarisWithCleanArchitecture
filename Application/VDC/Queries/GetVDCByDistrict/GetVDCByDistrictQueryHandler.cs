using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VDC.Queries.GetVDCByDistrict
{
    public class GetVDCByDistrictQueryHandler : IRequestHandler<GetVDCByDistrictidQuery, Result<List<GetVDCByDistrictIdResponse>>>
    {

        private readonly IVDCRepository _vDCRepository;
        public GetVDCByDistrictQueryHandler(IVDCRepository vDCRepository)
        {
            _vDCRepository = vDCRepository;
            
        }
        public async Task<Result<List<GetVDCByDistrictIdResponse>>> Handle(GetVDCByDistrictidQuery request, CancellationToken cancellationToken)
        {
            var vdcs = await _vDCRepository.GetByDistrictId(request.districtId);

            List<GetVDCByDistrictIdResponse> getVdcByDistrictIdResponses = new List<GetVDCByDistrictIdResponse>();

            if (vdcs is not null && vdcs.Count > 0)
            {
                foreach (var vdc in vdcs)
                {
                    getVdcByDistrictIdResponses.Add(new GetVDCByDistrictIdResponse(
                        vdc.Id,
                        vdc.VDCNameInNepali,
                        vdc.VDCNameInEnglish,
                        vdc.DistrictId
                        ));
                }
            }
            return Result<List<GetVDCByDistrictIdResponse>>.Success(getVdcByDistrictIdResponses);


        }
    }
}
