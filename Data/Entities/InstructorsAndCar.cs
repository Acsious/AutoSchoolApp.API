using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class InstructorsAndCar
{
    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public string Марка { get; set; } = null!;

    public string Модель { get; set; } = null!;

    public string РегистрационныйНомер { get; set; } = null!;
}
