using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Help.Models
{
  public class HelpContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<City> Cities { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<CityCuisinePriceRestaurant> CityCuisinePriceRestaurants { get; set; }

    public DbSet<RestaurantReview> RestaurantReviews { get; set; }

    public HelpContext(DbContextOptions options) : base(options) { }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
