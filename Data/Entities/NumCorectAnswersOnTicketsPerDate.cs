using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class NumCorectAnswersOnTicketsPerDate
{
    public DateOnly? Дата { get; set; }

    public int? КолВоПравильноРешённыхБилетовов { get; set; }
}
