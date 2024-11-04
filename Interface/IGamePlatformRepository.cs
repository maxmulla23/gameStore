using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Models;

namespace gameStore.Interface
{
    public interface IGamePlatformRepository
    {
        Task <GamePlatform> CreateAsync(GamePlatform gamePlatform);
    }
}