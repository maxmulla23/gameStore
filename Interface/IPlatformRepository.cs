using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Models;

namespace gameStore.Interface
{
    public interface IPlatformRepository
    {
        Task <Platform> CreatePlatformAsync(Platform platform);
        Task<List<Platform>> GetAllPlatformsAsync();
        Task <Platform?> GetPlatformById(int id);
        Task <Platform> EditPlatformAsync(Platform platform);
        Task DeletePlatformAsync(Platform platform);
    }
}