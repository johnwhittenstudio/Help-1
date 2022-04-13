using Help.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Help.Controllers
{
  [Authorize]
  public class ReviewsController : Controller
  {
    private readonly HelpContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

    public ReviewsController(UserManager<ApplicationUser> userManager, HelpContext db)
    {
      _userManager = userManager;
      _db = db;
    }


    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Reviews.ToList());
      // return View(_db.Reviews.Average(x => (double?)x.Rating) ?? 0);
    }

    public ActionResult Create()
    {
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View();
    }


    [HttpPost]
    public async Task<ActionResult> Create(Review review, int RestaurantId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      review.User = currentUser;
      _db.Reviews.Add(review);
      _db.SaveChanges();
      if (RestaurantId != 0)
      {
        _db.RestaurantReviews.Add(new RestaurantReview() { RestaurantId = RestaurantId, ReviewId = review.ReviewId });
      }
        _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisReview = _db.Reviews
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