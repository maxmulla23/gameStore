using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gameStore.DTOs
{
    public class GameDTO
    {
        [Required]
        public string Name { get; set;} = string.Empty;
        [Required]
        public string Description { get; set;} = string.Empty;
        
        [Required]
        public IFormFile? ImageFile { get; set;}
    }

    public class UpdateGameDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? Picture { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}