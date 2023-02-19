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
    public class BookTsController : Controller
    {
        private readonly LibrarytestContext _context;

        public BookTsController(LibrarytestContext context)
        {
            _context = context;
        }

        // GET: BookTs
        public async Task<IActionResult> Index()
        {
            var librarytestContext = _context.BookTs.Include(b => b.Author);
            return View(await librarytestContext.ToListAsync());
        }

        // GET: BookTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookTs == null)
            {
                return NotFound();
            }

            var bookT = await _context.BookTs
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookT == null)
            {
                return NotFound();
            }

            return View(bookT);
        }

        // GET: BookTs/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId");
            return View();
        }

        // POST: BookTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,BookPageCount,AuthorId")] BookT bookT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId", bookT.AuthorId);
            return View(bookT);
        }

        // GET: BookTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookTs == null)
            {
                return NotFound();
            }

            var bookT = await _context.BookTs.FindAsync(id);
            if (bookT == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId", bookT.AuthorId);
            return View(bookT);
        }

        // POST: BookTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,BookPageCount,AuthorId")] BookT bookT)
        {
            if (id != bookT.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTExists(bookT.BookId))
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
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId", bookT.AuthorId);
            return View(bookT);
        }

        // GET: BookTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookTs == null)
            {
                return NotFound();
            }

            var bookT = await _context.BookTs
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookT == null)
            {
                return NotFound();
            }

            return View(bookT);
        }

        // POST: BookTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookTs == null)
            {
                return Problem("Entity set 'LibrarytestContext.BookTs'  is null.");
            }
            var bookT = await _context.BookTs.FindAsync(id);
            if (bookT != null)
            {
                _context.BookTs.Remove(bookT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTExists(int id)
        {
          return _context.BookTs.Any(e => e.BookId == id);
        }
    }
}
