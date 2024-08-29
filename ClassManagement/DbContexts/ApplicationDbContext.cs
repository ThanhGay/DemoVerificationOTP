using DemoVerificationOTP.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoVerificationOTP.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions options): base (options) { }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
