using System.Collections.Generic;

namespace Help.Models
{
  public class Review
    {
        public Review()
        {
            this.JoinEntries = new HashSet<RestaurantReview>();
        }

        public int ReviewId { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public ICollection<RestaurantReview> JoinEntries { get; }
    }
}