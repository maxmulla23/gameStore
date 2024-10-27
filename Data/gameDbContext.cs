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

            // builder.Entity<Game>(x => x.HasKey(p => new { p.AppUserId, p.StockId}));

            builder.Entity<Game>()
             .HasMany(e => e.Platforms)
             .WithMany(u => u.Games);


            builder.Entity<Game>()
             .HasMany(e => e.Categories)
             .WithMany(e => e.Games);

        }
    }
}