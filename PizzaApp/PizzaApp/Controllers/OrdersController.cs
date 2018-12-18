﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess;

namespace PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly pizzaDbContext _context;

        public OrdersController(pizzaDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var pizzaDbContext = _context.Orders.Include(o => o.IdNavigation).Include(o => o.StoreAddress).Include(o => o.UserOrderAddress);
            return View(await pizzaDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.IdNavigation)
                .Include(o => o.StoreAddress)
                .Include(o => o.UserOrderAddress)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.OrderDetails, "OrderId", "OrderId");
            ViewData["StoreAddressId"] = new SelectList(_context.Store, "StoreAddressId", "Address1");
            ViewData["UserOrderAddressId"] = new SelectList(_context.UserAddress, "UserAddressId", "Address1");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserOrderAddressId,StoreAddressId,Id,OrderId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.OrderDetails, "OrderId", "OrderId", orders.Id);
            ViewData["StoreAddressId"] = new SelectList(_context.Store, "StoreAddressId", "Address1", orders.StoreAddressId);
            ViewData["UserOrderAddressId"] = new SelectList(_context.UserAddress, "UserAddressId", "Address1", orders.UserOrderAddressId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.OrderDetails, "OrderId", "OrderId", orders.Id);
            ViewData["StoreAddressId"] = new SelectList(_context.Store, "StoreAddressId", "Address1", orders.StoreAddressId);
            ViewData["UserOrderAddressId"] = new SelectList(_context.UserAddress, "UserAddressId", "Address1", orders.UserOrderAddressId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserOrderAddressId,StoreAddressId,Id,OrderId")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
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
            ViewData["Id"] = new SelectList(_context.OrderDetails, "OrderId", "OrderId", orders.Id);
            ViewData["StoreAddressId"] = new SelectList(_context.Store, "StoreAddressId", "Address1", orders.StoreAddressId);
            ViewData["UserOrderAddressId"] = new SelectList(_context.UserAddress, "UserAddressId", "Address1", orders.UserOrderAddressId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.IdNavigation)
                .Include(o => o.StoreAddress)
                .Include(o => o.UserOrderAddress)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
