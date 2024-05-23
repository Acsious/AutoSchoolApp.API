using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int TicketNumber { get; set; }

    public int Question1 { get; set; }

    public int Question2 { get; set; }

    public int Question3 { get; set; }

    public int Question4 { get; set; }

    public int Question5 { get; set; }

    public int Question6 { get; set; }

    public int Question7 { get; set; }

    public int Question8 { get; set; }

    public int Question9 { get; set; }

    public int Question10 { get; set; }

    public int Question11 { get; set; }

    public int Question12 { get; set; }

    public int Question13 { get; set; }

    public int Question14 { get; set; }

    public int Question15 { get; set; }

    public int Question16 { get; set; }

    public int Question17 { get; set; }

    public int Question18 { get; set; }

    public int Question19 { get; set; }

    public int Question20 { get; set; }

    public virtual ICollection<PerformanceOnTicket> PerformanceOnTickets { get; set; } = new List<PerformanceOnTicket>();

    public virtual Question Question10Navigation { get; set; } = null!;

    public virtual Question Question11Navigation { get; set; } = null!;

    public virtual Question Question12Navigation { get; set; } = null!;

    public virtual Question Question13Navigation { get; set; } = null!;

    public virtual Question Question14Navigation { get; set; } = null!;

    public virtual Question Question15Navigation { get; set; } = null!;

    public virtual Question Question16Navigation { get; set; } = null!;

    public virtual Question Question17Navigation { get; set; } = null!;

    public virtual Question Question18Navigation { get; set; } = null!;

    public virtual Question Question19Navigation { get; set; } = null!;

    public virtual Question Question1Navigation { get; set; } = null!;

    public virtual Question Question20Navigation { get; set; } = null!;

    public virtual Question Question2Navigation { get; set; } = null!;

    public virtual Question Question3Navigation { get; set; } = null!;

    public virtual Question Question4Navigation { get; set; } = null!;

    public virtual Question Question5Navigation { get; set; } = null!;

    public virtual Question Question6Navigation { get; set; } = null!;

    public virtual Question Question7Navigation { get; set; } = null!;

    public virtual Question Question8Navigation { get; set; } = null!;

    public virtual Question Question9Navigation { get; set; } = null!;
}
