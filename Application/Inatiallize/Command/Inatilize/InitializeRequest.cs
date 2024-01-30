using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Command.Inatilize
{
    public class InitializeRequest
    {
        public string? BranchNameInNepali { get; set; }
        public string? BranchNameInEnglish { get; set; }
        public int? provianceId { get; set; }
        public int? districtId { get; set; }
        public string? localGovernment { get; set; }
        public string? addressInEnglish { get; set; }
        public string ? addressInNepali { get; set; }
        public string? branchContactInEnglish {  get; set; }
        public string? branchContactInNepali { get; set; }
        public string? officeHead { get; set; }
        public string? basicInformation { get; set; }
        public string? logoURL { get; set; }
        public string? headerInEnglish { get; set; }
        public string? headerInNepali { get; set; }
        public string? footerInEnglish { get; set; }
        public string? footerInNepali { get; set; }
        public string? watermarkURL { get; set; }
        public int? branchTypeId { get; set; }
        public int? wardId { get; set;}
        public int? departmentId { get; set; }
        public int? municipalityId { get; set; }
        public int? vDCId { get; set; }
        public bool? isActive { get; set; }
    }
    
}
