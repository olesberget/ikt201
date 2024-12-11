using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using assignment_4.Models;
using assignment_4.Data;
namespace assignment_4.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db; // Initialize the DbContext
    }
    public IActionResult Index()
    {
        var blogs = _db.Blogs.ToList();
        return View(blogs);
    }
    public IActionResult Privacy() { return View(); }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}