using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.DTOs;
using gameStore.Interface;
using gameStore.Models;
using gameStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gameStore.Controllers
{
    [Route("api/platform")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepo;
        private readonly ILogger<PlatformController> _logger;

        public PlatformController(IPlatformRepository platformRepo, ILogger<PlatformController> logger)
        {
            _platformRepo = platformRepo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform([FromForm] PlatformDTO toCreatePlatform)
        {
            try
            {
                var platform = new Platform
                {
                    Name = toCreatePlatform.Name
                };
                var createdPlatform = await _platformRepo.CreatePlatformAsync(platform);
                return CreatedAtAction(nameof(CreatePlatform), createdPlatform );

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatform()
        {
            try
            {
                var platforms = await _platformRepo.GetAllPlatformsAsync();
                return Ok(platforms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode (StatusCodes.Status500InternalServerError, ex.Message);
                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatform(int id)
        {
        var platform = await _platformRepo.GetPlatformById(id);
        if (platform == null)
        {
          return StatusCode(StatusCodes.Status404NotFound, $"platform not found");
        }
        return Ok(platform);
        }

        [HttpPut]
        public async Task<IActionResult> EditPlatform(int id, [FromForm] PlatformDTO editplatform)
        {
            try
            {
            //    if (id != editplatform.Id)
            //    {
            //     return StatusCode(StatusCodes.Status400BadRequest, $"id in url and form body do not match");
            //    } 
               var existingPlatform = await _platformRepo.GetPlatformById(id);
               if (existingPlatform == null)
               {
                return StatusCode(StatusCodes.Status404NotFound, $"Platform not found");
               }
               existingPlatform.Name = editplatform.Name;

               var updatedPlatform = await _platformRepo.EditPlatformAsync(existingPlatform);

               return Ok(updatedPlatform);
            }
            catch (Exception ex)
            {
                
               _logger.LogError(ex.Message);
               return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            try
            {
                var existingPlatform = await _platformRepo.GetPlatformById(id);
          if(existingPlatform == null)
          {
            return StatusCode(StatusCodes.Status404NotFound, "The game does not exist");
          }

          await _platformRepo.DeletePlatformAsync(existingPlatform);
          
          return NoContent();
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}