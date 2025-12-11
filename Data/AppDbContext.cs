using CodeChallenge.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Message>();

            // entity.HasIndex(e => e.CreatedAt);

            base.OnModelCreating(modelBuilder);
        }
    }
}
