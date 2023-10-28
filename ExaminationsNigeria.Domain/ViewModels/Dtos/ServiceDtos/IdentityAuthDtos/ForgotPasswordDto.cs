using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.ViewModels.Dtos.ServiceDtos.IdentityAuthDtos
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Addess")]
        public string Email { get; set; }
    }
}
