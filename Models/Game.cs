using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameStore.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Picture { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Category> Categories { get; set; } = [];
        public List<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
    }
}