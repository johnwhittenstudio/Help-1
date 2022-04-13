using System.Collections.Generic;

namespace Help.Models
{
  public class Cuisine
    {
        public Cuisine()
        {
            this.Restaurants = new HashSet<CityCuisinePriceRestaurant>();
        }

        public int CuisineId { get; set; }
        public string Type { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CityCuisinePriceRestaurant> Restaurants { get; set; }
    }
}