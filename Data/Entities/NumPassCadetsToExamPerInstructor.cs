using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class NumPassCadetsToExamPerInstructor
{
    public string? Инструктор { get; set; }

    public int? КолВоКурсантовДопущенныхКПрактическомуЭкзамену { get; set; }
}
