using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proviance.Queries.GetAllProviance
{
    public record GetAllProvianceQuery : IRequest<Result<List<GetAllProvianceResponse>>>;
    
}
