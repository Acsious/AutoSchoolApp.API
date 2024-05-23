using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class Cadet
{
    public int Id { get; set; }

    public int? ClassesAttended { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
