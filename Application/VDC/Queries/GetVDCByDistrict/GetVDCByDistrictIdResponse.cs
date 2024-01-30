using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VDC.Queries.GetVDCByDistrict
{
    public record GetVDCByDistrictIdResponse(int id, string vDCNameInNepali, string vDCNameInEnglish, int districtId);
    
}
