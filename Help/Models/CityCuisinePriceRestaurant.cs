namespace Help.Models
{
  public class CityCuisinePriceRestaurant
  {
    public int CityCuisinePriceRestaurantId { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }
    public int? PriceId { get; set; }
    public Price Price { get; set; }
    public int? RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
  }
}