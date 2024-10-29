using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameStore.Models
{
    public class GamePlatform
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
    }
}