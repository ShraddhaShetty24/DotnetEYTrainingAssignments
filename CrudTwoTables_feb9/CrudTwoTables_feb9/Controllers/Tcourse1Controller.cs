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
    public class Tcourse1Controller : Controller
    {
        private readonly StudentCourse2Context _context;

        public Tcourse1Controller(StudentCourse2Context context)
        {
            _context = context;
        }

        // GET: Tcourse1
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tcourse1s.ToListAsync());
        }

        // GET: Tcourse1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tcourse1s == null)
            {
                return NotFound();
            }

            var tcourse1 = await _context.Tcourse1s
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (tcourse1 == null)
            {
                return NotFound();
            }

            return View(tcourse1);
        }

        // GET: Tcourse1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tcourse1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,CourseFee")] Tcourse1 tcourse1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tcourse1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tcourse1);
        }

        // GET: Tcourse1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tcourse1s == null)
            {
                return NotFound();
            }

            var tcourse1 = await _context.Tcourse1s.FindAsync(id);
            if (tcourse1 == null)
            {
                return NotFound();
            }
            return View(tcourse1);
        }

        // POST: Tcourse1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName,CourseFee")] Tcourse1 tcourse1)
        {
            if (id != tcourse1.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tcourse1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tcourse1Exists(tcourse1.CourseId))
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
            return View(tcourse1);
        }

        // GET: Tcourse1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tcourse1s == null)
            {
                return NotFound();
            }

            var tcourse1 = await _context.Tcourse1s
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (tcourse1 == null)
            {
                return NotFound();
            }

            return View(tcourse1);
        }

        // POST: Tcourse1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tcourse1s == null)
            {
                return Problem("Entity set 'StudentCourse2Context.Tcourse1s'  is null.");
            }
            var tcourse1 = await _context.Tcourse1s.FindAsync(id);
            if (tcourse1 != null)
            {
                _context.Tcourse1s.Remove(tcourse1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tcourse1Exists(int id)
        {
          return _context.Tcourse1s.Any(e => e.CourseId == id);
        }
    }
}
