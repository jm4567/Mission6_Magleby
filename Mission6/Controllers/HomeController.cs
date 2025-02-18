using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View("MovieForm");
    }

    //return the movie form and make sure it resets
    [HttpPost]
    public IActionResult MovieForm(Movies response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return RedirectToAction("MovieForm");

    }
    
    public IActionResult JoelsMovies()
    {
        var joelsMovies = _context.Movies
            .Include(x => x.Category).ToList()
            .OrderBy(x => x.Title).ToList();

        return View(joelsMovies);
    }  
    
}