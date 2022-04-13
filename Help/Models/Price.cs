using System.Collections.Generic;

namespace Help.Models
{
  public class Price
    {
        public Price()
        {
            this.Restaurants = new HashSet<CityCuisinePriceRestaurant>();
        }

        public int PriceId { get; set; }
        public string DollarSigns { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CityCuisinePriceRestaurant> Restaurants { get; set; }
    }
}