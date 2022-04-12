namespace Help.Models
{
  public class CityCuisinePriceRestaurant
  {
    public int CityCuisinePriceRestaurantId { get; set; }
    public int? CityId { get; set; }
    public virtual City City { get; set; }
    public int? CuisineId { get; set; }
    public virtual Cuisine Cuisine { get; set; }
    public int? PriceId { get; set; }
    public virtual Price Price { get; set; }
    public int RestaurantId { get; set; }
    public virtual Restaurant Restaurant { get; set; }
  }
}