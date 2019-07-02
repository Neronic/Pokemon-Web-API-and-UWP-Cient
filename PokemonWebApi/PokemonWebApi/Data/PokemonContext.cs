using Microsoft.EntityFrameworkCore;
using PokemonWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonWebApi.Data
{
    public class PokemonContext : DbContext
    {

        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options)
        {

        }

        public DbSet<Region> Region { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Pokemon");

            //Unique Constraints

            modelBuilder.Entity<Types>()
                .HasIndex(t => t.TypeName )
                .IsUnique();

            modelBuilder.Entity<Route>()
                .HasIndex(r => r.RouteName)
                .IsUnique();

            modelBuilder.Entity<Region>()
                .HasIndex(g => g.RegionName)
                .IsUnique();

            modelBuilder.Entity<Pokemon>()
                .HasIndex(p => p.Number)
                .IsUnique();

            //Restrictions

            modelBuilder.Entity<Types>()
                .HasMany(p => p.Pokemons)
                .WithOne(t => t.Types)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Route)
                .WithOne(g => g.Region)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Route>()
                .HasMany(p => p.Pokemons)
                .WithOne(r => r.Route)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
