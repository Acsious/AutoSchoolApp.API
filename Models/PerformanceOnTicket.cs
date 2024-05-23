using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class PerformanceOnTicket
{
    public int Id { get; set; }

    public bool CorrectAnswer { get; set; }

    public int UserId { get; set; }

    public int TicketId { get; set; }

    public DateOnly? SolveDate { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
