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
  public class PricesController : Controller
  {
    private readonly HelpContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

    public PricesController(UserManager<ApplicationUser> userManager, HelpContext db)
    {
      _userManager = userManager;
      _db = db;
    }


    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Price> model = _db.Prices.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }


    [HttpPost]
    public async Task<ActionResult> Create(Price price)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      price.User = currentUser;
      _db.Prices.Add(price);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Price thisPrice = _db.Prices.FirstOrDefault(price => price.PriceId == id);
      return View(thisPrice);
    }
    public ActionResult Edit(int id)
    {
      var thisPrice = _db.Prices.FirstOrDefault(price => price.PriceId == id);
      return View(thisPrice);
    }

    [HttpPost]
    public ActionResult Edit(Price price)
    {
      _db.Entry(price).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPrice = _db.Prices.FirstOrDefault(price => price.PriceId == id);
      return View(thisPrice);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPrice = _db.Prices.FirstOrDefault(price => price.PriceId == id);
      _db.Prices.Remove(thisPrice);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}