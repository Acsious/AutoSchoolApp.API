using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class Question
{
    public int Id { get; set; }

    public int QuestionNumber { get; set; }

    public string? Formulation { get; set; }

    public string? CorrectAnswer { get; set; }

    public string? FirstIncorrectAnswer { get; set; }

    public string? SecondIncorrectAnswer { get; set; }

    public string? ThirdIncorrectAnswer { get; set; }

    public string? Theme { get; set; }

    public virtual ICollection<PerformanceOnQuestion> PerformanceOnQuestions { get; set; } = new List<PerformanceOnQuestion>();

    public virtual ICollection<Ticket> TicketQuestion10Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion11Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion12Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion13Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion14Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion15Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion16Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion17Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion18Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion19Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion1Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion20Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion2Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion3Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion4Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion5Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion6Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion7Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion8Navigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQuestion9Navigations { get; set; } = new List<Ticket>();
}
