using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proviance.Queries.GetAllProviance
{
    public sealed class GetAllQueryHandeler : IRequestHandler<GetAllProvianceQuery, Result<List<GetAllProvianceResponse>>>
    {

        private readonly IProvinceRepository _provinceRepository;


        public GetAllQueryHandeler(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;

        }
        public async Task<Result<List<GetAllProvianceResponse>>> Handle(GetAllProvianceQuery request, CancellationToken cancellationToken)
        {
            var query = await _provinceRepository.GetAll();

            List<GetAllProvianceResponse> getAllProvianceResponses = new List<GetAllProvianceResponse>();
            if(query is not null &&  query.Count > 0)
            {
                foreach(var response in query)
                {
                    getAllProvianceResponses.Add(new GetAllProvianceResponse(
                        response.Id,
                        response.ProvinceNameInNepali,
                        response.ProvinceNameInEnglish
                        ));

                }
            }

            return Result<List<GetAllProvianceResponse>>.Success(getAllProvianceResponses);
        }
    }
}
