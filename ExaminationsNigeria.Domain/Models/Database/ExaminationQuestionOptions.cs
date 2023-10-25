using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;
using System.ComponentModel.DataAnnotations;


namespace ExaminationsNigeria.Domain.Models.Database
{
  public class ExaminationQuestionOptions : BaseDatabaseModel
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Option One"), Required]
    public string? OptionOne { get; set; }

    [Display(Name = "Option Two"), Required]
    public string? OptionTwo { get; set; }

    [Display(Name = "Option Three")]
    public string? OptionThree { get; set; }

    [Display(Name = "Option Four")]
    public string? OptionFour { get; set; }

    [Display(Name = "Option Five")]
    public string? OptionFive { get; set; }

    [Display(Name = "Option Answer"), Required]
    public int OptionAnswer { get; set; }


    //Relationships
    public virtual ExaminationQuestion? ExaminationQuestion { get; set; }

    [Display(Name = "Question Type"), Required]
    public int ExaminationQuestionId { get; set; }
  }
}
