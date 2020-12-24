using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Storing {
    public class PizzaWorldContext : DbContext {
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer("Server=michaelpizzaworlddb.database.windows.net;Initial Catalog=PizzaWorldDb;User ID=sqladmin;Password=[REDACTED];");
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Store>().HasKey(s => s.EntityId);
            builder.Entity<User>().HasKey(u => u.EntityId);
            builder.Entity<Order>().HasKey(o => o.EntityId);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityId);

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder) {
            builder.Entity<Store>().HasData(new List<Store>
                {
                    new Store() { EntityId = 2, Name = "Dominoes" },
                    new Store() { EntityId = 3, Name = "Pizza Hut" }
                }
            );
        }
    }
}