using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


// Coffee controller provides CRUD and is organised into Controllers namespace
namespace Beanbrew.Controllers
{
    public class CoffeesController : Controller
    {
        // declare ApplicationDbContext property to do crud on C# without SQL
        private readonly ApplicationDbContext _context;

        // set the ApplicationDbContext obj as a coffee order contr property
        public CoffeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coffees - return Index with an overview of coffee data
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coffee.ToListAsync());
        }

        // GET: Coffees/Details/5 - return Details with order data
        public async Task<IActionResult> Details(int? id)
        {
            // raise a 404 if the coffee ID is null
            if (id == null)
            {
                return NotFound();
            }

            // get the coffee order by coffee order ID and store in variable
            Coffee coffee = await _context.Coffee
                .FirstOrDefaultAsync(m => m.CoffeeId == id);

            // if the coffee is null return a 404 error
            if (coffee == null)
            {
                return NotFound();
            }

            // return the Details page with coffee data if everything is ok
            return View(coffee);
        }

        // GET: Coffees/Create - return the Coffee Create page to the user
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coffees/Create - securely insert data into Coffee table
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoffeeId,CoffeeName,UnitPrice")] Coffee coffee)
        {
            // if coffee is valid add the coffee, and redirect user to Index
            if (ModelState.IsValid)
            {
                _ = _context.Add(coffee);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // otherwise return the Coffee create page to the user
            return View(coffee);
        }

        // GET: Coffees/Edit/5 - get coffee and return edit form to user
        public async Task<IActionResult> Edit(int? id)
        {
            // if the ID is null raise a 404
            if (id == null)
            {
                return NotFound();
            }

            // otherwise find coffee by ID and store in variable
            Coffee coffee = await _context.Coffee.FindAsync(id);

            // raise a 404 error if the coffee object found is null
            if (coffee == null)
            {
                return NotFound();
            }

            // otherwise return view page with the user editing coffee
            return View(coffee);
        }

        // POST: Coffees/Edit/5 - securely update coffee data to entered data
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoffeeId,CoffeeName,UnitPrice")] Coffee coffee)
        {
            // if the coffee IDs do not match raise a 404
            if (id != coffee.CoffeeId)
            {
                return NotFound();
            }

            // if the coffee is valid update coffee and redirect to Index
            if (ModelState.IsValid)
            {
                // try updating coffee and saving changes
                try
                {
                    _ = _context.Update(coffee);
                    _ = await _context.SaveChangesAsync();
                }

                // throw wrror of 0 or multiple coffees are found
                catch (DbUpdateConcurrencyException)
                {
                    // if a coffee is not found raise a 404 error on the page 
                    if (!CoffeeExists(coffee.CoffeeId))
                    {
                        return NotFound();
                    }
                    // otherwise throw the exception for multiple updated rows
                    else
                    {
                        throw;
                    }
                }

                // if everything is fine then redirect user to Index page
                return RedirectToAction(nameof(Index));
            }

            // if the updated coffee data is invalid return the edit page 
            return View(coffee);
        }

        // GET: Coffees/Delete/5 - get the coffee deletion conformation page
        public async Task<IActionResult> Delete(int? id)
        {
            // raise a 404 to the user if the coffee cannot be found by ID
            if (id == null)
            {
                return NotFound();
            }

            // otherwise put a Coffee object based on that ID on a variable
            Coffee coffee = await _context.Coffee
                .FirstOrDefaultAsync(m => m.CoffeeId == id);

            // if that coffee object is null raise a 404 to the user on page
            if (coffee == null)
            {
                return NotFound();
            }

            // otherwise return deletion conformation page with data to user
            return View(coffee);
        }

        // POST: Coffees/Delete/5 - securely remove the row from Coffee table
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // remove coffee from coffee table and redirect user to Index page
            Coffee coffee = await _context.Coffee.FindAsync(id);
            _ = _context.Coffee.Remove(coffee);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // find a coffee by its ID and return whether a coffee was found
        private bool CoffeeExists(int id)
        {
            return _context.Coffee.Any(e => e.CoffeeId == id);
        }
    }
}
