using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class NumCorectAnswersOnQuestionsPerTheme
{
    public string? Тема { get; set; }

    public int? КолВоПравильноРешённыхВопросов { get; set; }
}
