using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.ViewModels.Dtos.ServiceDtos.IdentityAuthDtos
{
    public class ConfirmEmailChangeDto
    {

        [Required, Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required, Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, Display(Name = "Code")]
        public string Code { get; set; }

    }

}
