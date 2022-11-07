using Eazii_Foods.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eazii_Foods.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<CommonDropdown> CommonDropdowns { get; set; }
        public DbSet<UserVerificaktion> UserVerificaktions { get; set; }
        public DbSet<PlaceOrder> PlaceOrders { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Chefs> Chefs { get; set; }
    }
}
