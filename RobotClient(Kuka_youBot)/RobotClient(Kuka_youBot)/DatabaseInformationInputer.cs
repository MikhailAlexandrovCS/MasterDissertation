using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClient_Kuka_youBot_
{
    public class DatabaseInformationInputer : DbContext
    {
        public DbSet<PathResultInformation> info { get; set; }
        public DbSet<PathRegion> pathRegions { get; set; }

        public DatabaseInformationInputer() : base("DefaultConnection")
        {

        }
    }
}
