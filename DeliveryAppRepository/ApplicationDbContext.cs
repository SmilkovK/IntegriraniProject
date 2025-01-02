using DeliveryAppDomain.Domain;
using DeliveryAppDomain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DeliveryAppRepository
{
    public class ApplicationDbContext : IdentityDbContext<DeliveryUser>
    {
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<FoodsInOrder> FoodsInOrders { get; set; }
        public virtual DbSet<RestaurantFoods> RestaurantFoods { get; set; }
        public virtual DbSet<FoodsInCart> FoodsInCarts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
    }
}
