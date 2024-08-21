using ECommerceAppusingDotnetcore.Data;
using ECommerceAppusingDotnetcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppusingDotnetcore.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext db;
        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult SignUp()
        {

            return View();
        }
        [AcceptVerbs("Post","Get")]
        public IActionResult CheckExistingEmailId(string email)
        {
            var data=db.user.Where(x=>x.Email==email).SingleOrDefault();
            if (data != null)
            {
                return Json($"Email {email} already in used");
            }
            else
            {
                return Json(true);
            }
        }
        [HttpPost]
        public IActionResult SignUp(User u)
        {
            u.Role = "User";
            db.user.Add(u);
            db.SaveChanges();
            return RedirectToAction("SignIn");
        }
    }
}
