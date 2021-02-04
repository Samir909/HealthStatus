using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStatus.DomainModels
{
   public class HealthStatusDbContext : DbContext
    {
        public HealthStatusDbContext() : base("Myconnection")
        {
            

        }
        public DbSet<User> users { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}
