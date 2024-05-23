using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class InstructorAuto
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string LicensePlate { get; set; } = null!;

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
