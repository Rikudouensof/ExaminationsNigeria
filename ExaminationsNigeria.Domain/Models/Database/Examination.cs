using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class Examination : BaseDatabaseModel
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Instructions { get; set; }


    //Relationships
    [Display(Name = "Examination Date")]
    public DateTime ExamDate { get; set; }

    public virtual ExaminationBody? ExaminationBody { get; set; }

    [Display(Name = "Examination Body"), Required]
    public int ExaminationBodyId { get; set; }


    public virtual ICollection<ExaminationQuestion>? ExaminationQuestions { get; set; }
  }
}
