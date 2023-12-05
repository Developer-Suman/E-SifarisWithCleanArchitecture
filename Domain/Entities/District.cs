using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Premetives;

namespace Domain.Entities
{
    public sealed class District : CustomEntity
    {
        public District(int id, string districtNameNepali, string districtNameEnglish, int provianceId) : base(id)
        {
            DistrictNameEnglish = districtNameEnglish;
            DistrictNameNepali = districtNameNepali;
            ProvianceId = provianceId;


        }

        public string DistrictNameNepali { get; set; }
        public string DistrictNameEnglish { get; set; }
        public int ProvianceId { get; set; }
        public Proviance? Proviance { get; set; }
    }
}
