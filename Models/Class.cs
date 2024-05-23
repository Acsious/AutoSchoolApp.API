using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class Class
{
    public int Id { get; set; }

    public TimeOnly? ClassTime { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
