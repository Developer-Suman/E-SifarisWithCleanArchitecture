using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.District.Queries.GetDistrictById
{
    public record GetDistrictByIdQuery(int Id) : IRequest<Result<GetDistrictByIdResponse>>;
    
}
