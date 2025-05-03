using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Data;
using gameStore.Interface;
using gameStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace gameStore.Controllers
{
    [Route("api/gameplatform")]
    [ApiController]
    public class GamePlatformController : ControllerBase
    {
        private readonly IGamePlatformRepository _gamePlatformRepo;
        private readonly IGameRepository _gameRepository;
        private readonly IPlatformRepository _platformRepo;
        private readonly GameDbContext _context;
        public GamePlatformController(IGamePlatformRepository gamePlatform, GameDbContext context, IPlatformRepository platformRepo, IGameRepository gameRepository)
        {
            _gamePlatformRepo = gamePlatform;
            _context = context; 
            _gameRepository = gameRepository;
            _platformRepo = platformRepo;  
        }

        [HttpPost]
        public async Task<IActionResult> AddGamePlatform(int id)
        {
            try
            {
            var game = await _gameRepository.FindGameByIdAsync(id);
            var platform = await _platformRepo.GetPlatformById(id);

           
            if (game == null) return BadRequest("game not Found");
            if (platform == null) return BadRequest("Platform not Found");

            var gamePlatform = new GamePlatform
            {
                GameId = game.Id,
                PlatformId = platform.Id
            };
            await _gamePlatformRepo.CreateAsync(gamePlatform);
            if (gamePlatform == null)
            {
                return StatusCode(500, "Could not add");
            } else {
                return Created();
            }
            
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }

    }
}