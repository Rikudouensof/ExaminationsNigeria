using ExaminationsNigeria.Domain.Models.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Infrastructure.Data
{
  public class ApplicationDbContext : IdentityDbContext<User>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<EducationSubject> EducationSubjects { get; set; }
    public DbSet<Examination> Examinations { get; set; }
    public DbSet<ExaminationAnswer> ExaminationAnswers { get; set; }
    public DbSet<ExaminationBody> ExaminationBodies { get; set; }
    public DbSet<ExaminationQuestion> ExaminationQuestions { get; set; }
    public DbSet<ExaminationQuestionOptions> ExaminationQuestionOptions { get; set; }
    public DbSet<ExaminationQuestionType> QuestionTypes { get; set; }
    public DbSet<ExaminationResults> ExaminationResults { get; set; }
    public DbSet<ExaminationSession> ExaminationSessions { get; set; }
   


  }
}
