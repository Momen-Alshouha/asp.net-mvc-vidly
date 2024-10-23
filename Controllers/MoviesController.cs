using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using asp.net_vidly.Models;
using asp.net_vidly.ViewModels;

public class MoviesController : Controller
{
    private ApplicationDbContext _context;

    public MoviesController()
    {
        _context = new ApplicationDbContext();
    }

    // GET: Movies
    public ActionResult Index()
    {
        return View();
    }

    // GET: Movies/Details/{id}
    public ActionResult Details(int id)
    {
        var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.MovieId == id);

        if (movie == null)
            return HttpNotFound();

        return View(movie);
    }


    [Authorize(Roles = "Admin")]
    [Route("Movie/Create")]
    [HttpGet]
    public ActionResult Create()
    {
        var genres = _context.Genres.ToList();
        var viewModel = new MovieFormViewModel
        {
            Genres = genres
        };

        return View("Create", viewModel);
    }

    [Authorize(Roles = "Admin")]
    [Route("Movie/Create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("Create", viewModel);
        }

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return RedirectToAction("Index", "Movies");
    }

    [Authorize(Roles = "Admin")]
    [Route("Movie/Edit/{id}")]
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);

        if (movie == null)
            return HttpNotFound();

        var genres = _context.Genres.ToList();

        var viewModel = new MovieFormViewModel
        {
            Movie = movie,
            Genres = genres
        };

        return View("Edit", viewModel);
    }

    [Authorize(Roles = "Admin")]
    [Route("Movie/Edit/{id}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("Edit", viewModel);
        }

        var movieInDb = _context.Movies.SingleOrDefault(m => m.MovieId == movie.MovieId);

        if (movieInDb == null)
            return HttpNotFound();

        movieInDb.Title = movie.Title;
        movieInDb.ReleaseDate = movie.ReleaseDate;
        movieInDb.Director = movie.Director;
        movieInDb.Rating = movie.Rating;
        movieInDb.GenreId = movie.GenreId;

        _context.SaveChanges();

        return RedirectToAction("Index", "Movies");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ActionResult Delete(int id)
    {
        var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);

        if (movie == null)
            return HttpNotFound();

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("Index", "Movies");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }

        base.Dispose(disposing);
    }
}
