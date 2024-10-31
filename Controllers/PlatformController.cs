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
    }
}