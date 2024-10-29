using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Models;

namespace gameStore.Interface
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllGamesAsync();
        Task<Game> AddGameAsync(Game game);
        Task<Game> UpdateGameAsync(Game game);
        Task<Game?> FindGameByIdAsync(int id);
        Task DeletGameSync(Game game);
    }
}