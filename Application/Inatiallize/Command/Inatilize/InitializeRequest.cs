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
        public string? provianceId { get; set; }
        public string? districtId { get; set; }
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
        public string? branchTypeId { get; set; }
        public string? wardId { get; set;}
        public string? departmentId { get; set; }
        public string? municipalityId { get; set; }
        public string? vDCId { get; set; }
        public string? isActive { get; set; }
    }
    
}
