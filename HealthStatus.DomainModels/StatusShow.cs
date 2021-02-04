using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStatus.DomainModels
{
    public class StatusShow
    {
        public string Email { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string Date { get; set; }

        public int Count { get; set; }

    }
}
