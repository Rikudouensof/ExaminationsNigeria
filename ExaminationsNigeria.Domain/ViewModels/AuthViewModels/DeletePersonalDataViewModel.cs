using ExaminationsNigeria.Domain.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.ViewModels.AuthViewModels
{
  public class DeletePersonalDataViewModel
  {
    [Required]
    public User User { get; set; }


    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}
