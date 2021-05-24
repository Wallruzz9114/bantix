using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Agent> Agents { get; set; }
<<<<<<< HEAD
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
=======

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }
>>>>>>> added-agent
    }
}