using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proviance.Queries.GetAllProviance
{
    public record GetAllProvianceResponse(int Id, string provinceNameInEnglish, string ProvinceNameInNepali);
    
}
