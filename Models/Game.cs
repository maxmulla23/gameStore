using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameStore.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}