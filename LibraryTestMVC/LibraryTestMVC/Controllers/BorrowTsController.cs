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
    public class BorrowTsController : Controller
    {
        private readonly LibrarytestContext _context;

        public BorrowTsController(LibrarytestContext context)
        {
            _context = context;
        }

        // GET: BorrowTs
        public async Task<IActionResult> Index()
        {
            var librarytestContext = _context.BorrowTs.Include(b => b.Author).Include(b => b.Book).Include(b => b.Student);
            return View(await librarytestContext.ToListAsync());
        }

        // GET: BorrowTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BorrowTs == null)
            {
                return NotFound();
            }

            var borrowT = await _context.BorrowTs
                .Include(b => b.Author)
                .Include(b => b.Book)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrowT == null)
            {
                return NotFound();
            }

            return View(borrowT);
        }

        // GET: BorrowTs/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId");
            ViewData["BookId"] = new SelectList(_context.BookTs, "BookId", "BookId");
            ViewData["StudentId"] = new SelectList(_context.StudentTs, "StudentId", "StudentId");
            return View();
        }

        // POST: BorrowTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowId,TakenDate,StudentId,BookId,AuthorId")] BorrowT borrowT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId", borrowT.AuthorId);
            ViewData["BookId"] = new SelectList(_context.BookTs, "BookId", "BookId", borrowT.BookId);
            ViewData["StudentId"] = new SelectList(_context.StudentTs, "StudentId", "StudentId", borrowT.StudentId);
            return View(borrowT);
        }

        // GET: BorrowTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BorrowTs == null)
            {
                return NotFound();
            }

            var borrowT = await _context.BorrowTs.FindAsync(id);
            if (borrowT == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId", borrowT.AuthorId);
            ViewData["BookId"] = new SelectList(_context.BookTs, "BookId", "BookId", borrowT.BookId);
            ViewData["StudentId"] = new SelectList(_context.StudentTs, "StudentId", "StudentId", borrowT.StudentId);
            return View(borrowT);
        }

        // POST: BorrowTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,TakenDate,StudentId,BookId,AuthorId")] BorrowT borrowT)
        {
            if (id != borrowT.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowTExists(borrowT.BorrowId))
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
            ViewData["AuthorId"] = new SelectList(_context.AuthorTs, "AuthorId", "AuthorId", borrowT.AuthorId);
            ViewData["BookId"] = new SelectList(_context.BookTs, "BookId", "BookId", borrowT.BookId);
            ViewData["StudentId"] = new SelectList(_context.StudentTs, "StudentId", "StudentId", borrowT.StudentId);
            return View(borrowT);
        }

        // GET: BorrowTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BorrowTs == null)
            {
                return NotFound();
            }

            var borrowT = await _context.BorrowTs
                .Include(b => b.Author)
                .Include(b => b.Book)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrowT == null)
            {
                return NotFound();
            }

            return View(borrowT);
        }

        // POST: BorrowTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BorrowTs == null)
            {
                return Problem("Entity set 'LibrarytestContext.BorrowTs'  is null.");
            }
            var borrowT = await _context.BorrowTs.FindAsync(id);
            if (borrowT != null)
            {
                _context.BorrowTs.Remove(borrowT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowTExists(int id)
        {
          return _context.BorrowTs.Any(e => e.BorrowId == id);
        }
    }
}
