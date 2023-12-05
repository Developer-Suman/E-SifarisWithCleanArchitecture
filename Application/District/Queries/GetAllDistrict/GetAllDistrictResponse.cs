using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.District.Queries.GetAllDistrict
{
    public record GetAllDistrictResponse(int Id, string DistrictNameNepali, string DistrictNameEnglish, int ProvianceId);
   
}
