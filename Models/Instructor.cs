using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public int InstructorAutoId { get; set; }

    public int UserId { get; set; }

    public virtual InstructorAuto InstructorAuto { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual User User { get; set; } = null!;
}
