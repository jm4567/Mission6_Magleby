using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using SQLitePCL;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;

    public HomeController(MovieCollectionContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult GettoKnowJoel()
    {
        return View("GettoKnowJoel");
    }
    [HttpGet]
    public IActionResult MovieForm()
    {
        return View("MovieForm");
    }

    //return the movie form and make sure it resets
    public IActionResult MovieForm(Movies response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return RedirectToAction("MovieForm");

    }
    
}