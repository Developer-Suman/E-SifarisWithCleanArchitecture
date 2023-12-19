using Application.Inatiallize.Command.Inatilize;
using Application.Inatiallize.Queries.CheckInitillize;
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
        

        public InitializeRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;

            
        }


        public async Task<Result<CheckInitillizeResponse>> CheckInitillize()
        {
            var result =  await _context.Set<Branch>().AnyAsync();
            if(result)
            {
                return Result<CheckInitillizeResponse>.Failure("System has been already Initialized");

            }
            else
            {
                return Result<CheckInitillizeResponse>.Success();
            }
        }

        //public async Task<string> Initialize(InitializeResponse branch)
        //{
        //    using (var dbContext = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            Branch branchs = new Branch(
        //                branchNameInNepali: branch.BranchNameInNepali,
        //                branchNameInEnglish: branch.BranchNameInEnglish,
        //                provianceId: branch.provianceId,
        //                districtId: branch.districtId,
        //                localGovernment: branch.localGovernment,
        //                addressInEnglish: branch.addressInEnglish,
        //                addressInNepali: branch.addressInNepali,
        //                branchContactInEnglish: branch.branchContactInEnglish,
        //                branchContactInNepali: branch.branchContactInNepali,
        //                officeHead: branch.officeHead,
        //                basicInformation: branch.basicInformation,
        //                logoURL: branch.logoURL,
        //                headerInEnglish: branch.headerInEnglish,
        //                headerInNepali: branch.headerInNepali,
        //                footerInEnglish: branch.footerInEnglish,
        //                footerInNepali: branch.footerInNepali,
        //                watermarkURL: branch.watermarkURL,
        //                branchTypeId: branch.branchTypeId,
        //                wardId: branch.wardId,
        //                departmentId: branch.departmentId,
        //                municipalityId: branch.municipalityId,
        //                vDCId: branch.vDCId,
        //                isActive: branch.isActive
        //            );

        //           await _context.AddAsync( branch );
        //           await _unitOfWork.SaveChangesAsync();



        //            dbContext.Commit();
        //            dbContext.Dispose();
        //            return "Successfully Add Branch";
        //        }
        //        // Add exception handling as needed
        //        catch (Exception ex)
        //        {
        //            dbContext.Rollback();
        //            dbContext.Dispose( );
        //            return ex.Message;
        //        }
        //    }
        //}

    }
}
