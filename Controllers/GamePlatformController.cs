using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Data;
using gameStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace gameStore.Controllers
{
    [Route("api/gameplatform")]
    [ApiController]
    public class GamePlatformController
    {
        private readonly IGamePlatformRepository _gamePlatformRepo;
        private readonly IGameRepository _gameRepository;
        private readonly IPlatformRepository _platformRepo;
        private readonly gameDbContext _context;
        public GamePlatformController(IGamePlatformRepository gamePlatform, gameDbContext context, IPlatformRepository platformRepo, IGameRepository gameRepository)
        {
            _gamePlatformRepo = gamePlatform;
            _context = context; 
            _gameRepository = gameRepository;
            _platformRepo = platformRepo;  
        }

        [HttpPost]
        public async Task<IActionResult> AddGamePlatform()
        {

        }

    }
}