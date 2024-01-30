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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCacheRepository _memoryCacheRepository;

        public ProvinceRepository(ApplicationDbContext applicationDbContext, IMemoryCacheRepository memoryCacheRepository)
        {
            _context = applicationDbContext;
            _memoryCacheRepository = memoryCacheRepository;
            
        }
        public async Task<List<Proviance>> GetAll()
        {
            var cKey = CacheKeys.Province;

            var cacheData = await _memoryCacheRepository.GetAsync<List<Proviance>>(cKey);
            if(cacheData is not null)
            {
                return cacheData;
            }

            var proviance = await _context.Proviances.ToListAsync();

            await _memoryCacheRepository.SetAsync(cKey, proviance, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            });

            return proviance;
        }

        public async Task<Proviance> GetById(int provianceId)
        {
            var cKey = $"GetById{provianceId}";

            var cacheData = await _memoryCacheRepository.GetAsync<Proviance>(cKey);
            if(cacheData is not null)
            {
                return cacheData;
            }
            var proviance = await _context.Proviances.SingleOrDefaultAsync(x=>x.Id == provianceId);
            if(proviance is null)
            {
                return default!;

            }

            await _memoryCacheRepository.SetAsync(cKey, proviance, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            });

            return proviance;
        }
    }
}
