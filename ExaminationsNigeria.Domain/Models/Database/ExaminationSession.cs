using ExaminationsNigeria.Domain.Models.Database.BaseDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationsNigeria.Domain.Models.Database
{
  public class ExaminationSession : BaseDatabaseModel
  {

    [Key]
    public int Id { get; set; }


    //Rekationships
    public virtual User? Examinee { get; set; }

    [Required]
    public int ExamineeId { get; set; }

    public virtual Examination? Examination { get; set; }

    [Required]
    public int ExaminationId { get; set; }

    public virtual ICollection<ExaminationAnswer>? ExaminationAnswers { get; set; }


  }
}
