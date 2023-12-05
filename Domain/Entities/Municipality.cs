using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Premetives;

namespace Domain.Entities
{
    public sealed class Municipality : CustomEntity
    {
        public Municipality(int id, string municipalityNameInNepali, string municipalityNameInEnglish, int districtId)
            : base(id)
        {
            MunicipalityNameInEnglish = municipalityNameInEnglish;
            MunicipalityNameInNepali = municipalityNameInNepali;
            DistrictId = districtId;


        }

        public string MunicipalityNameInNepali { get; set; }
        public string MunicipalityNameInEnglish { get; set; }
        public int DistrictId { get; set; }
        public District? District { get; set; }
    }
}
