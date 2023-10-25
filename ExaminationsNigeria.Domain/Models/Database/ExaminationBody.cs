using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class ExaminationBody : BaseDatabaseModel
  {
    [Key]
    [Display(Name = "Examination Id")]
    public int Id { get; set; }

    [Display(Name = "Examination Name")]
    [Required]
    public string? Name { get; set; }

    [Display(Name = "Examination Short Name")]
    [Required]
    public string? ShortName { get; set; }

  }
}
