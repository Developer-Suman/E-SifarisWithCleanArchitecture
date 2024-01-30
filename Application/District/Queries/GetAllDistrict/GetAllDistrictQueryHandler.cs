using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.District.Queries.GetAllDistrict
{
    public sealed class GetAllDistrictQueryHandler : IRequestHandler<GetAllDistrictQuery, Result<List<GetAllDistrictResponse>>>
    {
        private readonly IDistrictRepository _districtRepository;
        public GetAllDistrictQueryHandler(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
            
        }
        public async Task<Result<List<GetAllDistrictResponse>>> Handle(GetAllDistrictQuery request, CancellationToken cancellationToken)
        {
            var districts = await _districtRepository.GetAll();

            List<GetAllDistrictResponse> getAllDistrictResponse = new List<GetAllDistrictResponse>();
            if(districts is not null && districts.Count > 0)
            {
                foreach(var district in districts)
                {
                    getAllDistrictResponse.Add(new GetAllDistrictResponse(
                        district.Id,
                        district.DistrictNameNepali,
                        district.DistrictNameEnglish,
                        district.ProvianceId
                        ));

                }
            }

            return Result<List<GetAllDistrictResponse>>.Success(getAllDistrictResponse);
        }
    }
}
