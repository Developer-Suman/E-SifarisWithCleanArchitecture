using Domain.Abstraction;
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
        private readonly Ivd
        public Task<Result<List<GetAllVDCResponse>>> Handle(GetAllVDCQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
