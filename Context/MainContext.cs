using Microsoft.EntityFrameworkCore;
using OOP.Contracts;

namespace OOP.Context
{
    public class MainContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<User> users { get; set; } = null!;

        public MainContext(string connectionString)
        {
            _connectionString = connectionString;
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.
             //   UseNpgsql(_connectionString);
        }
    }
}
