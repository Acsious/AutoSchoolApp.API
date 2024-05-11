using System;
using System.Collections.Generic;

namespace AutoSchoolApp.API.Data.Entities;

public partial class AllInfoAboutUser
{
    public int ИдентификаторПользователя { get; set; }

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public string Роль { get; set; } = null!;
}
