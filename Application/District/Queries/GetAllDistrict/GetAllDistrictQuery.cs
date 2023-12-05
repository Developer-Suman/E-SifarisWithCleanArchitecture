using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.District.Queries.GetAllDistrict
{
    public record GetAllDistrictQuery : IRequest<Result<List<GetAllDistrictResponse>>>;
    
}
