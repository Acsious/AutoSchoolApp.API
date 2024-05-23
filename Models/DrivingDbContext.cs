using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoSchoolApp.API.Models;

public partial class DrivingDbContext : DbContext
{
    public DrivingDbContext()
    {
    }

    public DrivingDbContext(DbContextOptions<DrivingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllInfoAboutUser> AllInfoAboutUsers { get; set; }

    public virtual DbSet<Cadet> Cadets { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Fiocadet> Fiocadets { get; set; }

    public virtual DbSet<Fioinstructor> Fioinstructors { get; set; }

    public virtual DbSet<FullSchedule> FullSchedules { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InstructorAuto> InstructorAutos { get; set; }

    public virtual DbSet<InstructorsAndCar> InstructorsAndCars { get; set; }

    public virtual DbSet<NumCorectAnswersOnQuestionsPerCadet> NumCorectAnswersOnQuestionsPerCadets { get; set; }

    public virtual DbSet<NumCorectAnswersOnQuestionsPerTheme> NumCorectAnswersOnQuestionsPerThemes { get; set; }

    public virtual DbSet<NumCorectAnswersOnTicketsPerDate> NumCorectAnswersOnTicketsPerDates { get; set; }

    public virtual DbSet<NumPassCadetsToExamPerInstructor> NumPassCadetsToExamPerInstructors { get; set; }

    public virtual DbSet<PerformanceOnQuestion> PerformanceOnQuestions { get; set; }

    public virtual DbSet<PerformanceOnTicket> PerformanceOnTickets { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<SignUpForDriving> SignUpForDrivings { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KBQVOJR;Database=drivingDB;Trusted_Connection=True;TrustServerCertificate=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllInfoAboutUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("allInfoAboutUsers");

            entity.Property(e => e.ИдентификаторПользователя).HasColumnName("Идентификатор пользователя");
            entity.Property(e => e.Имя)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Логин)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Отчество)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Роль)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Фамилия)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cadet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cadet__3214EC27FA845FF5");

            entity.ToTable("Cadet");

            entity.HasIndex(e => e.Id, "Cadet_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Cadets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCadet652147");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC27CD35C4A2");

            entity.HasIndex(e => e.Id, "Classes_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClassTime).HasPrecision(0);
        });

        modelBuilder.Entity<Fiocadet>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FIOCadet");

            entity.Property(e => e.IdCadet).HasColumnName("Id_Cadet");
            entity.Property(e => e.Фио)
                .HasMaxLength(122)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Fioinstructor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FIOInstructors");

            entity.Property(e => e.IdInstructor).HasColumnName("Id_Instructor");
            entity.Property(e => e.Фио)
                .HasMaxLength(122)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<FullSchedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FullSchedule");

