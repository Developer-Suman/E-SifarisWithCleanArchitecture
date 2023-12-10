using Application.Static.Cache;
using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VDCRepository : IVDCRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCacheRepository _cacheRepository;

        public VDCRepository(ApplicationDbContext applicationDbContext, IMemoryCacheRepository memoryCacheRepository)
        {
            _context = applicationDbContext;
            _cacheRepository = memoryCacheRepository;
            
        }
        public async Task<List<Vdc>> GetAll()
        {
            var cKey = CacheKeys.VDC;
            var cacheData = await _cacheRepository.GetAsync<List<Vdc>>(cKey);

            if(cacheData is not null)
            {
                return cacheData;
            }

            var vdc = await _context.Vdcs.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }

        public Task<List<Vdc>> GetByDistrictId(int DistrictId)
        {
            throw new NotImplementedException();
        }

        public Task<Vdc> GetById(int VDCId)
        {
            throw new NotImplementedException();
        }
    }
}
