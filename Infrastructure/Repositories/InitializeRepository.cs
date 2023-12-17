using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InitializeRepository : IinitializeRepository
    {
        private readonly ApplicationDbContext _context;

        public InitializeRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }


        public async Task<bool> CheckInitillize()
        {
            return await _context.Set<District>().AnyAsync();
        }

        //public Task<IdentityResult> Initiallize(Branch branch)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
