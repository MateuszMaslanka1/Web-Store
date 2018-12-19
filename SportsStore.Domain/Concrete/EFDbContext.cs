using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Infoes> Infoes { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}