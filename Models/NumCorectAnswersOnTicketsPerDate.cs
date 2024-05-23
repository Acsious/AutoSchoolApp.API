using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class NumCorectAnswersOnTicketsPerDate
{
    public DateOnly? Дата { get; set; }

    public int? КолВоПравильноРешённыхБилетовов { get; set; }
}
