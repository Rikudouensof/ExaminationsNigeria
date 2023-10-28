using ExaminationsNigeria.Domain.ViewModels.Dtos.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Application.Services
{
  public interface IEmailService
  {

    Task SendMailAsync(EmailRequestDto message);
  }
}
