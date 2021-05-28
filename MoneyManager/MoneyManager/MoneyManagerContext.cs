using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager
{
    class MoneyManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<User> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MoneyManagerContext()
        {
           if (Database.EnsureCreated())
            {
                //script to add data
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().Property<DateTime>("Date").HasColumnType("datetime2(7)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = WSA-112-21\SQL_EXPRESS; Initial Catalog = MoneyManager; Integrated Security = True;");
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added);

            foreach (var entityEntry in entries)
            {
                entityEntry.Property("Date").CurrentValue = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}