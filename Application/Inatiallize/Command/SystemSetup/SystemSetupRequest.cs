using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Command.SystemSetup
{
    public class SystemSetupRequest()
    {
        public int? districtId { get; set; }
        public int? provinceId { get; set; }
        public int? municipalityId { get; set; }
        public int? vdcId { get; set; }
        public int? localgovermentType { get; set; }
        public int? totalwardnumber { get; set; }
        public bool? dartachalanimode { get; set; }
        public bool? chalaninumberforpreviousyear { get; set; }
        public bool? isactive { get; set; }
        public string? logo { get; set; }
        public string? blockdatefrom { get;set; }
        public string? blockdateto { get; set; }
    }
    
}
