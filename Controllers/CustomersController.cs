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
            return View();
        }

        // GET: Customers/Create
        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        // GET: Customers/Edit/{id}
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("customers/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("Edit", viewModel);
        }

        // POST: Customers/Edit/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [Route("customers/edit/{id}")]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("Edit", viewModel);
            }

            var customerInDb = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);

            if (customerInDb == null)
                return HttpNotFound();

            customerInDb.Name = customer.Name;
            customerInDb.Email = customer.Email;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.PhoneNumber = customer.PhoneNumber;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers/Details/id
        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).Single(c => c.CustomerId == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // POST: Customers/Delete/{id}
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customerInDb == null)
                return HttpNotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Dispose the DbContext when the controller is destroyed
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
