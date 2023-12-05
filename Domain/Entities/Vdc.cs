using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Premetives;

namespace Domain.Entities
{
    public sealed class Vdc : CustomEntity
    {
        public Vdc(int id, string vDCNameInNepali, string vDCNameInEnglish, int districtId) : base(id)
        {
            VDCNameInNepali = vDCNameInNepali;
            VDCNameInEnglish = vDCNameInEnglish;
            DistrictId = districtId;


        }

        public string VDCNameInNepali { get; set; }
        public string VDCNameInEnglish { get; set; }
        public int DistrictId { get; set; }
        public District? District { get; set; }
    }
}
