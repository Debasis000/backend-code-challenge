using CodeChallenge.Api.Models; 
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(500);
                entity.HasIndex(e => e.CreatedAt);  
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
