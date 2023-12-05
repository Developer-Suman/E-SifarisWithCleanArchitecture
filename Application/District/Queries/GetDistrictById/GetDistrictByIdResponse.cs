using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.District.Queries.GetDistrictById
{
    public record GetDistrictByIdResponse(int Id, string DistrictNameNepali, string DistrictNameEnglish, int ProvianceId);
   
}
