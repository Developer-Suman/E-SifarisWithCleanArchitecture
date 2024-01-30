using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Register.RegisteredUser
{
    public sealed class RegisteredCreatedEventConsumer : IConsumer<RegisterCreatedEvent>
    {
        private readonly ILogger<RegisteredCreatedEventConsumer> _logger;

        public RegisteredCreatedEventConsumer(ILogger<RegisteredCreatedEventConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<RegisterCreatedEvent> context)
        {
            _logger.LogInformation("User Created: {@User}", context.Message);
            return Task.CompletedTask;
        }
    }
}
