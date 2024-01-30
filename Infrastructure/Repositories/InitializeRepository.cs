using Application.Inatiallize.Command.Inatilize;
using Application.Inatiallize.Queries.CheckInitillize;
using Application.Static.Roles;
using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public InitializeRepository(ApplicationDbContext context, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _unitOfWork = unitOfWork;

            
        }

        public async Task<string> Initialize(Branch branch)
        {
            using (var dbContext = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await _context.Branches.AddAsync(branch);
                    await _unitOfWork.SaveChangesAsync();

                    ApplicationUser user = new()
                    {
                        UserName = "superadmin",
                        Email = "superadmin@gmail.com",
                        
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };

                    var results = await _userManager.CreateAsync(user, "Admin@123");
                    //if (!results.Succeeded)
                    //{
                    //    return Result<InitializeResponse>.Failure("User Creation Failed, Please try again ");
                    //}

                    if (!await _roleManager.RoleExistsAsync(Role.Superadmin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Role.Superadmin));
                    }

                    if (!await _roleManager.RoleExistsAsync(Role.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Role.User));
                    }


                    dbContext.Commit();
                    return "Success";
                }
                catch (Exception ex)
                {
                    dbContext.Rollback();
                    return null;
                }
            }
        }




        public async Task<Result<CheckInitillizeResponse>> CheckInitillize()
        {
            var result = await _context.Set<Branch>().AnyAsync();
            if (result)
            {
                return Result<CheckInitillizeResponse>.Failure("System has been already Initialized");

            }
            else
            {
                return Result<CheckInitillizeResponse>.Success();
            }
        }

        Task<bool> IinitializeRepository.CheckInitillize()
        {
            throw new NotImplementedException();
        }
    }


}
