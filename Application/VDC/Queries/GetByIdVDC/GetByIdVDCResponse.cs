using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VDC.Queries.GetByIdVDC
{
    public record GetByIdVDCResponse(int Id, string vDCNameInNepali, string vDCNameInEnglish, int districtid);
   
}
