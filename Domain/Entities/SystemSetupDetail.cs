using Domain.Premetives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class SystemSetupDetail : Entity
    {
        public SystemSetupDetail(
            Guid id,
            int? districtId,
            int? provinceId,
            int? vdcId,
            int? municipalityId,
            int? localgovermentType,
            int? totalWardNumber,
            bool? dartaChalaniMode,
            bool chalaniNumberForPreviousYear,
            bool isActive,
            string logo,
            string blockDateFrom,
            string blockDateTo
            ) : base(id)
        {
            DistrictId = districtId;
            ProvinceId = provinceId;
            VdcId = vdcId;
            MunicipalityId = municipalityId;
            LocalgovermentType = localgovermentType;
            TotalWardNumber = totalWardNumber;
            DartaChalaniMode = dartaChalaniMode;
            ChalaniNumberForPreviousYear = chalaniNumberForPreviousYear;
            IsActive = isActive;
            Logo = logo;
            BlockDateFrom = blockDateFrom;
            BlockDateTo = blockDateTo;   
        }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public int? ProvinceId { get; set; }
        public Proviance Proviance { get; set; }

        public int? VdcId { get; set; }
        public Vdc Vdc { get; set; }
        public int? MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }
        public int? LocalgovermentType { get; set; }
        public int? TotalWardNumber { get; set; }
        public bool? DartaChalaniMode { get; set; }
        public bool? ChalaniNumberForPreviousYear { get; set; }
        public bool? IsActive { get; set; }
        public string? Logo { get; set; }
        public string? BlockDateFrom { get; set; }
        public string? BlockDateTo { get; set;}
    }
  
}
