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
    public class PerformanceOnQuestionsController : Controller
    {
        private readonly DrivingDbContext _context;

        public PerformanceOnQuestionsController(DrivingDbContext context)
        {
            _context = context;
        }

        // GET: PerformanceOnQuestions
        public async Task<IActionResult> Index()
        {
            var drivingDbContext = _context.PerformanceOnQuestions.Include(p => p.Question);
            return View(await drivingDbContext.ToListAsync());
        }

        // GET: PerformanceOnQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performanceOnQuestion = await _context.PerformanceOnQuestions
                .Include(p => p.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performanceOnQuestion == null)
            {
                return NotFound();
            }

            return View(performanceOnQuestion);
        }

        // GET: PerformanceOnQuestions/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
            return View();
        }

        // POST: PerformanceOnQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CorrectAnswer,UserId,QuestionId")] PerformanceOnQuestion performanceOnQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(performanceOnQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", performanceOnQuestion.QuestionId);
            return View(performanceOnQuestion);
        }

        // GET: PerformanceOnQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performanceOnQuestion = await _context.PerformanceOnQuestions.FindAsync(id);
            if (performanceOnQuestion == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", performanceOnQuestion.QuestionId);
            return View(performanceOnQuestion);
        }

        // POST: PerformanceOnQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CorrectAnswer,UserId,QuestionId")] PerformanceOnQuestion performanceOnQuestion)
        {
            if (id != performanceOnQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performanceOnQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformanceOnQuestionExists(performanceOnQuestion.Id))
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
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", performanceOnQuestion.QuestionId);
            return View(performanceOnQuestion);
        }

        // GET: PerformanceOnQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performanceOnQuestion = await _context.PerformanceOnQuestions
                .Include(p => p.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performanceOnQuestion == null)
            {
                return NotFound();
            }

            return View(performanceOnQuestion);
        }

        // POST: PerformanceOnQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performanceOnQuestion = await _context.PerformanceOnQuestions.FindAsync(id);
            if (performanceOnQuestion != null)
            {
                _context.PerformanceOnQuestions.Remove(performanceOnQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformanceOnQuestionExists(int id)
        {
            return _context.PerformanceOnQuestions.Any(e => e.Id == id);
        }
    }
}
