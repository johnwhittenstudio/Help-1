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
  public class CitiesController : Controller
  {
    private readonly HelpContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

    public CitiesController(UserManager<ApplicationUser> userManager, HelpContext db)
    {
      _userManager = userManager;
      _db = db;
    }


    [AllowAnonymous]
    public ActionResult Index()
    {
      List<City> model = _db.Cities.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }


    [HttpPost]
    public async Task<ActionResult> Create(City city)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      city.User = currentUser;
      _db.Cities.Add(city);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


    public ActionResult Details(int id)
    {
      City thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
      return View(thisCity);
    }
    
    public ActionResult Edit(int id)
    {
      var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
      return View(thisCity);
    }

    [HttpPost]
    public ActionResult Edit(City city)
    {
      _db.Entry(city).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
      return View(thisCity);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
      _db.Cities.Remove(thisCity);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}