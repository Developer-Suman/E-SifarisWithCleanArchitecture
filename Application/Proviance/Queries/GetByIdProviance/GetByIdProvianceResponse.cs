using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proviance.Queries.GetByIdProviance
{
    public record GetByIdProvianceResponse(int Id, string ProvinceNameInNepali, string ProvinceNameInEnglish);
    
}
