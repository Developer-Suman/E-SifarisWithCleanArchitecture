using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proviance.Queries.GetByIdProviance
{
    public record class GetProvianceByIdQuery(int Id) : IRequest<Result<GetByIdProvianceResponse>>;
    
}
