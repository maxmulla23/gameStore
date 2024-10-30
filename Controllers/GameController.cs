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

      [HttpGet]
      public async Task<IActionResult> GetGames()
      {
        var games = await _gameRepo.GetAllGamesAsync();
        return Ok(games);
      }
      [HttpGet("{id}")]
      public async Task<IActionResult> GetGames(int id)
      {
        var game = await _gameRepo.FindGameByIdAsync(id);
        if (game == null)
        {
          return StatusCode(StatusCodes.Status404NotFound, $"game not found");
        }
        return Ok(game);
      }
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteGame(int id)
      {
        try
        {
          var existingGame = await _gameRepo.FindGameByIdAsync(id);
          if(existingGame == null)
          {
            return StatusCode(StatusCodes.Status404NotFound, "The game does not exist");
          }

          await _gameRepo.DeletGameSync(existingGame);
          _fileService.DeleteFile(existingGame.Picture);
          return NoContent();
        }
        catch (Exception ex)
        {
          _logger.LogError(ex.Message);
          return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateGame(int id, [FromForm] UpdateGameDTO gameToUpdate)
      {
        try
        {
          if (id != gameToUpdate.Id)
          {
            return StatusCode(StatusCodes.Status400BadRequest, $"id in url and form body does not match.");
          }

          var existingGame = await _gameRepo.FindGameByIdAsync(id);
          if (existingGame == null)
          {
            return StatusCode(StatusCodes.Status404NotFound, $"Game not found");
          } 
          string oldImage = existingGame.Picture;
            if (gameToUpdate.ImageFile != null)
            {
                if (gameToUpdate.ImageFile?.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
                string createdImageName = await _fileService.SaveFileAsync(gameToUpdate.ImageFile, allowedFileExtentions);
                gameToUpdate.Picture = createdImageName;
            }
            existingGame.Id = gameToUpdate.Id;
            existingGame.Name = gameToUpdate.Name;
            existingGame.Picture = gameToUpdate.Picture;
            existingGame.Description = gameToUpdate.Description;

            var updatedgame = await _gameRepo.UpdateGameAsync(existingGame);

            if (gameToUpdate.ImageFile != null)
                 _fileService.DeleteFile(oldImage);

            return Ok(updatedgame);
        }
        catch (Exception ex)
        {
          _logger.LogError(ex.Message);
          return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
      }
    }
}