using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        return View("MovieForm", new Movie());
    }

    //return a confirmation after movie is submitted with validity
    
    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        if (ModelState.IsValid) //Validation
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            Console.WriteLine($"Database Path: {Path.GetFullPath("./JoelHiltonMovieCollection.sqlite")}");
            return View("Confirmation", response); 
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(response); 
        }
        
    }
    
    public IActionResult JoelsMovies()
    {
        var joelsMovies = _context.Movies
            .Include(x => x.Category) //include category table
            .OrderBy(x => x.Title).ToList();

        return View(joelsMovies); 
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();
        return View("MovieForm", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo) 
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("JoelsMovies");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie deletedInfo)
    {
        _context.Movies.Remove(deletedInfo);
        _context.SaveChanges();
        return RedirectToAction("JoelsMovies");
    }
}