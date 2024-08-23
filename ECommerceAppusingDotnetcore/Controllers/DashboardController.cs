using ECommerceAppusingDotnetcore.Data;
using ECommerceAppusingDotnetcore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppusingDotnetcore.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext db;
        private IWebHostEnvironment env;

        public DashboardController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index(string choice)
        {
          if(choice=="LTH")
            {
                var data = db.myproducts.OrderBy(X => X.Price).ToList();
                return View(data);
            }
          else
            {
                var data=db.myproducts.ToList();
                return View(data);
            }
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(ProductViewModel pm)
        {
            var path = env.WebRootPath;
            var filePath= "Content/Images/" + pm.Picture.FileName;
            var fullPath = Path.Combine(path, filePath);
            UploadFile(pm.Picture, fullPath);
            var obj = new Product()
            {
                Pname = pm.Pname,
                Pcat = pm.Pcat,
                Price = pm.Price,
                Picture = filePath
            };
            db.myproducts.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        public IActionResult LTH()
        {
            var data = db.myproducts.OrderBy(x => x.Picture).ToList();
            return View(data);
        }

        public IActionResult AddToCart(int id)
        {
            string sess = HttpContext.Session.GetString("myuser");
            var prod = db.myproducts.Find(id);
            var obj = new Cart()
            {
                Pname = prod.Pname,
                Pcat = prod.Pcat,
                Picture = prod.Picture,
                Price = prod.Price,
                Suser = sess
            };
            db.Mycart.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
