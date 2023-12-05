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

        private readonly IProvinceRepository provinceRepository;


        //public GetAllQueryHandeler(IProvi)
        //{
            
        //}
        public Task<Result<List<GetAllProvianceResponse>>> Handle(GetAllProvianceQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
