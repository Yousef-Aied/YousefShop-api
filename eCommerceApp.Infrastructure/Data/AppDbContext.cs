using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Achieve> CheckoutAchieves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PaymentMethod>()
                .HasData(
                new PaymentMethod
                {
                    //Id = Guid.NewGuid(),
                    Id = Guid.Parse("e3e8881c-d2f3-41e4-b0f9-111111111111"),
                    Name = "Cerdit Card",
                });

            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                //Id = Guid.NewGuid().ToString(),
                Id = "e3e8881c-d2f3-41e4-b0f9-222222222222",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                //Id = Guid.NewGuid().ToString(),
                Id = "e3e8881c-d2f3-41e4-b0f9-333333333333",
                Name = "User",
                NormalizedName = "USER"
            });
        }
    }
}