using assignment_4.Data;
using assignment_4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace assignment_4.Controllers;

public class BlogController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _db;
    public BlogController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }
   
    [AllowAnonymous]
    public IActionResult Index()
    {
        var blogs = _db.Blogs.ToList();
        return View(blogs);
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult Add(){return View(new Blog());}
    
    [HttpPost]
    [Authorize]
    public IActionResult Add(Blog blog)
    {
        if (!ModelState.IsValid)
            return View(blog);
        _db.Blogs.Add(blog);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }   
    
    [HttpGet]
    [Authorize]
    public IActionResult Edit(int id)
    {
        var blog = _db.Blogs.Find(id);

        if (blog == null)
            return NotFound();

        return View("Edit", blog); 
    }

    [HttpPost]
    [Authorize]
    public IActionResult Edit(int id, Blog blog)
    {
        if (!ModelState.IsValid)
            return View("Edit", blog);

        _db.Blogs.Update(blog);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}