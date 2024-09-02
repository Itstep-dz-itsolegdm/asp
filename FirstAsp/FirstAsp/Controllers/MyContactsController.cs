using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstAsp.Models; 
using System.Threading.Tasks;

namespace FirstAsp.Controllers 
{
    public class MyContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyContacts.ToListAsync());
        }

        // GET: MyContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myContact = await _context.MyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myContact == null)
            {
                return NotFound();
            }

            return View(myContact);
        }

        // GET: MyContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyContacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone")] MyContacts myContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myContact);
        }

        // GET: MyContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myContact = await _context.MyContacts.FindAsync(id);
            if (myContact == null)
            {
                return NotFound();
            }
            return View(myContact);
        }

        // POST: MyContacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone")] MyContacts myContact)
        {
            if (id != myContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyContactsExists(myContact.Id))
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
            return View(myContact);
        }

        // GET: MyContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myContact = await _context.MyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myContact == null)
            {
                return NotFound();
            }

            return View(myContact);
        }

        // POST: MyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myContact = await _context.MyContacts.FindAsync(id);
            _context.MyContacts.Remove(myContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyContactsExists(int id)
        {
            return _context.MyContacts.Any(e => e.Id == id);
        }
    }
}
