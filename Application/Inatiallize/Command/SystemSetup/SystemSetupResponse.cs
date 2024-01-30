using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Command.SystemSetup
{
    public record SystemSetupResponse(
        string districtName,
        string provianceName,
        string vdcName,
        string municipalityName,
        bool daratachalaniMode
        );
    
}
