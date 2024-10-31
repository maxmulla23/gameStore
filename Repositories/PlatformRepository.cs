using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Data;
using gameStore.Interface;
using gameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace gameStore.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {

        private readonly gameDbContext _context;
        public PlatformRepository(gameDbContext context)
        {
            _context = context;
        }
        public async Task<Platform> CreatePlatformAsync(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();
            return platform;
        }

        public async Task<List<Platform>> GetAllPlatformsAsync()
        {
            return await _context.Platforms.ToListAsync();
        }
    }
}