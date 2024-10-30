using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.DTOs;
using gameStore.Interface;
using gameStore.Models;
using gameStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace gameStore.Controllers
{
     [ApiController] 
     [Route("api/games")]
    public class GameController : ControllerBase
    {
      private readonly IFileService _fileService;
      private readonly IGameRepository _gameRepo;
      private readonly ILogger<GameController> _logger;

      public GameController(IFileService fileService, IGameRepository gameRepo, ILogger<GameController> logger)
      {
        _fileService = fileService;
        _gameRepo = gameRepo;
        _logger = logger;
      }

      [HttpPost]
      public async Task <IActionResult> PostGame([FromForm] GameDTO gameToAdd)
      {
        try
        {
            if (gameToAdd.ImageFile?.Length > 1 * 1024 * 1024)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
            }
            string[] allowedFileExtensions = [".jpg", ".jpeg", ".png"];
            string createdImageName = await _fileService.SaveFileAsync(gameToAdd.ImageFile, allowedFileExtensions);

            var game = new Game
            {
              Name = gameToAdd.Name,
              Picture = createdImageName,
              Description = gameToAdd.Description
            };
            var createdGame = await _gameRepo.AddGameAsync(game);
            return CreatedAtAction(nameof(PostGame), createdGame);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
      }
    }
}