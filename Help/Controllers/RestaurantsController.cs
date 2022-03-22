using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Help.Models;
using System.Collections.Generic;
using System.Linq;

namespace Help.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly HelpContext _db;

    public RestaurantsController(HelpContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Restaurants.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
      ViewBag.CityId = new SelectList(_db.Cities, "CityId", "Name", "State");
      ViewBag.PriceId = new SelectList(_db.Prices, "PriceId", "DollarSigns");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant, int CityId, int CuisineId, int PriceId)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants
          .Include(restaurant => restaurant.JoinEntries)
          .ThenInclude(join => join.City)
          .Include(restaurant => restaurant.JoinEntries)
          .ThenInclude(join => join.Cuisine)
          .Include(restaurant => restaurant.JoinEntries)
          .ThenInclude(join => join.Price)
          .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
      ViewBag.CityId = new SelectList(_db.Cities, "CityId", "Name", "State");
      ViewBag.PriceId = new SelectList(_db.Prices, "PriceId", "DollarSigns");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



///////////////////////////////////////////////////////
    public ActionResult AddCity(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.CityId = new SelectList(_db.Cities, "CityId", "Name", "State");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult AddCity(Restaurant restaurant, int CityId)
    {
      if (CityId != 0)
      {
        _db.CityCuisinePriceRestaurants.Add(new CityCuisinePriceRestaurant() { CityId = CityId, RestaurantId = restaurant.RestaurantId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = restaurant.RestaurantId });
    }

    public ActionResult AddCuisine(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult AddCuisine(Restaurant restaurant, int CuisineId)
    {
      if (CuisineId != 0)
      {
        _db.CityCuisinePriceRestaurants.Add(new CityCuisinePriceRestaurant() { CuisineId = CuisineId, RestaurantId = restaurant.RestaurantId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = restaurant.RestaurantId });
    }

    public ActionResult AddPrice(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.PriceId = new SelectList(_db.Prices, "PriceId", "DollarSigns");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult AddPrice(Restaurant restaurant, int PriceId)
    {
      if (PriceId != 0)
      {
        _db.CityCuisinePriceRestaurants.Add(new CityCuisinePriceRestaurant() { PriceId = PriceId, RestaurantId = restaurant.RestaurantId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = restaurant.RestaurantId });
    }


///////////////////////////////////////////////////////


    public ActionResult Delete(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}