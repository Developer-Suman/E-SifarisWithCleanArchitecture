using Application.Static.Cache;
using Domain.Abstraction;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Cache;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMemoryCacheRepository _memoryCacheRepository;

        public UserRepository(UserManager<ApplicationUser> userManager, IMemoryCacheRepository memoryCacheRepository)
        {
            _userManager = userManager;
            _memoryCacheRepository = memoryCacheRepository;
            
        }
        public async Task<List<ApplicationUser>?> GetAllUsers()
        {
            var cacheKey = CacheKeys.User;
            var cacheData = await _memoryCacheRepository.GetAsync<List<ApplicationUser>>(cacheKey);
            if(cacheData is not null && cacheData.Count > 0)
            {
                return cacheData;
            }

            var users = await _userManager.Users.ToListAsync();

            await _memoryCacheRepository.SetAsync(cacheKey, users, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
            });

            return users;
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            var cacheKey = $"GetById{id}";
            var cacheData = await _memoryCacheRepository.GetAsync<ApplicationUser>(cacheKey);

            if(cacheData is not null)
            {
                return cacheData;
            }

            var user = await _userManager.FindByIdAsync(id);

            await _memoryCacheRepository.SetAsync<ApplicationUser>(cacheKey, user, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)

            });
            return user;
        }
    }
}
