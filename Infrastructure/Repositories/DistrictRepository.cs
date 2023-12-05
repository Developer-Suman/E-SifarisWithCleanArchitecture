
using Application.Static.Cache;
using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCacheRepository _memoryCacheRepository;


        public DistrictRepository(IMemoryCacheRepository memoryCacheRepository, ApplicationDbContext applicationDbContext)
        {
            _memoryCacheRepository = memoryCacheRepository;
            _context = applicationDbContext;
            
        }
        public async Task<List<District>> GetAll()
        {
            var cKey = CacheKeys.District;
            var cacheData = await _memoryCacheRepository.GetAsync<List<District>>(cKey);

            if(cacheData is not null )
            {
                return cacheData;
            }

            var districts = await _context.Districts.ToListAsync();

            await _memoryCacheRepository.SetAsync(cKey, districts, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)

            });

            return districts;
        }

        public async Task<District> GetById(int districtId)
        {
            string ckey = $"GetById{districtId}";
            var cacheData = await _memoryCacheRepository.GetAsync<District>(ckey);
            if( cacheData is not null )
            {
                return cacheData;
            }

            var district = await _context.Districts.SingleOrDefaultAsync(x=>x.Id == districtId);

            if(district is null)
            {
                return default!;
            }

            await _memoryCacheRepository.SetAsync(ckey, district, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            });

            return district;

        }

        public async Task<List<District>> GetProvianceId(int ProvianceId)
        {
            string cKey = $"GetProvianceId{ProvianceId}";

            var cacheData = await _memoryCacheRepository.GetAsync<List<District>>(cKey);

            if(cacheData is not null)
            {
                return cacheData;
            }

            var districts = await _context.Districts.Where(x=>x.ProvianceId == ProvianceId).ToListAsync();

            await _memoryCacheRepository.SetAsync(cKey, districts, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            });

            return districts;
        }
    }
}
