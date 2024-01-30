using Application.Inatiallize.Command.Inatilize;
using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inatiallize.Queries.CheckInitillize
{
    public sealed class CheckInitillizeQueryHandler : IRequestHandler<CheckInitillizeQuery, Result<CheckInitillizeResponse>>
    {
        private readonly IinitializeRepository _initializeRepository;

        public CheckInitillizeQueryHandler(IinitializeRepository iinitializeRepository)
        {
            _initializeRepository = iinitializeRepository;

        }
        public async Task<Result<CheckInitillizeResponse>> Handle(CheckInitillizeQuery request, CancellationToken cancellationToken)
        {
            var checkInitiallize = await _initializeRepository.CheckInitillize();
            if (checkInitiallize)
            {
                return Result<CheckInitillizeResponse>.Failure("Not Initiallized");

            }
            else
            {
                return Result<CheckInitillizeResponse>.Success();

            }



        }
    }
}
