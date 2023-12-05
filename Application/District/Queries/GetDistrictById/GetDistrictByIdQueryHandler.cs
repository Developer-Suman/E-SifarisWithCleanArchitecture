using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.District.Queries.GetDistrictById
{
    public sealed class GetDistrictByIdQueryHandler : IRequestHandler<GetDistrictByIdQuery, Result<GetDistrictByIdResponse>>
    {
        private readonly IDistrictRepository _districtrepository;

        public GetDistrictByIdQueryHandler(IDistrictRepository districtRepository)
        {
            _districtrepository = districtRepository;
        }
        public async Task<Result<GetDistrictByIdResponse>> Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
        {
            var districts = await _districtrepository.GetById(request.Id);

            if(districts is null)
            {
                return Result<GetDistrictByIdResponse>.Failure("Not Found");
            }

            GetDistrictByIdResponse getDistrictByIdResponse = new(
                districts.Id,
                districts.DistrictNameNepali,
                districts.DistrictNameEnglish,
                districts.ProvianceId
                );

            return Result<GetDistrictByIdResponse>.Success( getDistrictByIdResponse );
        }
    }
}
