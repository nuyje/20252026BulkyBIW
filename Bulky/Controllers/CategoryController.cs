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
    }
}
