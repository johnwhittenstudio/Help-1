using Microsoft.AspNetCore.Mvc;

namespace Help.Controllers
{
    public class OwnersController : Controller
    {

      [HttpGet("Owners/Index")]
      public ActionResult Index()
      {
        return View();
      }

    }
}