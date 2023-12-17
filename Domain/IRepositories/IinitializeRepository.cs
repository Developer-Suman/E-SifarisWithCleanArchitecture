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
      
        Task<bool> CheckInitillize();
        //Task<IdentityResult> Initiallize(Branch branch);  
    }
}
