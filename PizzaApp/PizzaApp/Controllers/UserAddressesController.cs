using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaApp;
using PizzaApp.DataAccess;

namespace PizzaApp.Controllers
{
    public class UserAddressesController : Controller
    {
        private readonly pizzaDbContext _context;

        public UserAddressesController(pizzaDbContext context)
        {
            _context = context;
        }

        // GET: UserAddresses
        public async Task<IActionResult> Index()
        {
            var pizzaDbContext = _context.UserAddress.Include(u => u.UserAddressNavigation);
            return View(await pizzaDbContext.ToListAsync());
        }

        // GET: UserAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddress = await _context.UserAddress
                .Include(u => u.UserAddressNavigation)
                .FirstOrDefaultAsync(m => m.UserAddressId == id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return View(userAddress);
        }

        // GET: UserAddresses/Create
        public IActionResult Create()
        {
            ViewData["UserAddressId"] = new SelectList(_context.UserTbl, "UserId", "FirstName");
            return View();
        }

        // POST: UserAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserAddressId,Address1,Address2,City,ProvidenceState,PostalCode,CountryAbrev")] UserAddress userAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserAddressId"] = new SelectList(_context.UserTbl, "UserId", "FirstName", userAddress.UserAddressId);
            return View(userAddress);
        }

        // GET: UserAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddress = await _context.UserAddress.FindAsync(id);
            if (userAddress == null)
            {
                return NotFound();
            }
            ViewData["UserAddressId"] = new SelectList(_context.UserTbl, "UserId", "FirstName", userAddress.UserAddressId);
            return View(userAddress);
        }

        // POST: UserAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserAddressId,Address1,Address2,City,ProvidenceState,PostalCode,CountryAbrev")] UserAddress userAddress)
        {
            if (id != userAddress.UserAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAddressExists(userAddress.UserAddressId))
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
            ViewData["UserAddressId"] = new SelectList(_context.UserTbl, "UserId", "FirstName", userAddress.UserAddressId);
            return View(userAddress);
        }

        // GET: UserAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddress = await _context.UserAddress
                .Include(u => u.UserAddressNavigation)
                .FirstOrDefaultAsync(m => m.UserAddressId == id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return View(userAddress);
        }

        // POST: UserAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAddress = await _context.UserAddress.FindAsync(id);
            _context.UserAddress.Remove(userAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAddressExists(int id)
        {
            return _context.UserAddress.Any(e => e.UserAddressId == id);
        }
    }
}
