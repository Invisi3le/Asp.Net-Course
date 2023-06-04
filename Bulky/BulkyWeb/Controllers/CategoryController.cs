using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Category.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost] 
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot be the same as the Category Name");
            }
            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Invalid name of Category");
            //}
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Edit(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Category.Find(id); // Find() is a method that finds the primary key
           // Category? categoryFromDb1 = _db.Category.FirstOrDefault(u => u.Id == id); // FirstOrDefault() is a method that finds the first record that matches the condition
           //Category? categoryFromDb2 = _db.Category.Where(u => u.Id == id).FirstOrDefault(); // Where() is a method that finds all records that matches the condition

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // POST - EDIT
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot be the same as the Category Name");
            }
            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Invalid name of Category");
            //}
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
