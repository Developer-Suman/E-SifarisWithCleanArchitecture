using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Queries.CheckInitillize
{
    public record CheckInitillizeQuery : IRequest<Result<CheckInitillizeResponse>>;
    
}
