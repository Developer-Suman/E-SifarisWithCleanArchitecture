using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Register.RegisteredUser
{
    public record RegisterCreatedEvent
    {
        public string Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
