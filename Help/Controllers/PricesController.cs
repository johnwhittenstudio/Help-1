using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Help.Models;
using System.Collections.Generic;
using System.Linq;

namespace Help.Controllers
{
  public class PricesController : Controller
  {
    private readonly HelpContext _db;

    public PricesController(HelpContext db)
    {
      _db = db;
    }

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
    public ActionResult Create(Price price)
    {
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