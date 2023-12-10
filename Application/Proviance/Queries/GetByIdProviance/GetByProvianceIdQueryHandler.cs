using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proviance.Queries.GetByIdProviance
{
    public sealed class GetByProvianceIdQueryHandler : IRequestHandler<GetProvianceByIdQuery, Result<GetByIdProvianceResponse>>
    {
        private readonly IProvinceRepository _provinceRepository;

        public GetByProvianceIdQueryHandler(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
            
        }
        public async Task<Result<GetByIdProvianceResponse>> Handle(GetProvianceByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _provinceRepository.GetById(request.Id);

            if(query is null)
            {
                return Result<GetByIdProvianceResponse>.Failure("Not Found");
            }

            GetByIdProvianceResponse response = new(
                query.Id,
                query.ProvinceNameInNepali,
                query.ProvinceNameInEnglish
                );

            return Result<GetByIdProvianceResponse>.Success( response );
        }
    }
}
