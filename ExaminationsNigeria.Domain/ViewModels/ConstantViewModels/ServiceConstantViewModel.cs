using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.ViewModels.ConstantViewModels
{
  public class ServiceConstantViewModel
  {

    [Required]
    public int Code { get; set; }


    [Required]
    public string Description { get; set; }
  }
}
