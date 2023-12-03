using Domain.Abstraction;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries.GetAllUsers
{
    public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUserResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public async Task<Result<List<GetAllUserResponse>>> Handle(GetAllUsersQuery request,CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers();
            List<GetAllUserResponse> getAllUserResponses = new List<GetAllUserResponse>();
            if(users is not null && users.Count > 0)
            {
                foreach (var user in users)
                {
                    getAllUserResponses.Add(new GetAllUserResponse(
                        user.Id,
                        user.UserName!,
                        user.Email!,
                        user.PhoneNumber!
                        ));
                }
            }

            return Result<List<GetAllUserResponse>>.Success(getAllUserResponses);
        }
    }
        
    
}
