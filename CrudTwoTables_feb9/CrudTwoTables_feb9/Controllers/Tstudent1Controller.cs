using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudTwoTables_feb9.Models;

namespace CrudTwoTables_feb9.Controllers
{
    public class Tstudent1Controller : Controller
    {
        private readonly StudentCourse2Context _context;

        public Tstudent1Controller(StudentCourse2Context context)
        {
            _context = context;
        }

        // GET: Tstudent1
        public async Task<IActionResult> Index()
        {
            var studentCourse2Context = _context.Tstudent1s.Include(t => t.Course);
            return View(await studentCourse2Context.ToListAsync());
        }

        // GET: Tstudent1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tstudent1s == null)
            {
                return NotFound();
            }

            var tstudent1 = await _context.Tstudent1s
                .Include(t => t.Course)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tstudent1 == null)
            {
                return NotFound();
            }

            return View(tstudent1);
        }

        // GET: Tstudent1/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Tcourse1s, "CourseId", "CourseId");
            return View();
        }

        // POST: Tstudent1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentAddress,CourseId")] Tstudent1 tstudent1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tstudent1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Tcourse1s, "CourseId", "CourseId", tstudent1.CourseId);
            return View(tstudent1);
        }

        // GET: Tstudent1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tstudent1s == null)
            {
                return NotFound();
            }

            var tstudent1 = await _context.Tstudent1s.FindAsync(id);
            if (tstudent1 == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Tcourse1s, "CourseId", "CourseId", tstudent1.CourseId);
            return View(tstudent1);
        }

        // POST: Tstudent1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentAddress,CourseId")] Tstudent1 tstudent1)
        {
            if (id != tstudent1.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tstudent1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tstudent1Exists(tstudent1.StudentId))
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
            ViewData["CourseId"] = new SelectList(_context.Tcourse1s, "CourseId", "CourseId", tstudent1.CourseId);
            return View(tstudent1);
        }

        // GET: Tstudent1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tstudent1s == null)
            {
                return NotFound();
            }

            var tstudent1 = await _context.Tstudent1s
                .Include(t => t.Course)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tstudent1 == null)
            {
                return NotFound();
            }

            return View(tstudent1);
        }

        // POST: Tstudent1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tstudent1s == null)
            {
                return Problem("Entity set 'StudentCourse2Context.Tstudent1s'  is null.");
            }
            var tstudent1 = await _context.Tstudent1s.FindAsync(id);
            if (tstudent1 != null)
            {
                _context.Tstudent1s.Remove(tstudent1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tstudent1Exists(int id)
        {
          return _context.Tstudent1s.Any(e => e.StudentId == id);
        }
    }
}
