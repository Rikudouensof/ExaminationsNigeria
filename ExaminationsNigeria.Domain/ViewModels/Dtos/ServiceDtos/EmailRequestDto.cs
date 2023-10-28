using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.ViewModels.Dtos.ServiceDtos
{
  public class EmailRequestDto : BaseRequestDto
  {

    [Required]
    [EmailAddress]
    public string? DesinationEmail { get; set; }

    public string[]? CC { get; set; }

    [Required]
    public string? Body { get; set; }

    [Required]
    public string Subject { get; set; }


    public string[]? BCC { get; set; }


    [Required]
    public string EmailSourceName { get; set; }

  }
}
