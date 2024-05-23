using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public int InstructorId { get; set; }

    public int ClassesId { get; set; }

    public virtual Class Classes { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual ICollection<SignUpForDriving> SignUpForDrivings { get; set; } = new List<SignUpForDriving>();
}
