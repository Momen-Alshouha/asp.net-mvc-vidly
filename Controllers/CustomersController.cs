using System.Linq;
using System.Web.Mvc;
using asp.net_vidly.Models;
using System.Data.Entity;
using asp.net_vidly.ViewModels;

namespace asp.net_vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        [Route("customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        // GET: Customers/Create
        [HttpGet]
        [Route("customers/create")]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        // POST: Customers/Create
        [HttpPost]
        [Route("customers/create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Details", "Customers", new { id = customer.CustomerId });
        }


        // GET: Customers/Details/id
        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // Dispose the DbContext when the controller is destroyed
        // To avoid memory leaks, the Dispose method is overridden to properly dispose of the _context instance when the controller is no longer needed.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
