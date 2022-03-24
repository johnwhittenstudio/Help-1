namespace Help.Models
{
  public class RestaurantReview
  {
    public int RestaurantReviewId { get; set; }
    public int RestaurantId { get; set; }
    public int ReviewId { get; set; }
    public virtual Restaurant Restaurant { get; set; }
    public virtual Review Review { get; set; }
  }
}