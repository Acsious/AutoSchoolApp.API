using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Cadet> Cadets { get; set; } = new List<Cadet>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SignUpForDriving> SignUpForDrivings { get; set; } = new List<SignUpForDriving>();

    public virtual ICollection<PerformanceOnQuestion> PerformanceOnQuestions { get; set; } = new List<PerformanceOnQuestion>();

    public virtual ICollection<PerformanceOnTicket> PerformanceOnTickets { get; set; } = new List<PerformanceOnTicket>();
}
