using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Beanbrew.Controllers
{
    public class SpaceBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpaceBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpaceBookings
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<SpaceBooking, Restaurant> applicationDbContext = _context.SpaceBooking.Include(s => s.Customers).Include(s => s.Restaurants);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SpaceBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SpaceBooking spaceBooking = await _context.SpaceBooking
                .Include(s => s.Customers)
                .Include(s => s.Restaurants)
                .FirstOrDefaultAsync(m => m.SpaceBookingId == id);
            return spaceBooking == null ? NotFound() : (IActionResult)View(spaceBooking);
        }

        // GET: SpaceBookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "RestaurantId");
            return View();
        }

        // POST: SpaceBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpaceBookingId,CustomerId,RestaurantId,TimeSlot")] SpaceBooking spaceBooking)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(spaceBooking);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", spaceBooking.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "RestaurantId", spaceBooking.RestaurantId);
            return View(spaceBooking);
        }

        // GET: SpaceBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SpaceBooking spaceBooking = await _context.SpaceBooking.FindAsync(id);
            if (spaceBooking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", spaceBooking.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "RestaurantId", spaceBooking.RestaurantId);
            return View(spaceBooking);
        }

        // POST: SpaceBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpaceBookingId,CustomerId,RestaurantId,TimeSlot")] SpaceBooking spaceBooking)
        {
            if (id != spaceBooking.SpaceBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(spaceBooking);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaceBookingExists(spaceBooking.SpaceBookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", spaceBooking.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "RestaurantId", spaceBooking.RestaurantId);
            return View(spaceBooking);
        }

        // GET: SpaceBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SpaceBooking spaceBooking = await _context.SpaceBooking
                .Include(s => s.Customers)
                .Include(s => s.Restaurants)
                .FirstOrDefaultAsync(m => m.SpaceBookingId == id);
            return spaceBooking == null ? NotFound() : (IActionResult)View(spaceBooking);
        }

        // POST: SpaceBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            SpaceBooking spaceBooking = await _context.SpaceBooking.FindAsync(id);
            _ = _context.SpaceBooking.Remove(spaceBooking);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaceBookingExists(int id)
        {
            return _context.SpaceBooking.Any(e => e.SpaceBookingId == id);
        }
    }
}
