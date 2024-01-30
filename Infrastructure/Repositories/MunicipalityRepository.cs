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
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCacheRepository _cacheRepository;

        public MunicipalityRepository(ApplicationDbContext applicationDbContext, IMemoryCacheRepository memoryCacheRepository)
        {
            _context = applicationDbContext;
            _cacheRepository = memoryCacheRepository;
            
        }
        public async Task<List<Municipality>> GetAll()
        {
            var cKey = CacheKeys.Municipality;

            var cacheData = await _cacheRepository.GetAsync<List<Municipality>>(cKey);
            if(cacheData is not null )
            {
                return cacheData;
            }

            var municipality = await _context.municipalities.ToListAsync();
            if(municipality is null)
            {
                return default!;
            }

            await _cacheRepository.SetAsync(cKey, municipality, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            });

            return municipality;
        }

        public async Task<List<Municipality>> GetByDistrictId(int districtId)
        {
            var cKey = $"GetByDistrictId{districtId}";

            var cacheData = await _cacheRepository.GetAsync<List<Municipality>>(cKey);
            if(cacheData is not null )
            {
                return cacheData;
            }

            var municipality = await _context.municipalities.Where(x=>x.DistrictId ==  districtId).ToListAsync();
            await _cacheRepository.SetAsync(cKey, municipality, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            }) ;

            return municipality;
            
        }

        public async Task<Municipality> GetById(int municipalityId)
        {
            var cKey = $"GetById{municipalityId}";

            var cacheData = await _cacheRepository.GetAsync<Municipality>(cKey);
            if(cacheData is not null)
            {
                return cacheData;
            }

            var municipality = await _context.municipalities.SingleOrDefaultAsync(x=>x.Id == municipalityId);
            if(municipality is null)
            {
                return default!;
            }

            await _cacheRepository.SetAsync(cKey, municipality, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            }) ;
            return municipality;
        }
    }
}
