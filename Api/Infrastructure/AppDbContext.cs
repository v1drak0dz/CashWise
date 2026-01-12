using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Accounts> Accounts => Set<Accounts>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Accounts>().HasKey(x => x.Id);
            b.Entity<Accounts>().Property(x => x.Name).IsRequired().HasMaxLength(200);
        }
    }
}
