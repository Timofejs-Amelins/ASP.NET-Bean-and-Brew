using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// this Controller is part of Controllers and provides CRUD to CoffeeOrder
namespace Beanbrew.Controllers
{
    public class CoffeeOrdersController : Controller
    {
        // declare ApplicationDbcontext property for CRUD functionality on C#
        private readonly ApplicationDbContext _context;

        // this sets the context to ApplicationDbContext object for C# CRUD
        public CoffeeOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoffeeOrders - return coffee orders overview with data
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<CoffeeOrder, Customer> applicationDbContext = _context.CoffeeOrder.Include(c => c.Coffees).Include(c => c.Customers);
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: CoffeeOrders/Details/5 - return coffee order details page
        public async Task<IActionResult> Details(int? id)
        {
            // raise a 404 if the ID of coffee order is null
            if (id == null)
            {
                return NotFound();
            }

            // create coffee order and bind the keys to the coffee order
            CoffeeOrder coffeeOrder = await _context.CoffeeOrder
                .Include(c => c.Coffees)
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(m => m.CoffeeOrderId == id);

            // raise a 404 if the coffee order is not null
            if (coffeeOrder == null)
            {
                return NotFound();
            }

            // if nothing is null return the coffee order with its data
            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Create - get foreign keys and return page
        public IActionResult Create()
        {
            ViewData["CoffeeId"] = new SelectList(_context.Coffee, "CoffeeId", "CoffeeId");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return View();
        }

        // POST: CoffeeOrders/Create - securely submit order into new row
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoffeeOrderId,CoffeeId,CustomerId,Quantity,Price")] CoffeeOrder coffeeOrder)
        {
            // validate order before adding it and redirecting to Index
            if (ModelState.IsValid)
            {
                _ = _context.Add(coffeeOrder);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // otherwise get the foreign keys again and return page
            ViewData["CoffeeId"] = new SelectList(_context.Coffee, "CoffeeId", "CoffeeId", coffeeOrder.CoffeeId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", coffeeOrder.CustomerId);
            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Edit/5 - validate order and get order form page
        public async Task<IActionResult> Edit(int? id)
        {
            // raise 404 if the ID is null
            if (id == null)
            {
                return NotFound();
            }

            // otherwise find coffee order by coffee order ID
            CoffeeOrder coffeeOrder = await _context.CoffeeOrder.FindAsync(id);

            // if coffee order is null raise a 404
            if (coffeeOrder == null)
            {
                return NotFound();
            }

            // get the foreign keys and then return the coffee order edit page
            ViewData["CoffeeId"] = new SelectList(_context.Coffee, "CoffeeId", "CoffeeId", coffeeOrder.CoffeeId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", coffeeOrder.CustomerId);
            return View(coffeeOrder);
        }

        // POST: CoffeeOrders/Edit/5 - securely update a coffee order row
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoffeeOrderId,CoffeeId,CustomerId,Quantity,Price")] CoffeeOrder coffeeOrder)
        {
            // if coffee order IDs do not match raise a 404
            if (id != coffeeOrder.CoffeeOrderId)
            {
                return NotFound();
            }

            // if coffee order is valid update order and redirect to Index
            if (ModelState.IsValid)
            {
                try
                {   // try updating coffee order
                    _ = _context.Update(coffeeOrder);
                    _ = await _context.SaveChangesAsync();
                }

                // if system tries updating 0 or many orders raise an error
                catch (DbUpdateConcurrencyException)
                {
                    // if the coffee order cannot be found raise a 404
                    if (!CoffeeOrderExists(coffeeOrder.CoffeeOrderId))
                    {
                        return NotFound();
                    }
                    // othwrwise throw the DbUpdateConcurrencyException
                    else
                    {
                        throw;
                    }
                }
                // redirect user to Index page if everything goes well
                return RedirectToAction(nameof(Index));
            }

            // if coffee order is invalid re-get foreign keys and return page
            ViewData["CoffeeId"] = new SelectList(_context.Coffee, "CoffeeId", "CoffeeId", coffeeOrder.CoffeeId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", coffeeOrder.CustomerId);
            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Delete/5 - get info before returning delete page
        public async Task<IActionResult> Delete(int? id)
        {
            // if ID  is null raise a 404
            if (id == null)
            {
                return NotFound();
            }

            // bundle the primary and foreign keys into the coffee order
            CoffeeOrder coffeeOrder = await _context.CoffeeOrder
                .Include(c => c.Coffees)
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(m => m.CoffeeOrderId == id);

            // raise a 404 of the coffee order is null
            if (coffeeOrder == null)
            {
                return NotFound();
            }

            // finally return the coffee order deletion confirmation page
            return View(coffeeOrder);
        }

        // POST: CoffeeOrders/Delete/5 - delete order before redirection 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // find coffee order before removing and redirecting to Index page
            CoffeeOrder coffeeOrder = await _context.CoffeeOrder.FindAsync(id);
            _ = _context.CoffeeOrder.Remove(coffeeOrder);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // check if a coffee order exists, if so return True, otherwise False
        private bool CoffeeOrderExists(int id)
        {
            return _context.CoffeeOrder.Any(e => e.CoffeeOrderId == id);
        }
    }
}
