using asp.net_vidly.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace asp.net_vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        // GET /api/customers/{id}
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customer);
        }

        // PUT /api/customers/{id}
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customerInDb == null)
                return NotFound();

            customerInDb.Name = customer.Name;
            customerInDb.Email = customer.Email;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.PhoneNumber = customer.PhoneNumber;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();

            return Ok(customerInDb);
        }

        // DELETE /api/customers/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
