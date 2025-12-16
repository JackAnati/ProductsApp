using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Listing all products in a database
        public IActionResult Index()
        {
            var productList = _context.Products.ToList();
            return View(productList);
        }
        
        //The function is for allowing for the creation of an html view
        public IActionResult Create()
        {
            return View();
        }

        //The function is for creating a product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Product product) 
        {

            if (ModelState.IsValid) 
            {
                product.CreatedDate = DateTime.UtcNow; // Defaulting the time to be now.

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(product);
        
        }
        //The function is for allowing for the creation of an html view for updating a product
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(e => e.ProductId == id);
            if (product == null) 
            {
                return NotFound();
                    
            }
            return View(product);
        }
        //The function is for updating a product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Models.Product product)
        {
            if(id != product.ProductId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.UtcNow;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(product);

        }
        // After a user has confirmed the deletion of a product the following function will be triggered based on the productId
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
