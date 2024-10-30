using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gameStore.Data
{
    public class gameDbContext : IdentityDbContext<AppUser>
    {
        public gameDbContext(DbContextOptions<gameDbContext> options) : base(options){ }
        public DbSet<Game> Games{ get; set; }
        public DbSet<Category> Categories { get; set;}
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GamePlatform>(x => x.HasKey(g => new { g.GameId, g.PlatformId}));

            builder.Entity<GamePlatform>()
            .HasOne(u => u.Game)
            .WithMany(u => u.GamePlatforms)
            .HasForeignKey(g => g.GameId);

            // builder.Entity<Game>()
            //  .HasMany(e => e.Platforms)
            //  .WithMany(u => u.Games);


            builder.Entity<Game>()
             .HasMany(e => e.Categories)
             .WithMany(e => e.Games);
        }
    }
}