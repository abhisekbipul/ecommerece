using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppusingDotnetcore.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
          string suser = HttpContext.Session.GetString("myuser");
          TempData["suser"]=suser;
          return View();
        }

        public IActionResult About()
        {
            return View();
        }

        
    }
}
