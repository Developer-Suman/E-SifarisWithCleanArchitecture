using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Refresh_Token
{
    public record RefreshTokenResponse(string token, string refreshToken);
    
   
}
