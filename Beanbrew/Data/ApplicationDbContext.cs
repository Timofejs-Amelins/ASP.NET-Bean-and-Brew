using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beanbrew.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Beanbrew.Models.Coffee> Coffee { get; set; }
        public DbSet<Beanbrew.Models.CoffeeOrder> CoffeeOrder { get; set; }
        public DbSet<Beanbrew.Models.Customer> Customer { get; set; }
        public DbSet<Beanbrew.Models.BakedGoodsOrder> BakedGoodsOrder { get; set; }
        public DbSet<Beanbrew.Models.BakedGood> BakedGood { get; set; }
        public DbSet<Beanbrew.Models.Hamper> Hamper { get; set; }
        public DbSet<Beanbrew.Models.Contact> Contact { get; set; }
        public DbSet<Beanbrew.Models.Restaurant> Restaurant { get; set; }
        public DbSet<Beanbrew.Models.SpaceBooking> SpaceBooking { get; set; }
    }
}
