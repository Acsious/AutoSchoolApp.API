using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class FullSchedule
{
    public string? Дата { get; set; }

    public int InstructorId { get; set; }

    public string? Инструктор { get; set; }

    public int CadetId { get; set; }

    public string? Курсант { get; set; }

    public string? Время { get; set; }
}
