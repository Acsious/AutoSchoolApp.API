using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class SignUpForDriving
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }

    public int UserId { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
