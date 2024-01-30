using Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Refresh_Token
{
    public record RefreshTokenCommand(string token, string refreshToken) : IRequest<Result<RefreshTokenResponse>>;
  
}
