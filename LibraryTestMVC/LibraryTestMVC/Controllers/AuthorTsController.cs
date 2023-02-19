using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryTestMVC.Models;

namespace LibraryTestMVC.Controllers
{
    public class AuthorTsController : Controller
    {
        private readonly LibrarytestContext _context;

        public AuthorTsController(LibrarytestContext context)
        {
            _context = context;
        }

        // GET: AuthorTs
        public async Task<IActionResult> Index()
        {
              return View(await _context.AuthorTs.ToListAsync());
        }

        // GET: AuthorTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuthorTs == null)
            {
                return NotFound();
            }

            var authorT = await _context.AuthorTs
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorT == null)
            {
                return NotFound();
            }

            return View(authorT);
        }

        // GET: AuthorTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName")] AuthorT authorT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorT);
        }

        // GET: AuthorTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuthorTs == null)
            {
                return NotFound();
            }

            var authorT = await _context.AuthorTs.FindAsync(id);
            if (authorT == null)
            {
                return NotFound();
            }
            return View(authorT);
        }

        // POST: AuthorTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName")] AuthorT authorT)
        {
            if (id != authorT.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorTExists(authorT.AuthorId))
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
            return View(authorT);
        }

        // GET: AuthorTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuthorTs == null)
            {
                return NotFound();
            }

            var authorT = await _context.AuthorTs
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorT == null)
            {
                return NotFound();
            }

            return View(authorT);
        }

        // POST: AuthorTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuthorTs == null)
            {
                return Problem("Entity set 'LibrarytestContext.AuthorTs'  is null.");
            }
            var authorT = await _context.AuthorTs.FindAsync(id);
            if (authorT != null)
            {
                _context.AuthorTs.Remove(authorT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorTExists(int id)
        {
          return _context.AuthorTs.Any(e => e.AuthorId == id);
        }
    }
}
