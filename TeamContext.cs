using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Contexts
{
    public class TeamContext : DbContext
    {
        public TeamContext() : base("name = TeamContext")
        {

        }
        public DbSet<Team> Team { get; set; }
    }
}
