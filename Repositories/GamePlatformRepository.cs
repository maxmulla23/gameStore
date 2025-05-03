using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Data;
using gameStore.Interface;
using gameStore.Models;

namespace gameStore.Repositories
{
    public class GamePlatformRepository : IGamePlatformRepository
    {
        private readonly GameDbContext _context;
        public GamePlatformRepository(GameDbContext context)
        {
            _context = context;
        }
        public async Task<GamePlatform> CreateAsync(GamePlatform gamePlatform)
        {
            await _context.GamePlatforms.AddAsync(gamePlatform);
            await _context.SaveChangesAsync();
            return gamePlatform;
        }
    }
}