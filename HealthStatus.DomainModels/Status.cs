using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStatus.DomainModels
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Uid { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentStatus { get; set; }
        public string Comments { get; set; }
      //  public string Email { get; set; }


        [ForeignKey("Uid")]
        public virtual User User { get; set; }
    }
}
