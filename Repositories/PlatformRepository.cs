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

        private readonly GameDbContext _context;
        public PlatformRepository(GameDbContext context)
        {
            _context = context;
        }
        public async Task<Platform> CreatePlatformAsync(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();
            return platform;
        }

        public async Task<Platform?> GetPlatformById(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            return platform; 
        }

        public async Task<List<Platform>> GetAllPlatformsAsync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<Platform> EditPlatformAsync(Platform platform)
        {
            _context.Platforms.Update(platform);
            await _context.SaveChangesAsync();
            return platform;
        }

        public async Task DeletePlatformAsync(Platform platform)
        {
            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();
        }
    }
}