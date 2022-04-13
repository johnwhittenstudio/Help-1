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
  public class CuisinesController : Controller
  {
    private readonly HelpContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

    public CuisinesController(UserManager<ApplicationUser> userManager, HelpContext db)
    {
      _userManager = userManager;
      _db = db;
    }


    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.OrderBy(x => x.Type).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }


    [HttpPost]
    public async Task<ActionResult> Create(Cuisine cuisine)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      cuisine.User = currentUser;
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }


    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      _db.Entry(cuisine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}