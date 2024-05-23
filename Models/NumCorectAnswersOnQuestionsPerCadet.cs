using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Models;

public partial class NumCorectAnswersOnQuestionsPerCadet
{
    public string? Курсант { get; set; }

    public int? КолВоПравильноРешённыхВопросов { get; set; }
}
