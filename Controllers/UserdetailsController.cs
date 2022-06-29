﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShoppingApp.Data;
using EShoppingApp.Models;

namespace EShoppingApp.Controllers
{
    public class UserdetailsController : Controller
    {
        private readonly EShoppingAppContext _context;

        public UserdetailsController(EShoppingAppContext context)
        {
            _context = context;
        }

        // GET: Userdetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Userdetails.ToListAsync());
        }

        // GET: Userdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userdetails = await _context.Userdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userdetails == null)
            {
                return NotFound();
            }

            return View(userdetails);
        }

        // GET: Userdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Firstname,Lastname,Mobileno,Created,Email,Usertype,Password")] Userdetails userdetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userdetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userdetails);
        }

        // GET: Userdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userdetails = await _context.Userdetails.FindAsync(id);
            if (userdetails == null)
            {
                return NotFound();
            }
            return View(userdetails);
        }

        // POST: Userdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Firstname,Lastname,Mobileno,Created,Email,Usertype,Password")] Userdetails userdetails)
        {
            if (id != userdetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userdetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserdetailsExists(userdetails.Id))
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
            return View(userdetails);
        }

        // GET: Userdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userdetails = await _context.Userdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userdetails == null)
            {
                return NotFound();
            }

            return View(userdetails);
        }

        // POST: Userdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userdetails = await _context.Userdetails.FindAsync(id);
            _context.Userdetails.Remove(userdetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserdetailsExists(int id)
        {
            return _context.Userdetails.Any(e => e.Id == id);
        }
    }
}
