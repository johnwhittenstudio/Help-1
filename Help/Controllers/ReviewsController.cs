using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Help.Models;
using System.Collections.Generic;
using System.Linq;

namespace Help.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly HelpContext _db;

    public ReviewsController(HelpContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Reviews.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Review review, int RestaurantId)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
      if (RestaurantId != 0)
      {
        _db.RestaurantReviews.Add(new RestaurantReview() { RestaurantId = RestaurantId, ReviewId = review.ReviewId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Review thisReview = _db.Reviews
          .Include(review => review.JoinEntries)
          .ThenInclude(join => join.Restaurant)
          .FirstOrDefault(review => review.ReviewId == id);
      return View(thisReview);
    }

    public ActionResult Edit(int id)
    {
      var thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisReview);
    }

    [HttpPost]
    public ActionResult Edit(Review review, int RestaurantId)
    {
      if (RestaurantId != 0)
      {
        _db.RestaurantReviews.Add(new RestaurantReview() { RestaurantId = RestaurantId, ReviewId = review.ReviewId });
      }
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddRestaurant(int id)
    {
      var thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisReview);
    }

    [HttpPost]
    public ActionResult AddRestaurant(Review review, int RestaurantId)
    {
      if (RestaurantId != 0)
      {
        _db.RestaurantReviews.Add(new RestaurantReview() { RestaurantId = RestaurantId, ReviewId = review.ReviewId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
      List<RestaurantReview> joins = _db.RestaurantReviews.Where(join => join.ReviewId == id).ToList();
      foreach (RestaurantReview join in joins) 
      {
        _db.RestaurantReviews.Remove(join);
      }
      _db.Reviews.Remove(thisReview);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteReview(int joinId)
    {
      var joinEntry = _db.RestaurantReviews.FirstOrDefault(entry => entry.RestaurantReviewId == joinId);
      _db.RestaurantReviews.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}