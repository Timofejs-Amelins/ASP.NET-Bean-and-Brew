// import modules necessary for the contr to perform CRUD on contacts table
using Beanbrew.Data;
using Beanbrew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// ContactsContr must inherit all contr methods to perform CRUD functionality
namespace Beanbrew.Controllers
{
    public class ContactsController : Controller
    {
        // declare ApplicationDbContext property to be defined in controller
        private readonly ApplicationDbContext _context;

        // set ApplicationDbContext property so C# performs CRUD without SQL
        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contacts - get all messages and return table page of contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        // GET: Contacts/Details/5 - get all the details about a single message
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.ContactID == id);
            return contact == null ? NotFound() : (IActionResult)View(contact);
        }

        // GET: Contacts/Create - get the contact creation webform
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create - validate token before sending msge to table
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,Email,Subject,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(contact);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5 - get the contact and display form with data
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact contact = await _context.Contact.FindAsync(id);
            return contact == null ? NotFound() : (IActionResult)View(contact);
        }

        // POST: Contacts/Edit/5 - validate token and update the Contact tble
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactID,Email,Subject,Message")] Contact contact)
        {
            if (id != contact.ContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(contact);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactID))
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
            return View(contact);
        }

        // GET: Contacts/Delete/5 - get deletion page with coffee data
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.ContactID == id);
            return contact == null ? NotFound() : (IActionResult)View(contact);
        }

        // POST: Contacts/Delete/5 - validate token and delete contact
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Contact contact = await _context.Contact.FindAsync(id);
            _ = _context.Contact.Remove(contact);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // check the existence of a contact and return contact if it is found
        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.ContactID == id);
        }
    }
}
