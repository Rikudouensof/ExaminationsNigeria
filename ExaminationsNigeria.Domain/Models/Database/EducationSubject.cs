using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class EducationSubject : BaseDatabaseModel
  {
    [Key]
    [Display(Name = "Subject Id")]
    public int Id { get; set; }

    [Display(Name ="Subject Name")]
    [Required]
    public string? Name { get; set; }
  }
}
