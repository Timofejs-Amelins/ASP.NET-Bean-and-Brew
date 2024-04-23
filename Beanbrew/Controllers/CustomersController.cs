// import modules necessary to create, read, update and delete customer data
using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

// organise into Controllers namespace and provide CRUD to Customer table
namespace Beanbrew.Controllers
{
    public class CustomersController : Controller
    {
        // declare property name of ApplicatonDbContext obj for CRUD on C#
        private readonly ApplicationDbContext _context;

        // set property var so C# can use ApplicationDbConrext instead of SQL
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers - return Index page with overview of customer data
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // render the coffee order search form for searching for orders
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // show the results of the search based on what user searched
        public async Task<IActionResult> ShowSearchResults(String searchString)
        {
            return View("Index", await _context.Customer.Where(c => c.FirstName!.Contains(searchString)).ToListAsync());
        }

        // GET: Customers/Details/5 - return Details with data about a row
        public async Task<IActionResult> Details(int? id)
        {
            // if the ID of the customer is null return a 404 error to user
            if (id == null)
            {
                return NotFound();
            }

            // otherwise find a customer by ID and store in method variable
            Customer customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);

            // if the customer is null then return a 404 error to the user
            if (customer == null)
            {
                return NotFound();
            }

            // otherwise return Details page with data about one customer
            return View(customer);
        }

        // GET: Customers/Create - get the Customers create page and return it
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create - securely insert customer into database
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,DOB")] Customer customer)
        {
            // validate Customer data before adding customer and redirecting
            if (ModelState.IsValid)
            {
                _ = _context.Add(customer);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // if customer data is invalid return form page with existing data
            return View(customer);
        }

        // GET: Customers/Edit/5 - get the Edit page with data to update
        public async Task<IActionResult> Edit(int? id)
        {
            // if the ID of a customer is null return a 404 error to the user
            if (id == null)
            {
                return NotFound();
            }

            // otherwise find a customer by ID and store in method variable
            Customer customer = await _context.Customer.FindAsync(id);

            // if that customer is null then return a 404 error to the user
            if (customer == null)
            {
                return NotFound();
            }

            // otherwise return the Edit page with the data to update to user
            return View(customer);
        }

        // POST: Customers/Edit/5 - securely update data in Customer database
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,DOB")] Customer customer)
        {
            // if the IDs do not match then return a 404 error to the user
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            // if the updated customer data is valid then update and recirect
            if (ModelState.IsValid)
            {
                try
                // update data before saving the changes ready to leave
                {
                    _ = _context.Update(customer);
                    _ = await _context.SaveChangesAsync();
                }

                // if system tried updating 0/many customers, raise an error
                catch (DbUpdateConcurrencyException)
                {
                    // if no customer can be found by ID then return a 404
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }

                    // otherwise just throw error for updating many rows
                    else
                    {
                        throw;
                    }
                }

                // if everything is fine redirect user to Index page
                return RedirectToAction(nameof(Index));
            }

            // if updated data is invalid then return page with invalid data
            return View(customer);
        }

        // GET: Customers/Delete/5 - get deletion confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            return customer == null ? NotFound() : (IActionResult)View(customer);
        }

        // POST: Customers/Delete/5 - validate token before deleting customer
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Customer customer = await _context.Customer.FindAsync(id);
            _ = _context.Customer.Remove(customer);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // check if a customer exists and if so return that customer
        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}
