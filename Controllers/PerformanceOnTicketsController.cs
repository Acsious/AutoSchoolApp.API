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
    public class PerformanceOnTicketsController : Controller
    {
        private readonly DrivingDbContext _context;

        public PerformanceOnTicketsController(DrivingDbContext context)
        {
            _context = context;
        }

        // GET: PerformanceOnTickets
        public async Task<IActionResult> Index()
        {
            var drivingDbContext = _context.PerformanceOnTickets.Include(p => p.Ticket);
            return View(await drivingDbContext.ToListAsync());
        }

        // GET: PerformanceOnTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performanceOnTicket = await _context.PerformanceOnTickets
                .Include(p => p.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performanceOnTicket == null)
            {
                return NotFound();
            }

            return View(performanceOnTicket);
        }

        // GET: PerformanceOnTickets/Create
        public IActionResult Create()
        {
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id");
            return View();
        }

        // POST: PerformanceOnTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CorrectAnswer,UserId,TicketId,SolveDate")] PerformanceOnTicket performanceOnTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(performanceOnTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", performanceOnTicket.TicketId);
            return View(performanceOnTicket);
        }

        // GET: PerformanceOnTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performanceOnTicket = await _context.PerformanceOnTickets.FindAsync(id);
            if (performanceOnTicket == null)
            {
                return NotFound();
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", performanceOnTicket.TicketId);
            return View(performanceOnTicket);
        }

        // POST: PerformanceOnTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CorrectAnswer,UserId,TicketId,SolveDate")] PerformanceOnTicket performanceOnTicket)
        {
            if (id != performanceOnTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performanceOnTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformanceOnTicketExists(performanceOnTicket.Id))
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
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", performanceOnTicket.TicketId);
            return View(performanceOnTicket);
        }

        // GET: PerformanceOnTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performanceOnTicket = await _context.PerformanceOnTickets
                .Include(p => p.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performanceOnTicket == null)
            {
                return NotFound();
            }

            return View(performanceOnTicket);
        }

        // POST: PerformanceOnTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performanceOnTicket = await _context.PerformanceOnTickets.FindAsync(id);
            if (performanceOnTicket != null)
            {
                _context.PerformanceOnTickets.Remove(performanceOnTicket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformanceOnTicketExists(int id)
        {
            return _context.PerformanceOnTickets.Any(e => e.Id == id);
        }
    }
}
