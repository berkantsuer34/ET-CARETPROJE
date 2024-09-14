using ETİCARETPROJE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ETİCARETPROJE.Controllers
{
    //kredi kart kontolü için
    public class CartController : Controller
    {
        private readonly ECommerceContext _context;

        public CartController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult AddToCart(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return NotFound();
            }

            // Sepet işlemleri burada yapılır
            return RedirectToAction("Index", "Product");
        }
    }
}
