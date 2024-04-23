// import different modules essential to the functionality of a controller
using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Beanbrew.Controllers
{
    // this class performs different methods for CRUD of baked good orers
    public class BakedGoodsOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        // set an ApplicationDbContext for C# to do CRUD instead of SQL
        public BakedGoodsOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BakedGoodsOrders - get an overview of baked goods
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<BakedGoodsOrder, Hamper> applicationDbContext = _context.BakedGoodsOrder.Include(b => b.BakedGoods).Include(b => b.Customer).Include(b => b.Hampers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BakedGoodsOrders/Details/5 - get the details of a baked goods order
        public async Task<IActionResult> Details(int? id)
        {
            // check if the order ID is null and if so, raise a 404
            if (id == null)
            {
                return NotFound();
            }

            // set the primary and foreign keys for the baked goods order
            BakedGoodsOrder bakedGoodsOrder = await _context.BakedGoodsOrder
                .Include(b => b.BakedGoods)
                .Include(b => b.Customer)
                .Include(b => b.Hampers)
                .FirstOrDefaultAsync(m => m.BakedGoodsOrderId == id);

            // check if the order is null and if so raise a 404
            return bakedGoodsOrder == null ? NotFound() : (IActionResult)View(bakedGoodsOrder);
        }

        // GET: BakedGoodsOrders/Create - get foreign keys and return page
        public IActionResult Create()
        {
            ViewData["BakedGoodsId"] = new SelectList(_context.BakedGood, "BakedGoodsId", "BakedGoodsId");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["HamperId"] = new SelectList(_context.Hamper, "HamperId", "HamperId");
            return View();
        }

        // POST: BakedGoodsOrders/Create - securely insert a baked goods order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BakedGoodsOrderId,Quantity,BakedGoodsId,CustomerId,HamperId,Price")] BakedGoodsOrder bakedGoodsOrder)
        {
            // if the baked goods order is valid calculate and return page
            if (ModelState.IsValid)
            {
                // add baked goods order and redirect user to Index page
                _ = _context.Add(bakedGoodsOrder);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // get the foreign keys from related tables and return create page
            ViewData["BakedGoodsId"] = new SelectList(_context.BakedGood, "BakedGoodsId", "BakedGoodsId", bakedGoodsOrder.BakedGoodsId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", bakedGoodsOrder.CustomerId);
            ViewData["HamperId"] = new SelectList(_context.Hamper, "HamperId", "HamperId", bakedGoodsOrder.HamperId);
            return View(bakedGoodsOrder);
        }

        // GET: BakedGoodsOrders/Edit/5  - get foreign keys and return page
        public async Task<IActionResult> Edit(int? id)
        {
            // if the ID is null raise a 404 to tell user order is not found
            if (id == null)
            {
                return NotFound();
            }
            // if the order is null raise 404 and tell user order is not found
            BakedGoodsOrder bakedGoodsOrder = await _context.BakedGoodsOrder.FindAsync(id);
            if (bakedGoodsOrder == null)
            {
                return NotFound();
            }
            // otherwise set the foreign keys and return the edit page
            ViewData["BakedGoodsId"] = new SelectList(_context.BakedGood, "BakedGoodsId", "BakedGoodsId", bakedGoodsOrder.BakedGoodsId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", bakedGoodsOrder.CustomerId);
            ViewData["HamperId"] = new SelectList(_context.Hamper, "HamperId", "HamperId", bakedGoodsOrder.HamperId);
            return View(bakedGoodsOrder);
        }

        // POST: BakedGoodsOrders/Edit/5 - securely update a baked goods order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BakedGoodsOrderId,Quantity,BakedGoodsId,CustomerId,HamperId,Price")] BakedGoodsOrder bakedGoodsOrder)
        {
            // if IDs do not match tell user that order is not found
            if (id != bakedGoodsOrder.BakedGoodsOrderId)
            {
                return NotFound();
            }

            // if the order is valid redirect the user to the order index page
            if (ModelState.IsValid)
            {
                // try to update the baked good order
                try
                {
                    _ = _context.Update(bakedGoodsOrder);
                    _ = await _context.SaveChangesAsync();
                }
                // if 0 or multiple rows are updated throw an error
                catch (DbUpdateConcurrencyException)
                {
                    // if no baked good orders are updated throw an error
                    if (!BakedGoodsOrderExists(bakedGoodsOrder.BakedGoodsOrderId))
                    {
                        return NotFound();
                    }
                    // otherwise throw the DbUpdateConcurrencyException
                    else
                    {
                        throw;
                    }
                }
                // redirect the user to the index page
                return RedirectToAction(nameof(Index));
            }
            // set values to display correct values in if there were errors
            ViewData["BakedGoodsId"] = new SelectList(_context.BakedGood, "BakedGoodsId", "BakedGoodsId", bakedGoodsOrder.BakedGoodsId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", bakedGoodsOrder.CustomerId);
            ViewData["HamperId"] = new SelectList(_context.Hamper, "HamperId", "HamperId", bakedGoodsOrder.HamperId);
            return View(bakedGoodsOrder);
        }

        // GET: BakedGoodsOrders/Delete/5 - get the deletion confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            // raise a 404 if the ID is null
            if (id == null)
            {
                return NotFound();
            }

            // otherwise bind the keys to the baked goods order
            BakedGoodsOrder bakedGoodsOrder = await _context.BakedGoodsOrder
                .Include(b => b.BakedGoods)
                .Include(b => b.Customer)
                .Include(b => b.Hampers)
                .FirstOrDefaultAsync(m => m.BakedGoodsOrderId == id);

            // if the order is null raise a 404
            if (bakedGoodsOrder == null)
            {
                return NotFound();
            }

            // return the deletion confirmation page to the user
            return View(bakedGoodsOrder);
        }

        // POST: BakedGoodsOrders/Delete/5 - delete the order securely
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            BakedGoodsOrder bakedGoodsOrder = await _context.BakedGoodsOrder.FindAsync(id);
            _ = _context.BakedGoodsOrder.Remove(bakedGoodsOrder);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // search for order by ID and if found/not found return True/False
        private bool BakedGoodsOrderExists(int id)
        {
            return _context.BakedGoodsOrder.Any(e => e.BakedGoodsOrderId == id);
        }
    }
}
