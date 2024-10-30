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
    public class GameRepository : IGameRepository
    {
        private readonly gameDbContext _context;
        public GameRepository(gameDbContext context)
        {
            _context = context;
        }
        public async Task<Game> AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task DeletGameSync(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task<Game?> FindGameByIdAsync(int id)
        {
           var game = await _context.Games.FindAsync(id);
           return game;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
           return await _context.Games.ToListAsync();
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }
    }
}