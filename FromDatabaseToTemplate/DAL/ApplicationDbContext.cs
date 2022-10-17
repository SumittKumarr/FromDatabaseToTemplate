using FromDatabaseToTemplate.Entities;
using Microsoft.EntityFrameworkCore;

namespace FromDatabaseToTemplate.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(p => p.PolicyExpiryDate).HasColumnType("date");
        }

        public DbSet<Template> Templates { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
