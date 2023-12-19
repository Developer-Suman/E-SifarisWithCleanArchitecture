using Domain.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IinitializeRepository
    {
      

        Task<Result<CheckInitillizeResponse>> CheckInitillize();
        //Task<string> Initialize(Branch branch);  
    }
}
