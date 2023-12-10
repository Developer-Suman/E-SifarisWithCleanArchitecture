using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VDC.Queries.GetAllVDC
{
    public sealed class GetAllVDCQueryHandler : IRequestHandler<GetAllVDCQuery, Result<List<GetAllVDCResponse>>>
    {
        private readonly IVDCRepository _vdcrepository;

        public GetAllVDCQueryHandler(IVDCRepository vDCRepository)
        {
            _vdcrepository = vDCRepository;
           
        }
        public async Task<Result<List<GetAllVDCResponse>>> Handle(GetAllVDCQuery request, CancellationToken cancellationToken)
        {
            var vdcs = await _vdcrepository.GetAll();

            List<GetAllVDCResponse> getAllVDCResponses = new List<GetAllVDCResponse>();
            if(vdcs is not null && vdcs.Count>0)
            {
                foreach(var vd in vdcs)
                {
                    getAllVDCResponses.Add(new GetAllVDCResponse(
                        vd.Id,
                        vd.VDCNameInNepali,
                        vd.VDCNameInEnglish,
                        vd.DistrictId
                        ));
                }
            }

            return Result<List<GetAllVDCResponse>>.Success(getAllVDCResponses);
        }
    }
}
