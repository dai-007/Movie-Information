using Microsoft.AspNetCore.Mvc;
using MovieInfo.Data;
using MovieInfo.Models;

namespace MovieInfo.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _db;
        public MovieController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Movie> movieList = _db.Movies.ToList();
            return View(movieList);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
                TempData["success"] = "Movie created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Movie? movieFromDb = _db.Movies.Find(id);
            
            if (movieFromDb == null)
                return NotFound();

            return View(movieFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            
            if (ModelState.IsValid)
            {
                _db.Movies.Update(movie);
                _db.SaveChanges();
                TempData["success"] = "Movie updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Movie? movieFromDb = _db.Movies.Find(id);

            if (movieFromDb == null)
                return NotFound();

            return View(movieFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteRecord(int? id)
        {
            Movie? movie = _db.Movies.Find(id);
            if (movie == null)
                return NotFound();

            _db.Movies.Remove(movie);
            _db.SaveChanges();
            TempData["success"] = "Movie deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
