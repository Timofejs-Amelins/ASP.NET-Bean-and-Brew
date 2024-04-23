// import these to provide the BakedGoodsController with useful functions
using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// provide the controller with CRUD and put the controller in a container
namespace Beanbrew.Controllers
{
    public class BakedGoodsController : Controller
    {
        // this declares an ApplicationDbContext type property
        private readonly ApplicationDbContext _context;

        // set var to ApplicationDbContext obj for CRUD with C# instead of SQL 
        public BakedGoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BakedGoods - get baked goods and put them in index page returned
        public async Task<IActionResult> Index()
        {
            return View(await _context.BakedGood.ToListAsync());
        }

        // GET: BakedGoods/Details/5 - get and return a baked good
        public async Task<IActionResult> Details(int? id)
        {
            // produce an error if the ID is null
            if (id == null)
            {
                return NotFound();
            }

            // get the baked good, check if it is null and make error if null
            BakedGood bakedGood = await _context.BakedGood
                .FirstOrDefaultAsync(m => m.BakedGoodsId == id);
            if (bakedGood == null)
            {
                return NotFound();
            }

            // otherwise return the baked good for displaying a baked good
            return View(bakedGood);
        }

        // GET: BakedGoods/Create - return a baked good entry form
        public IActionResult Create()
        {
            return View();
        }

        // POST: BakedGoods/Create, stop user doing acts on other websites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BakedGoodsId,BakedGoodName,BakedGoodType,Price")] BakedGood bakedGood)
        {   // check if the values are valid and if so create the baked good
            if (ModelState.IsValid)
            {
                _ = _context.Add(bakedGood);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // if the values are invalid return the page with outdated data
            return View(bakedGood);
        }

        // GET: BakedGoods/Edit/5 - get the baked goods edit form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BakedGood bakedGood = await _context.BakedGood.FindAsync(id);
            return bakedGood == null ? NotFound() : (IActionResult)View(bakedGood);
        }

        // POST: BakedGoods/Edit/5 - update baked good securely
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BakedGoodsId,BakedGoodName,BakedGoodType,Price")] BakedGood bakedGood)
        {
            if (id != bakedGood.BakedGoodsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(bakedGood);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BakedGoodExists(bakedGood.BakedGoodsId))
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
            return View(bakedGood);
        }

        // GET: BakedGoods/Delete/5 - get deletion confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BakedGood bakedGood = await _context.BakedGood
                .FirstOrDefaultAsync(m => m.BakedGoodsId == id);
            return bakedGood == null ? NotFound() : (IActionResult)View(bakedGood);
        }

        // POST: BakedGoods/Delete/5 - delete the baked good securely
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            BakedGood bakedGood = await _context.BakedGood.FindAsync(id);
            _ = _context.BakedGood.Remove(bakedGood);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // check if a baked good exists and if so return baked good else null
        private bool BakedGoodExists(int id)
        {
            return _context.BakedGood.Any(e => e.BakedGoodsId == id);
        }
    }
}
