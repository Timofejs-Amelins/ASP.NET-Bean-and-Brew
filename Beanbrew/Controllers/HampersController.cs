// import modules to implement the controller functionality properly
using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Beanbrew.Controllers
{
    public class HampersController : Controller
    {
        // declare ApplicationDbContext property to perform CRUD using C#
        private readonly ApplicationDbContext _context;

        // construct the hamper and set an ApplicationDbContext property
        public HampersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hampers - return all the data about the hampers to tbl page
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hamper.ToListAsync());
        }

        // GET: Hampers/Details/5 - get the details of a hamper based on ID
        public async Task<IActionResult> Details(int? id)
        {
            // if the ID is null then raise a 404 error
            if (id == null)
            {
                return NotFound();
            }

            // if the hamper is null then raise a 404 error
            Hamper hamper = await _context.Hamper
                .FirstOrDefaultAsync(m => m.HamperId == id);
            return hamper == null ? NotFound() : (IActionResult)View(hamper);
        }

        // GET: Hampers/Create - get the hamper creation entry form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hampers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HamperId,Size,Colour,Price")] Hamper hamper)
        {
            if (ModelState.IsValid)
            {
                // this is the calculation
                hamper.Price = hamper.Size * (decimal)0.1;
                // store the price in a text box
                ViewBag.HamperPriceTextBox = hamper.Price.ToString();
                _ = _context.Add(hamper);
                _ = await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                ViewBag.HamperPriceMessage = "Your hamper costs £" + hamper.Price;
            }
            return View(hamper);
        }

        // GET: Hampers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hamper hamper = await _context.Hamper.FindAsync(id);
            return hamper == null ? NotFound() : (IActionResult)View(hamper);
        }

        // POST: Hampers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HamperId,Size,Colour,Price")] Hamper hamper)
        {
            if (id != hamper.HamperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(hamper);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HamperExists(hamper.HamperId))
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
            return View(hamper);
        }

        // GET: Hampers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hamper hamper = await _context.Hamper
                .FirstOrDefaultAsync(m => m.HamperId == id);
            return hamper == null ? NotFound() : (IActionResult)View(hamper);
        }

        // POST: Hampers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Hamper hamper = await _context.Hamper.FindAsync(id);
            _ = _context.Hamper.Remove(hamper);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HamperExists(int id)
        {
            return _context.Hamper.Any(e => e.HamperId == id);
        }
    }
}
