using Application.Static.Cache;
using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic;
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

            await _cacheRepository.SetAsync(cKey, vdc, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(30)
            }) ;

            return vdc;
        }

        public async Task<List<Vdc>> GetByDistrictId(int DistrictId)
        {
            var cKey = $"GetByDistrictId{DistrictId}";
            var cacheData = await _cacheRepository.GetAsync<List<Vdc>>(cKey);
            
            if(cacheData is not null)
            {
                return cacheData;
            }

            var vdcs = await _context.Vdcs.AsNoTracking().Where(x=>x.DistrictId == DistrictId).OrderBy(x=>x.Id).ToListAsync();

            await _cacheRepository.SetAsync(cKey, vdcs, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration= DateTime.Now.AddMinutes(30)
            });

            return vdcs;
        }

        public async Task<Vdc> GetById(int VDCId)
        {
            var cKey = $"GetById{VDCId}";
            var cacheData = await _cacheRepository.GetAsync<Vdc>(cKey);
            if(cacheData is not null)
            {
                return cacheData;
            }

            var vdc = await _context.Vdcs.SingleOrDefaultAsync(x=>x.Id == VDCId);
            if(vdc is null)
            {
                return default!;

            }

            await _cacheRepository.SetAsync(cKey, vdc, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(30)
            });

            return vdc;
        }
    }
}
