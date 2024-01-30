using Domain.Premetives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities;

    public sealed class Branch : Entity
    {
        public Branch(Guid id,
           string? branchNameInNepali,
           string? branchNameInEnglish,
           int? provinceId,
           int? districtId,
           string? localGovernment,
           string? addressInEnglish,
           string? addressInNepali,
           string? branchContactInEnglish,
           string? branchContactInNepali,
           string? officeHead,
           string? basicInformation,
           string? logoURL,
           string? headerInEnglish,
           string? headerInNepali,
           string? footerInEnglish,
           string? footerInNepali,
           string? watermarkURL,
           int? branchTypeId,
           int? wardId,
           int? departmentId,
           int? municipalityId,
           int? vDCId,
           bool? isActive
           ) : base(id)
        {
            BranchNameInNepali = branchNameInNepali;
            BranchNameInEnglish = branchNameInEnglish;
            ProvinceId = provinceId;
            DistrictId = districtId;
            LocalGovernment = localGovernment;
            AddressInEnglish = addressInEnglish;
            AddressInNepali = addressInNepali;
            BranchContactInEnglish = branchContactInEnglish;
            BranchContactInNepali = branchContactInNepali;
            OfficeHead = officeHead;
            BasicInformation = basicInformation;
            LogoURL = logoURL;
            HeaderInEnglish = headerInEnglish;
            HeaderInNepali = headerInNepali;
            FooterInEnglish = footerInEnglish;
            FooterInNepali = footerInNepali;
            WatermarkURL = watermarkURL;
            BranchTypeId = branchTypeId;
            WardId = wardId;
            DepartmentId = departmentId;
            MunicipalityId = municipalityId;
            VDCId = vDCId;
            IsActive = isActive;
        }

        public string? BranchNameInNepali { get; set; }
        public string? BranchNameInEnglish { get; set; }
        public int? ProvinceId { get; set; }
        public Proviance? Province { get; set; }
        public int? DistrictId { get; set; }
        public District? District { get; set; }
        public string? LocalGovernment { get; set; }
        public string? AddressInEnglish { get; set; }
        public string? AddressInNepali { get; set; }
        public string? BranchContactInEnglish { get; set; }
        public string? BranchContactInNepali { get; set; }
        public string? OfficeHead { get; set; }
        public string? BasicInformation { get; set; }
        public string? LogoURL { get; set; }
        public string? HeaderInEnglish { get; set; }
        public string? HeaderInNepali { get; set; }
        public string? FooterInEnglish { get; set; }
        public string? FooterInNepali { get; set; }
        public string? WatermarkURL { get; set; }
        public int? BranchTypeId { get; set; }
        public BranchType? BranchType { get; set; }
        public int? WardId { get; set; }
        public Ward? Ward { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? MunicipalityId { get; set; }
        public Municipality? Municipality { get; set; }
        public int? VDCId { get; set; }
        public Vdc? Vdc { get; set; }
        public bool? IsActive { get; set; }
    }

