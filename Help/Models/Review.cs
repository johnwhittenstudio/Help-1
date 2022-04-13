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
        public string Headline { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<RestaurantReview> JoinEntries { get; }
    }
}