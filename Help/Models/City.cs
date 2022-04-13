using System.Collections.Generic;

namespace Help.Models
{
  public class City
    {
        public City()
        {
            this.Restaurants = new HashSet<CityCuisinePriceRestaurant>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CityCuisinePriceRestaurant> Restaurants { get; set; }
    }
}