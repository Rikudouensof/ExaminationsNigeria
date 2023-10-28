using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.ViewModels.Dtos.ServiceDtos.IdentityAuthDtos
{
  public class LoginDto
  {
    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; }


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }

  }
}
