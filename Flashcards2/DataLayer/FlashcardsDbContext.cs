using System;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Flashcards2.DataLayer
{
    public class FlashcardsDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<Query> Queries { get; set; }

        public FlashcardsDbContext(DbContextOptions<FlashcardsDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            var Entries = ChangeTracker.Entries()
                .Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified));

            var now = DateTime.Now;

            foreach (var entry in Entries)
            {
                ((BaseEntity)entry.Entity).SetUpdatedAt(now);

                if (entry.State == EntityState.Added)
                    ((BaseEntity)entry.Entity).SetCreatedAt(now);
            }
            return base.SaveChanges();
        }
    }
}