            entity.Property(e => e.CadetId).HasColumnName("CadetID");
            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.Время).HasMaxLength(4000);
            entity.Property(e => e.Дата).HasMaxLength(4000);
            entity.Property(e => e.Инструктор)
                .HasMaxLength(122)
                .IsUnicode(false);
            entity.Property(e => e.Курсант)
                .HasMaxLength(122)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instruct__3214EC27E52CAA54");

            entity.ToTable("Instructor");

            entity.HasIndex(e => e.Id, "Instructor_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InstructorAutoId).HasColumnName("InstructorAutoID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.InstructorAuto).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.InstructorAutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKInstructor345072");

            entity.HasOne(d => d.User).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKInstructor151216");
        });

        modelBuilder.Entity<InstructorAuto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instruct__3214EC27DC9DDB1D");

            entity.ToTable("InstructorAuto", tb => tb.HasTrigger("DelAuto"));

            entity.HasIndex(e => e.Id, "InstructorAuto_ID").IsUnique();

            entity.HasIndex(e => e.LicensePlate, "UQ__Instruct__026BC15CE21AFB37").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Brand)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InstructorsAndCar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("InstructorsAndCars");

            entity.Property(e => e.Имя)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Марка)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Модель)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Отчество)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.РегистрационныйНомер)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Регистрационный номер");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NumCorectAnswersOnQuestionsPerCadet>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NumCorectAnswersOnQuestionsPerCadet");

            entity.Property(e => e.КолВоПравильноРешённыхВопросов).HasColumnName("Кол-во правильно решённых вопросов");
            entity.Property(e => e.Курсант)
                .HasMaxLength(122)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NumCorectAnswersOnQuestionsPerTheme>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NumCorectAnswersOnQuestionsPerTheme");

            entity.Property(e => e.КолВоПравильноРешённыхВопросов).HasColumnName("Кол-во правильно решённых вопросов");
            entity.Property(e => e.Тема)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NumCorectAnswersOnTicketsPerDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NumCorectAnswersOnTicketsPerDate");

            entity.Property(e => e.КолВоПравильноРешённыхБилетовов).HasColumnName("Кол-во правильно решённых билетовов");
        });

        modelBuilder.Entity<NumPassCadetsToExamPerInstructor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NumPassCadetsToExamPerInstructor");

            entity.Property(e => e.Инструктор)
                .HasMaxLength(122)
                .IsUnicode(false);
            entity.Property(e => e.КолВоКурсантовДопущенныхКПрактическомуЭкзамену).HasColumnName("Кол-во курсантов допущенных к практическому экзамену");
        });

        modelBuilder.Entity<PerformanceOnQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Performa__3214EC2798929F43");

            entity.HasIndex(e => e.Id, "PerformanceOnQuestions_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Question).WithMany(p => p.PerformanceOnQuestions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPerformanc789912");
        });

        modelBuilder.Entity<PerformanceOnTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Performa__3214EC274B7880E5");

            entity.HasIndex(e => e.Id, "PerformanceOnTickets_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Ticket).WithMany(p => p.PerformanceOnTickets)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPerformanc752572");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC27F6A918D7");

            entity.ToTable("Question");

            entity.HasIndex(e => e.Id, "Question_ID").IsUnique();

            entity.HasIndex(e => e.QuestionNumber, "UQ__Question__3A469287CA0C1861").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CorrectAnswer)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.FirstIncorrectAnswer)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Formulation)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.SecondIncorrectAnswer)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Theme)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ThirdIncorrectAnswer)
                .HasMaxLength(512)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC27F7AE08BF");

            entity.ToTable("Role", tb => tb.HasTrigger("InsertRole"));

            entity.HasIndex(e => e.Id, "Role_ID").IsUnique();

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B6160E9D19E3F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC27E3440114");

            entity.ToTable("Schedule");

            entity.HasIndex(e => e.Id, "Schedule_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClassesId).HasColumnName("ClassesID");
            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

            entity.HasOne(d => d.Classes).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ClassesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSchedule187494");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSchedule700162");
        });

        modelBuilder.Entity<SignUpForDriving>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SignUpFo__3214EC27CCAD9775");

            entity.ToTable("SignUpForDriving", tb =>
                {
                    tb.HasTrigger("OnNewSignNotification");
                    tb.HasTrigger("OnRemoveSignNotification");
                    tb.HasTrigger("OnRemoveSignUpForDriving");
                });

            entity.HasIndex(e => e.Id, "SignUpForDriving_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Schedule).WithMany(p => p.SignUpForDrivings)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSignUpForD46785");

            entity.HasOne(d => d.User).WithMany(p => p.SignUpForDrivings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSignUpForD603085");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC272BE2A347");

            entity.ToTable("Ticket");

            entity.HasIndex(e => e.Id, "Ticket_ID").IsUnique();

            entity.HasIndex(e => e.TicketNumber, "UQ__Ticket__CBED06DACAAC61EE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Question1Navigation).WithMany(p => p.TicketQuestion1Navigations)
                .HasForeignKey(d => d.Question1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384849");

            entity.HasOne(d => d.Question10Navigation).WithMany(p => p.TicketQuestion10Navigations)
                .HasForeignKey(d => d.Question10)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558662");

            entity.HasOne(d => d.Question11Navigation).WithMany(p => p.TicketQuestion11Navigations)
                .HasForeignKey(d => d.Question11)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558661");

            entity.HasOne(d => d.Question12Navigation).WithMany(p => p.TicketQuestion12Navigations)
                .HasForeignKey(d => d.Question12)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558660");

            entity.HasOne(d => d.Question13Navigation).WithMany(p => p.TicketQuestion13Navigations)
                .HasForeignKey(d => d.Question13)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558659");

            entity.HasOne(d => d.Question14Navigation).WithMany(p => p.TicketQuestion14Navigations)
                .HasForeignKey(d => d.Question14)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558658");

            entity.HasOne(d => d.Question15Navigation).WithMany(p => p.TicketQuestion15Navigations)
                .HasForeignKey(d => d.Question15)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558657");

            entity.HasOne(d => d.Question16Navigation).WithMany(p => p.TicketQuestion16Navigations)
                .HasForeignKey(d => d.Question16)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558656");

            entity.HasOne(d => d.Question17Navigation).WithMany(p => p.TicketQuestion17Navigations)
                .HasForeignKey(d => d.Question17)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558655");

            entity.HasOne(d => d.Question18Navigation).WithMany(p => p.TicketQuestion18Navigations)
                .HasForeignKey(d => d.Question18)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558654");

            entity.HasOne(d => d.Question19Navigation).WithMany(p => p.TicketQuestion19Navigations)
                .HasForeignKey(d => d.Question19)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558653");

            entity.HasOne(d => d.Question2Navigation).WithMany(p => p.TicketQuestion2Navigations)
                .HasForeignKey(d => d.Question2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384850");

            entity.HasOne(d => d.Question20Navigation).WithMany(p => p.TicketQuestion20Navigations)
                .HasForeignKey(d => d.Question20)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket558631");

            entity.HasOne(d => d.Question3Navigation).WithMany(p => p.TicketQuestion3Navigations)
                .HasForeignKey(d => d.Question3)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384851");

            entity.HasOne(d => d.Question4Navigation).WithMany(p => p.TicketQuestion4Navigations)
                .HasForeignKey(d => d.Question4)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384852");

            entity.HasOne(d => d.Question5Navigation).WithMany(p => p.TicketQuestion5Navigations)
                .HasForeignKey(d => d.Question5)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384853");

            entity.HasOne(d => d.Question6Navigation).WithMany(p => p.TicketQuestion6Navigations)
                .HasForeignKey(d => d.Question6)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384854");

            entity.HasOne(d => d.Question7Navigation).WithMany(p => p.TicketQuestion7Navigations)
                .HasForeignKey(d => d.Question7)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384855");

            entity.HasOne(d => d.Question8Navigation).WithMany(p => p.TicketQuestion8Navigations)
                .HasForeignKey(d => d.Question8)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384856");

            entity.HasOne(d => d.Question9Navigation).WithMany(p => p.TicketQuestion9Navigations)
                .HasForeignKey(d => d.Question9)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTicket384857");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC278FA85A45");

            entity.ToTable("User", tb => tb.HasTrigger("InsertCadet"));

            entity.HasIndex(e => e.Login, "UQ__User__5E55825B54880DE1").IsUnique();

            entity.HasIndex(e => e.Id, "User_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.SecondName)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUser349791");

            entity.HasMany(d => d.PerformanceOnQuestions).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserPerformanceOnQuestion",
                    r => r.HasOne<PerformanceOnQuestion>().WithMany()
                        .HasForeignKey("PerformanceOnQuestionsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKUser_Perfo101733"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKUser_Perfo790577"),
                    j =>
                    {
                        j.HasKey("UserId", "PerformanceOnQuestionsId").HasName("PK__User_Per__E8B5F59698582D25");
                        j.ToTable("User_PerformanceOnQuestions");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("PerformanceOnQuestionsId").HasColumnName("PerformanceOnQuestionsID");
                    });

            entity.HasMany(d => d.PerformanceOnTickets).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserPerformanceOnTicket",
                    r => r.HasOne<PerformanceOnTicket>().WithMany()
                        .HasForeignKey("PerformanceOnTicketsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKUser_Perfo9023"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKUser_Perfo184059"),
                    j =>
                    {
                        j.HasKey("UserId", "PerformanceOnTicketsId").HasName("PK__User_Per__C3E2EBBC3B952200");
                        j.ToTable("User_PerformanceOnTickets");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("PerformanceOnTicketsId").HasColumnName("PerformanceOnTicketsID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
