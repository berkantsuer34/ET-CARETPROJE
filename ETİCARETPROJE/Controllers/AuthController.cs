using ETİCARETPROJE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AuthController : Controller
{
    private readonly ECommerceContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(ECommerceContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        if (user != null && _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success)
        {
            HttpContext.Session.SetString("UserEmail", user.Email);
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(string firstName, string lastName, string email, string password)
    {
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PasswordHash = _passwordHasher.HashPassword(null, password)
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        HttpContext.Session.SetString("UserEmail", user.Email);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserEmail");
        return RedirectToAction("Index", "Home");
    }
}
