using Bulky.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; 

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Dit is een Action method
        //De naam van de action method bepaalt welke view je gaat teruggeven
        public IActionResult Index()
        {
            //_db = een object van de klasse ApplicationDbContext
            //We gebruiken dit object om een List<Category> te creëren 
            List<Category> objCategoryList = _db.Categories.ToList();

            //De List met Category objecten moeten we vanuit de controller doorgeven aan
            //de view (index). In de view gaan we dan deze list opvangen. 
            return View(objCategoryList); 
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "DisplayOrder cannot exactly match the Name."); 
            }
            if (obj.Name!=null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is not a valid category name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View(); 

            
        }
    }
}
