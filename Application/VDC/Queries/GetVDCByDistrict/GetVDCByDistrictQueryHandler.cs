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

            List<GetVDCByDistrictIdResponse> getVDCByDistrictIdResponses = new List<GetVDCByDistrictIdResponse>();
            if(vdcs is not null && vdcs.Count > 0)
            {
                foreach(var vd in vdcs)
                {
                    getVDCByDistrictIdResponses.Add(new GetVDCByDistrictIdResponse(
                        vd.Id,
                        vd.VDCNameInNepali,
                        vd.VDCNameInEnglish,
                        vd.DistrictId
                        ));

                }
            }

            return Result<List<GetVDCByDistrictIdResponse>>.Success(getVDCByDistrictIdResponses);
        }
    }
}
