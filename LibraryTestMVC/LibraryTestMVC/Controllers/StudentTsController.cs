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
    public class StudentTsController : Controller
    {
        private readonly LibrarytestContext _context;

        public StudentTsController(LibrarytestContext context)
        {
            _context = context;
        }

        // GET: StudentTs
        public async Task<IActionResult> Index()
        {
              return View(await _context.StudentTs.ToListAsync());
        }

        // GET: StudentTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentTs == null)
            {
                return NotFound();
            }

            var studentT = await _context.StudentTs
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentT == null)
            {
                return NotFound();
            }

            return View(studentT);
        }

        // GET: StudentTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentFirstName,StudentLastName,StudentAge")] StudentT studentT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentT);
        }

        // GET: StudentTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentTs == null)
            {
                return NotFound();
            }

            var studentT = await _context.StudentTs.FindAsync(id);
            if (studentT == null)
            {
                return NotFound();
            }
            return View(studentT);
        }

        // POST: StudentTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentFirstName,StudentLastName,StudentAge")] StudentT studentT)
        {
            if (id != studentT.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTExists(studentT.StudentId))
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
            return View(studentT);
        }

        // GET: StudentTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentTs == null)
            {
                return NotFound();
            }

            var studentT = await _context.StudentTs
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentT == null)
            {
                return NotFound();
            }

            return View(studentT);
        }

        // POST: StudentTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentTs == null)
            {
                return Problem("Entity set 'LibrarytestContext.StudentTs'  is null.");
            }
            var studentT = await _context.StudentTs.FindAsync(id);
            if (studentT != null)
            {
                _context.StudentTs.Remove(studentT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTExists(int id)
        {
          return _context.StudentTs.Any(e => e.StudentId == id);
        }
    }
}
