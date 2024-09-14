
using ETİCARETPROJE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace ETİCARETPROJE.Controllers
{
    //Ürünlerle ilgili işlemleri yöneten kontrolcü
    public class ProductController : Controller
    {
        private readonly ECommerceContext _context;

        public ProductController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}