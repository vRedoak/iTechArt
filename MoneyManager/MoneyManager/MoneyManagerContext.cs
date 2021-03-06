using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System;
using System.Linq;

namespace MoneyManager
{
    class MoneyManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MoneyManagerContext()
        {
            if (Database.EnsureCreated())
            {
                using (var transaction = Database.BeginTransaction())
                {
                    try
                    {
                        var xmlReader = new XmlReader();
                        Users.AddRange(xmlReader.Read<User>("users.xml"));
                        SaveChanges();
                        Assets.AddRange(xmlReader.Read<Asset>("assets.xml"));
                        SaveChanges();
                        Categories.AddRange(xmlReader.Read<Category>("categories.xml"));
                        SaveChanges();
                        Transactions.AddRange(xmlReader.Read<Transaction>("transactions.xml"));
                        SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().Property<DateTime>("Date").HasColumnType("datetime2(7)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = WSA-112-21\SQL_EXPRESS; Initial Catalog = MoneyManager; Integrated Security = True; MultipleActiveResultSets=true");
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added);
            foreach (var entityEntry in entries)
            {
                if (entityEntry.CurrentValues.EntityType.ClrType == new Transaction().GetType())
                    entityEntry.Property("Date").CurrentValue = DateTime.Now;
                if (entityEntry.CurrentValues.EntityType.ClrType == new User().GetType())
                {
                    var encryption = new Encryption();
                    entityEntry.Property("Hash").CurrentValue = encryption.Encrypt(entityEntry.Property("Salt").CurrentValue.ToString(), entityEntry.Property("Hash").CurrentValue.ToString());
                }

            }
            return base.SaveChanges();
        }
    }
}