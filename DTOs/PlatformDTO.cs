using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gameStore.DTOs
{
    public class PlatformDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}