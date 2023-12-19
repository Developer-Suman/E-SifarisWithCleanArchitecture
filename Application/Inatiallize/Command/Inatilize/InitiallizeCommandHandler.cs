using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Command.Inatilize
{
    public sealed class InitiallizeCommandHandler : IRequestHandler<InitializeCommand, Result<InitializeResponse>>
    {

        private readonly IinitializeRepository _initializeRepository;

        public InitiallizeCommandHandler(IinitializeRepository iinitializeRepository)
        {
            _initializeRepository = iinitializeRepository;
            
        }
        public async Task<Result<InitializeResponse>> Handle(InitializeCommand request, CancellationToken cancellationToken)
        {
            var checkInitiallize = await _initializeRepository.CheckInitillize();
            if(checkInitiallize)
            {
                var result = await _initializeRepository.Initialize(request.municipalityId, request.officeHead);
                if()
            }
            return Result<InitializeResponse>.Failure(nameof(InitializeResponse));
        }
    }
}
