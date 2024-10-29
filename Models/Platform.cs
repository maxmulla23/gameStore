using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameStore.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
    }
}