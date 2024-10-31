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
    }
}