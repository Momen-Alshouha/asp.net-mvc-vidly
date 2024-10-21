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

    [Route("Movie/Edit/{id}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Movie movie)
    {
        /// <summary>
        /// Handles form validation for the Edit Movie form.
        /// If the form data is invalid, the form is redisplayed with the entered data and validation messages.
        /// </summary>
        /// <param name="movie">The movie object containing the form data submitted by the user.</param>
        /// <returns>
        /// If the form data is valid, the action proceeds to save the movie.
        /// If the form data is invalid, the Edit form is redisplayed with the user's entered data and error messages.
        /// </returns>
        if (!ModelState.IsValid)
        {
            // Create a new instance of MovieFormViewModel
            // The Movie object is set to the form data so that the user's input is retained
            // The Genres list is reloaded from the database to populate the dropdown again
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            // Return the Edit view, passing the viewModel to repopulate the form with the user's input and validation messages
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

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }

        base.Dispose(disposing);
    }
}
