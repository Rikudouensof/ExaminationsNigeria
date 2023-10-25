using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class ExaminationAnswer : BaseDatabaseModel
  {
    [Key]
    public int Id { get; set; }

    public DateTime TimeAnswered { get; set; } = DateTime.Now;

    [Required]
    public string? Answer { get; set; }


    //Relationships
    public virtual ExaminationQuestion? ExaminationQuestion { get; set; }

    [Required]
    public int ExaminationQuestionId { get; set; }


    

    [Required]
    public int SessionId { get; set; }

  }
}
