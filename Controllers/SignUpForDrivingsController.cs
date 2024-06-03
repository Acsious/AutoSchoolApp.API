using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoSchoolApp.API.Models;

namespace AutoSchoolApp.API.Controllers
{
    public class SignUpForDrivingsController : Controller
    {
        private readonly DrivingDbContext _context;

        public SignUpForDrivingsController(DrivingDbContext context)
        {
            _context = context;
        }

        // GET: SignUpForDrivings
        public async Task<IActionResult> Index()
        {
            var drivingDbContext = _context.SignUpForDrivings.Include(s => s.Schedule).Include(s => s.User);
            return View(await drivingDbContext.ToListAsync());
        }

        // GET: SignUpForDrivings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpForDriving = await _context.SignUpForDrivings
                .Include(s => s.Schedule)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUpForDriving == null)
            {
                return NotFound();
            }

            return View(signUpForDriving);
        }

        // GET: SignUpForDrivings/Create
        public IActionResult Create()
        {
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: SignUpForDrivings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScheduleId,UserId")] SignUpForDriving signUpForDriving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signUpForDriving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", signUpForDriving.ScheduleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", signUpForDriving.UserId);
            return View(signUpForDriving);
        }

        // GET: SignUpForDrivings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpForDriving = await _context.SignUpForDrivings.FindAsync(id);
            if (signUpForDriving == null)
            {
                return NotFound();
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", signUpForDriving.ScheduleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", signUpForDriving.UserId);
            return View(signUpForDriving);
        }

        // POST: SignUpForDrivings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScheduleId,UserId")] SignUpForDriving signUpForDriving)
        {
            if (id != signUpForDriving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUpForDriving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignUpForDrivingExists(signUpForDriving.Id))
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
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", signUpForDriving.ScheduleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", signUpForDriving.UserId);
            return View(signUpForDriving);
        }

        // GET: SignUpForDrivings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpForDriving = await _context.SignUpForDrivings
                .Include(s => s.Schedule)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUpForDriving == null)
            {
                return NotFound();
            }

            return View(signUpForDriving);
        }

        // POST: SignUpForDrivings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signUpForDriving = await _context.SignUpForDrivings.FindAsync(id);
            if (signUpForDriving != null)
            {
                _context.SignUpForDrivings.Remove(signUpForDriving);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignUpForDrivingExists(int id)
        {
            return _context.SignUpForDrivings.Any(e => e.Id == id);
        }
    }
}
