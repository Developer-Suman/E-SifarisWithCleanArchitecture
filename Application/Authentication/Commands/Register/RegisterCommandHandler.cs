using Application.Abstraction.EventBus;
using Application.Authentication.Commands.Register.RegisteredUser;
using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<string>>
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IEventBus _eventBus;
        public RegisterCommandHandler(IAuthenticationRepository authenticationRepository, IEventBus eventBus) 
        {
            _authenticationRepository = authenticationRepository;
            _eventBus = eventBus;

        }

        public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _authenticationRepository.FindByNameAsync(request.username);
            if(userExists is not null)
            {
                return Result<string>.Failure("User already exists.");
            }

            var userEmailExists = await _authenticationRepository.FindByEmailAsync(request.email);
            if(userEmailExists is not null)
            {
                return Result<string>.Failure("Email already exists.");
            }

            ApplicationUser user = new()
            {
                UserName = request.username,
                Email = request.email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _authenticationRepository.CreateUserAsync(user, request.password);

            await _eventBus.PublishAsync(
                new RegisterCreatedEvent
            {
                Id = user.Id,
                Name = request.username,
            }, cancellationToken);
            if(!result.Succeeded)
            {
                return Result<string>.Failure("User Creation Failed.");
            }

            return Result<string>.Success();
        }

    }
  
}
