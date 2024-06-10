using AutoSchoolApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoSchoolApp.API.Controllers
{
    public class PerformanceOnQuestionsController : Controller
    {
        private readonly DrivingDbContext _context;

        public PerformanceOnQuestionsController(DrivingDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaveQuestionAnswer")]
        public async Task<ActionResult<PerformanceOnQuestion>> Create(int cadetId, bool correctAnswer, int questionId)
        {
            PerformanceOnQuestion performanceOnQuestion = new()
            {
                UserId = cadetId,
                CorrectAnswer = correctAnswer,
                QuestionId = questionId
            };

            if (Helper.IsExists(ref performanceOnQuestion, _context.PerformanceOnQuestions.ToList()))
            {
                await Update(cadetId, correctAnswer, questionId);
                return Ok();
            }

            _context.PerformanceOnQuestions.Add(performanceOnQuestion);
            await _context.SaveChangesAsync();
            return Ok(performanceOnQuestion);
        }

        [HttpPut("UpdateQuestionAnswer")]
        public async Task<ActionResult<PerformanceOnQuestion>> Update(int cadetId, bool correctAnswer, int questionId)
        {
            var Performances = await _context.PerformanceOnQuestions.ToListAsync();
            var Performance = Performances.Find(x => x.UserId == cadetId && x.QuestionId == questionId);

            if (Performance == null)
                return BadRequest();

            if (!_context.PerformanceOnQuestions.Any(x => x.UserId == cadetId && x.QuestionId == questionId))
                return NotFound();

            Performance.CorrectAnswer = correctAnswer;
            await _context.SaveChangesAsync();
            return Ok(Performance);
        }
    }
}
