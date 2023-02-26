using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudExample_Feb9.Models;

namespace CrudExample_Feb9.Controllers
{
    public class TEmployeesController : Controller
    {
        private readonly EmployeeContext _context;

        public TEmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: TEmployees
        public async Task<IActionResult> Index()
        {
              return View(await _context.TEmployees.ToListAsync());
        }

        // GET: TEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TEmployees == null)
            {
                return NotFound();
            }

            var tEmployee = await _context.TEmployees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (tEmployee == null)
            {
                return NotFound();
            }

            return View(tEmployee);
        }

        // GET: TEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,EmployeeSalary,EmployeeAge")] TEmployee tEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tEmployee);
        }

        // GET: TEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TEmployees == null)
            {
                return NotFound();
            }

            var tEmployee = await _context.TEmployees.FindAsync(id);
            if (tEmployee == null)
            {
                return NotFound();
            }
            return View(tEmployee);
        }

        // POST: TEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,EmployeeSalary,EmployeeAge")] TEmployee tEmployee)
        {
            if (id != tEmployee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TEmployeeExists(tEmployee.EmployeeId))
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
            return View(tEmployee);
        }

        // GET: TEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TEmployees == null)
            {
                return NotFound();
            }

            var tEmployee = await _context.TEmployees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (tEmployee == null)
            {
                return NotFound();
            }

            return View(tEmployee);
        }

        // POST: TEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TEmployees == null)
            {
                return Problem("Entity set 'EmployeeContext.TEmployees'  is null.");
            }
            var tEmployee = await _context.TEmployees.FindAsync(id);
            if (tEmployee != null)
            {
                _context.TEmployees.Remove(tEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TEmployeeExists(int id)
        {
          return _context.TEmployees.Any(e => e.EmployeeId == id);
        }
    }
}
