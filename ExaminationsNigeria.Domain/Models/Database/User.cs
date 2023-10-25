using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class User : IdentityUser
  {
    [Required]
    public DateTime LastOnline { get; set; }

    [Required]
    public DateTime JoinedOn { get; set; }
  }
}
