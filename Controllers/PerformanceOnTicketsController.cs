using AutoSchoolApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoSchoolApp.API.Controllers
{
    public class PerformanceOnTicketsController : Controller
    {
        private readonly DrivingDbContext _context;

        public PerformanceOnTicketsController(DrivingDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaveTicketAnswer")]
        public async Task<ActionResult<PerformanceOnTicket>> Create(int cadetId, bool correctAnswer, int ticketId)
        {
            PerformanceOnTicket performanceOnTicket = new()
            {
                UserId = cadetId,
                CorrectAnswer = correctAnswer,
                TicketId = ticketId
            };

            if (Helper.IsExists(ref performanceOnTicket, _context.PerformanceOnTickets.ToList()))
            {
                await Update(cadetId, correctAnswer, ticketId);
                return Ok();
            }

            _context.PerformanceOnTickets.Add(performanceOnTicket);
            await _context.SaveChangesAsync();
            return Ok(performanceOnTicket);
        }

        [HttpPut("UpdateTicketAnswer")]
        public async Task<ActionResult<PerformanceOnTicket>> Update(int cadetId, bool correctAnswer, int ticketId)
        {
            var Performances = await _context.PerformanceOnTickets.ToListAsync();
            var Performance = Performances.Find(x => x.UserId == cadetId && x.TicketId == ticketId);

            if (Performance == null)
                return BadRequest();

            if (!_context.PerformanceOnTickets.Any(x => x.UserId == cadetId && x.TicketId == ticketId))
                return NotFound();

            Performance.CorrectAnswer = correctAnswer;
            await _context.SaveChangesAsync();
            return Ok(Performance);
        }
    }
}
