using System.Collections.Generic;

namespace Help.Models
{
  public class Restaurant
    {
        public Restaurant()
        {
            this.JoinEntries = new HashSet<CityCuisinePriceRestaurant>();
        }

        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CityCuisinePriceRestaurant> JoinEntries { get; }
    }
}