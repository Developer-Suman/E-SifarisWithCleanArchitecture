using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VDC.Queries.GetAllVDC
{
    public record GetAllVDCResponse(int Id, string VDCNameInEnglish, string VDCNameInNepali, int districtId);
   
}
