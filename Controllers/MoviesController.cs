using System.Data.Entity; // Required for using Include
using System.Linq;
using System.Web.Mvc;
using asp.net_vidly.Models;

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
        // Fetch movies from the database and include the Genre information (eager loading)
        var movies = _context.Movies.Include(m => m.Genre).ToList();

        return View(movies);
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
