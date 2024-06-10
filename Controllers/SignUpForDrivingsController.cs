using AutoSchoolApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoSchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpForDrivingsController : Controller
    {
        private readonly DrivingDbContext _context;

        public SignUpForDrivingsController(DrivingDbContext context)
        {
            _context = context;
        }

        [HttpPost("MakeSignUpForDriving")]
        public async Task<ActionResult<SignUpForDriving>> Create(DateOnly date, TimeOnly time, int cadetId, int instructorId)
        {
            var classes = await _context.Classes.ToListAsync();
            int classId = classes.Find(x => x.ClassTime == time).Id;

            Schedule schedule = new()
            {
                Date = date,
                ClassesId = classId,
                InstructorId = instructorId
            };

            SignUpForDriving signUpForDriving = new()
            {
                ScheduleId = schedule.Id,
                UserId = cadetId
            };

            if (Helper.IsExists(ref signUpForDriving, _context.SignUpForDrivings.ToList()))
                return Ok(signUpForDriving);

            _context.SignUpForDrivings.Add(signUpForDriving);
            await _context.SaveChangesAsync();
            return Ok(signUpForDriving);
        }

        [HttpDelete("RemoveSignUpForDriving")]
        public async Task<ActionResult<SignUpForDriving>> Delete(DateOnly date, TimeOnly time, int cadetId, int instructorId)
        {
            var delClass = _context.Classes.FirstOrDefault(x => x.ClassTime == time);
            var schedule = _context.Schedules.FirstOrDefault(x => x.Date == date && x.ClassesId == delClass.Id && x.InstructorId == instructorId);

            if (schedule == null)
            {
                return NotFound();
            }

            var signUpForDriving = _context.SignUpForDrivings.FirstOrDefault(x => x.Schedule.Id == schedule.Id && x.UserId == cadetId);

            if (signUpForDriving == null)
            {
                return NotFound();
            }

            _context.SignUpForDrivings.Remove(signUpForDriving);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
