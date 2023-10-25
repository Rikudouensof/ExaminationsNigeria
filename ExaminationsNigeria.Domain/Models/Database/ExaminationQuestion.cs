using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class ExaminationQuestion : BaseDatabaseModel
  {
    [Key]
    [Display(Name = "Exam Question Id")]
    public int Id { get; set; }

    [Display(Name = "Question")]
    [Required]
    public string? Question { get; set; }

    [Display(Name = "Question Image Url")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Question Number")]
    public int? QuestionNumber { get; set; }

    [Display(Name = "Question Points")]
    public int QuestionPoints { get; set; }

    //Relationships
    public virtual ExaminationQuestionType? QuestionType { get; set; }


    [Display(Name = "Question Type"), Required]
    public int QuestionTypeId { get; set; }



    [Display(Name = "Question Number")]
    public Examination? Examination { get; set; }

    [Required, Display(Name = "Examination")]
    public int ExaminationId { get; set; }


  }
}
