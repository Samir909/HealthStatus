using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStatus.ViewModels
{
    public class UserModel
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [NotMapped]
        
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string confirmPassword { get; set; }

        [System.ComponentModel.DefaultValue(0)]
        public int IsAdmin { get; set; }
    }
}
