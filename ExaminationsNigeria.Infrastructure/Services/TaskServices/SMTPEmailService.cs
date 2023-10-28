using ExaminationsNigeria.Application.Services;
using ExaminationsNigeria.Domain.ViewModels.Dtos.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Infrastructure.Services.TaskServices
{
  public class SMTPEmailService : IEmailService
  {

    public async Task SendMailAsync(EmailRequestDto message)
    {
      #region formatter
      string text = string.Format("{0}: {1}", message.Subject, message.Body);

      #endregion

      MailMessage msg = new MailMessage();
      msg.From = new MailAddress(message.AppSettings.SmtpEmailAddress);
      msg.To.Add(new MailAddress(message.DesinationEmail));
      msg.Subject = message.Subject;
      msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html));
      msg.IsBodyHtml = true;
      SmtpClient smtpClient = new SmtpClient("Kigoo.properties", Convert.ToInt32(587));
      System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(message.AppSettings.SmtpEmailAddress, message.AppSettings.SmtpPassword);
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = credentials;
      smtpClient.EnableSsl = false;
      smtpClient.Send(msg);
    }
  }
}
