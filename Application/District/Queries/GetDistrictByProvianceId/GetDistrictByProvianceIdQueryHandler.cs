using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.District.Queries.GetDistrictByProvianceId
{
    public sealed class GetDistrictByProvianceIdQueryHandler : IRequestHandler<GetDistrictByProvianceIdQuery, Result<List<GetDistrictByProvianceIdResponse>>>
    {
        private readonly IDistrictRepository _districtRepository;

        public GetDistrictByProvianceIdQueryHandler(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;    
        }
        public async Task<Result<List<GetDistrictByProvianceIdResponse>>> Handle(GetDistrictByProvianceIdQuery request, CancellationToken cancellationToken)
        {
            var districts = await _districtRepository.GetProvianceId(request.ProvianceId);

            List<GetDistrictByProvianceIdResponse> getDistrictByProvianceIdResponses = new List<GetDistrictByProvianceIdResponse>();

            if(districts is not null && districts.Count > 0)
            {
                foreach(var district in districts )
                {
                    getDistrictByProvianceIdResponses.Add(new GetDistrictByProvianceIdResponse(
                        district.Id,
                        district.DistrictNameNepali,
                        district.DistrictNameEnglish,
                        district.ProvianceId
                        ));

                }

            }

            return Result<List<GetDistrictByProvianceIdResponse>>.Success(getDistrictByProvianceIdResponses);


        }
    }
}
