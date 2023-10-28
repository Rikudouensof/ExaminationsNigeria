using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models
{
  public class AppSettings
  {


    public string BaseConnectionString { get; set; }

    public string SmtpEmailAddress { get; set; }
    public string SmtpPassword { get; set; }

    public string SendGridEmailApiKey { get; set; }
  }

}
