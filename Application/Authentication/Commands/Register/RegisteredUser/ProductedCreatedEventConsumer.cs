using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Register.RegisteredUser
{
    public sealed class ProductedCreatedEventConsumer : IConsumer<RegisterCreatedEvent>
    {
        private readonly ILogger<ProductedCreatedEventConsumer> _logger;

        public ProductedCreatedEventConsumer(ILogger<ProductedCreatedEventConsumer> logger)
        {
            _logger = logger;
            
        }
        public Task Consume(ConsumeContext<RegisterCreatedEvent> context)
        {
            _logger.LogInformation("Product created: {@Product}", context.Message);
            return Task.CompletedTask;
        }
    }
}
