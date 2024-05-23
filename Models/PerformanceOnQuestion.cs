using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class PerformanceOnQuestion
{
    public int Id { get; set; }

    public bool CorrectAnswer { get; set; }

    public int UserId { get; set; }

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
