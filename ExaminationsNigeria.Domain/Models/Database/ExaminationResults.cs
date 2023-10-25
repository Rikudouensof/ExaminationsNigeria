using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class ExaminationResults : BaseDatabaseModel
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int ScoredPoints { get; set; }

    [Required]
    public string TotalPoints { get; set; }

    //Relationships

    public ExaminationSession? ExaminationSession { get; set; }
    public int ExaminationSessionId { get; set; }
  }
}
