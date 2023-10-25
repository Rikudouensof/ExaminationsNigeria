using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database.BaseDatabase
{
  public class BaseDatabaseModel
  {
    [Required(ErrorMessage ="Please set who is creating this record")]
    [Display(Name = "Created By")]
    public string? CreatedById { get; set; }

    [Required(ErrorMessage = "Please set when this record is created")]
    [Display(Name = "Created On")]
    public DateTime CreatedOn { get; set; }

    [Required(ErrorMessage = "Please set when this record is updated")]
    [Display(Name = "Updated On")]
    public DateTime UpdatedOn { get; set; }

    [Display(Name = "Updated By")]
    [Required(ErrorMessage = "Please set who is updating this record")]
    public string? UpdatedById { get; set; }
  }
}
