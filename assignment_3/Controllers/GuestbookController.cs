using assignment_3.Data;
using assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
namespace assignment_3.Controllers;
public class GuestbookController : Controller
{
    private readonly ApplicationDbContext _db;
    public GuestbookController(ApplicationDbContext db){_db = db;}
    // GET
    public IActionResult Index()
    {
        var guestbooks = _db.Guestbooks.ToList();
        return View(guestbooks);
    }
    
    [HttpGet]
    public IActionResult Add() {return View(new Guestbook());}
    
    [HttpPost]
    public IActionResult Add(Guestbook guestbook)
    {
        if (!ModelState.IsValid)
            return View(guestbook);
        _db.Guestbooks.Add(guestbook);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}