using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RideShareMVC.Models;

namespace RideShareMVC.Controllers
{
    public class TblcontactsController : Controller
    {
        private readonly RideShareContext _context;

        public TblcontactsController(RideShareContext context)
        {
            _context = context;
        }

        // GET: Tblcontacts
        public async Task<IActionResult> Index()
        {
            var rideShareContext = _context.Tblcontact.Include(t => t.ContactTypeNavigation).Include(t => t.UserGu);
            return View(await rideShareContext.ToListAsync());
        }

        // GET: Tblcontacts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcontact = await _context.Tblcontact
                .Include(t => t.ContactTypeNavigation)
                .Include(t => t.UserGu)
                .FirstOrDefaultAsync(m => m.ContactGuid == id);
            if (tblcontact == null)
            {
                return NotFound();
            }

            return View(tblcontact);
        }

        // GET: Tblcontacts/Create
        public IActionResult Create()
        {
            ViewData["ContactType"] = new SelectList(_context.TblContactType, "ContactTypeGuid", "ContactTypeGuid");
            ViewData["UserGuid"] = new SelectList(_context.TblUser, "UserGuid", "EmailAddress");
            return View();
        }

        // POST: Tblcontacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactGuid,UserGuid,ContactType,ContactValue,IsActive,ContactCreateDate,ContactUpdateDate")] Tblcontact tblcontact)
        {
            if (ModelState.IsValid)
            {
                tblcontact.ContactGuid = Guid.NewGuid();
                _context.Add(tblcontact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactType"] = new SelectList(_context.TblContactType, "ContactTypeGuid", "ContactTypeGuid", tblcontact.ContactType);
            ViewData["UserGuid"] = new SelectList(_context.TblUser, "UserGuid", "EmailAddress", tblcontact.UserGuid);
            return View(tblcontact);
        }

        // GET: Tblcontacts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcontact = await _context.Tblcontact.FindAsync(id);
            if (tblcontact == null)
            {
                return NotFound();
            }
            ViewData["ContactType"] = new SelectList(_context.TblContactType, "ContactTypeGuid", "ContactTypeGuid", tblcontact.ContactType);
            ViewData["UserGuid"] = new SelectList(_context.TblUser, "UserGuid", "EmailAddress", tblcontact.UserGuid);
            return View(tblcontact);
        }

        // POST: Tblcontacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ContactGuid,UserGuid,ContactType,ContactValue,IsActive,ContactCreateDate,ContactUpdateDate")] Tblcontact tblcontact)
        {
            if (id != tblcontact.ContactGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblcontact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblcontactExists(tblcontact.ContactGuid))
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
            ViewData["ContactType"] = new SelectList(_context.TblContactType, "ContactTypeGuid", "ContactTypeGuid", tblcontact.ContactType);
            ViewData["UserGuid"] = new SelectList(_context.TblUser, "UserGuid", "EmailAddress", tblcontact.UserGuid);
            return View(tblcontact);
        }

        // GET: Tblcontacts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcontact = await _context.Tblcontact
                .Include(t => t.ContactTypeNavigation)
                .Include(t => t.UserGu)
                .FirstOrDefaultAsync(m => m.ContactGuid == id);
            if (tblcontact == null)
            {
                return NotFound();
            }

            return View(tblcontact);
        }

        // POST: Tblcontacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblcontact = await _context.Tblcontact.FindAsync(id);
            _context.Tblcontact.Remove(tblcontact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblcontactExists(Guid id)
        {
            return _context.Tblcontact.Any(e => e.ContactGuid == id);
        }
    }
}
