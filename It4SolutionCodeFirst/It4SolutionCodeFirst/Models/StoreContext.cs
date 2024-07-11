using System.Data.Entity;

namespace It4SolutionCodeFirst.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Roles> Role { get; set; }

        public DbSet<User> users { get; set; }

    }
}