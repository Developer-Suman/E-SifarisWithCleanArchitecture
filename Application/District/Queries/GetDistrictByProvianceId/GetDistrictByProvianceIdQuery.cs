using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.District.Queries.GetDistrictByProvianceId
{
    public record GetDistrictByProvianceIdQuery(int ProvianceId) : IRequest<Result<List<GetDistrictByProvianceIdResponse>>>;
    
}
