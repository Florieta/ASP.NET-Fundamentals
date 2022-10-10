using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Data.Models;
using WebShop.Core.Data.Models.Account;

namespace WebShop.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           

            var decimalProps = modelBuilder.Model
   .GetEntityTypes()
   .SelectMany(t => t.GetProperties())
   .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        
    }
}