using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VDC.Queries.GetByIdVDC
{
    public record GetVDCByIdQuery(int VDCId) : IRequest<Result<GetByIdVDCResponse>>;
    
}
